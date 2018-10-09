using ClienteVendas.Domain.Core;
using ClienteVendas.Domain.Entities;
using ClienteVendas.Domain.Interfaces;
using ClienteVendas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}
