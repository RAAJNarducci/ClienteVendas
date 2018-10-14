using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClienteVendas.Application.Interfaces;
using ClienteVendas.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClienteVendas.Services.Api.Controllers
{
    public class ClienteController : BaseController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        [Route("BuscarClientes")]
        public ClienteResponseViewModel BuscarClientes(ClienteConsultaViewModel clienteConsultaViewModel)
        {
            return _clienteAppService.BuscarClientes(clienteConsultaViewModel);
        }

        [HttpGet]
        [Route("findById")]
        public ClienteViewModel FindById(int id)
        {
            try
            {
                return _clienteAppService.FindById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IEnumerable<ClienteViewModel> Get()
        {
            try
            {
                return _clienteAppService.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public void Post([FromBody] ClienteViewModel clienteViewModel)
        {
            try
            {
                _clienteAppService.Add(clienteViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public void Put([FromBody] ClienteViewModel clienteViewModel)
        {
            try
            {
                _clienteAppService.Update(clienteViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}