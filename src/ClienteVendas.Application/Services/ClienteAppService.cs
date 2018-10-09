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
    public class ClienteAppService : AppServicebase<Cliente, ClienteViewModel, IClienteService>, IClienteAppService
    {
        public ClienteAppService(IUnitOfWork uow, IClienteService service, IMapper mapper) : base(uow, service, mapper)
        {
        }
    }
}
