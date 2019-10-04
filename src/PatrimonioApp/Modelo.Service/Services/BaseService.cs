using FluentValidation;
using Modelo.Domain.Entities;
using Modelo.Domain.Interfaces;
using Modelo.Infra.Data.Context;
using Modelo.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Modelo.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> _repository { get; set; }
        public BaseService(SQLServerContext sqlServerContext)
        {
            _repository = new BaseRepository<T>(sqlServerContext);
        }

        public T Post(T obj)
        {
            _repository.Insert(obj);
            return obj;
        }

        public T Put(T obj)
        {
            _repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IList<T> Get(params Expression<Func<T, object>>[] includeExpressions)
        {
            return _repository.Select(includeExpressions);
        }

        public T Get(int id, params Expression<Func<T, object>>[] includeExpressions)
        {
            return _repository.Select(id, includeExpressions);
        }
    }
}
