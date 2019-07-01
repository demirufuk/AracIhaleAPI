using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(object id);

        T First(Expression<Func<T, bool>> where);

        void Insert(T obj);

        void Update(T obj);

        void Delete(object id);

        void Save();
    }
}