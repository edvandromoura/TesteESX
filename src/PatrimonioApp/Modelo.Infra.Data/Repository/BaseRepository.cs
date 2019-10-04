
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Infra.Data.Context;

namespace Modelo.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private SQLServerContext Context { get; set; }
        private DbSet<T> dbSet;

        public BaseRepository(SQLServerContext sqlServerContext)
        {
            Context = sqlServerContext;
            this.dbSet = Context.Set<T>();
        }

        public void Insert(T obj)
        {
            obj.Created = DateTime.Now;
            Context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            Context.SaveChanges();
        }

        public void Update(T obj)
        {
            obj.Updated = DateTime.Now;
            Context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Context.Entry(Select(id)).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            Context.SaveChanges();
        }

        public IList<T> Select(params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            if (includeExpressions.Count() > 0)
                query = includeExpressions.Aggregate(query, (current, expressionInclude) => current.Include(expressionInclude));

            return query.ToList();
        }

        public T Select(int id, params Expression<Func<T, object>>[] includeExpressions)
        {
            return Select(includeExpressions).FirstOrDefault(x => x.Id == id);
        }
    }
}
