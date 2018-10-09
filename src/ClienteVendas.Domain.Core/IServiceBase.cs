using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Domain.Core
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : EntityBase<TEntity>
    {
        TEntity Add(TEntity entity);
        TEntity FindById(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
