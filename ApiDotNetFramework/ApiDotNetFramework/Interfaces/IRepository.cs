using System;
using System.Collections.Generic;

namespace ApiDotNetFramework.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : class 
    {
        List<TEntity> GetAll();
        TEntity GetById(TKey id);
        int Insert(TEntity entity);
        void Update(TEntity entity, TKey id);
        void Delete(TKey id);
    }
}
