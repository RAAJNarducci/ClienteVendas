using ClienteVendas.Domain.Core;
using ClienteVendas.Domain.Entities;
using ClienteVendas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto, IProdutoRepository>, IProdutoService
    {
        public ProdutoService(IProdutoRepository repository) : base(repository)
        {
        }
    }
}
