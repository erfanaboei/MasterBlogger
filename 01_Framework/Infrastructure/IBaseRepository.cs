using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _01_Framework.Infrastructure
{
    public interface IBaseRepository<in TKey , T>
    {
        void Create(T entity);
        T Get(TKey id);
        List<T> GetAll();
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
