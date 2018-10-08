using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Domain.Core
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : EntityBase<TEntity>
    {
        TEntity Add(TEntity entity);
        TEntity FindById(int id);
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> GetAll();
        void Delete(int id);
        int SaveChanges();
    }
}
