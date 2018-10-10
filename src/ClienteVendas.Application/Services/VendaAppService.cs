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
    public class VendaAppService : AppServicebase<Venda, VendaViewModel, IVendaService>, IVendaAppService
    {
        public VendaAppService(IUnitOfWork uow, IVendaService service, IMapper mapper) : base(uow, service, mapper)
        {
        }
    }
}
