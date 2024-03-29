﻿using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Modelo.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Insert(T obj);

        void Update(T obj);

        void Delete(int id);

        T Select(int id, params Expression<Func<T, object>>[] includeExpressions);

        IList<T> Select(params Expression<Func<T, object>>[] includeExpressions);
    }
}
