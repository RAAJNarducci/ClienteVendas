using ClienteVendas.Domain.Entities;
using ClienteVendas.Domain.Interfaces;
using ClienteVendas.Infra.Data.Context;
using Microsoft.Extensions.Configuration;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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
