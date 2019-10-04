using FluentValidation;
using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Modelo.Domain.Interfaces
{
    public interface IService<T> 
    {
        T Post(T obj);

        T Put(T obj);

        void Delete(int id);

        T Get(int id, params Expression<Func<T, object>>[] includeExpressions);

        IList<T> Get(params Expression<Func<T, object>>[] includeExpressions);
    }
}
