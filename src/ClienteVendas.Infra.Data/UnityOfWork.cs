using ClienteVendas.Domain.Core;
using ClienteVendas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;

        public UnitOfWork(MainContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
