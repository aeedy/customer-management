using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CustomerManagement.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Delete(int id);
        IEnumerable<TEntity> Get();
        TEntity GetById(int id);
        bool Insert(TEntity entity);
    }
}
