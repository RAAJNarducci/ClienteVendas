using AutoMapper;
using ClienteVendas.Application.Interfaces;
using ClienteVendas.Application.ViewModels;
using ClienteVendas.Domain.Core;
using ClienteVendas.Domain.Entities;
using ClienteVendas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Application.Services
{
    public class ProdutoAppService : AppServicebase<Produto, ProdutoViewModel, IProdutoService>, IProdutoAppService
    {
        public ProdutoAppService(IUnitOfWork uow, IProdutoService service, IMapper mapper) : base(uow, service, mapper)
        {
        }
    }
}
