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

        public ClienteResponseViewModel BuscarClientes(ClienteConsultaViewModel clienteConsultaViewModel)
        {
            int total = 0;

            var clienteMapper = _mapper.Map<List<ClienteViewModel>>(_service.BuscarClientes(
                clienteConsultaViewModel.Nome, 
                clienteConsultaViewModel.Cpf, 
                clienteConsultaViewModel.Pagina, 
                clienteConsultaViewModel.QuantidadePagina, 
                out total));
            return new ClienteResponseViewModel
            {
                Clientes = clienteMapper,
                TotalItens = total
            };
        }
    }
}
