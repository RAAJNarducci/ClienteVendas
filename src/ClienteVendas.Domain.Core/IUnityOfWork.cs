using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
