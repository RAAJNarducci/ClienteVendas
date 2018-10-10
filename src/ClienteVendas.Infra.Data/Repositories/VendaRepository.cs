using ClienteVendas.Domain.Entities;
using ClienteVendas.Domain.Interfaces;
using ClienteVendas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Infra.Data.Repositories
{
    public class VendaRepository : RepositoryBase<Venda>, IVendaRepository
    {
        public VendaRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}
