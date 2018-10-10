using ClienteVendas.Domain.Entities;
using ClienteVendas.Domain.Interfaces;
using ClienteVendas.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MainContext mainContext) : base(mainContext)
        {
        }
    }
}
