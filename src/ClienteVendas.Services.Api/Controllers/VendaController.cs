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
    public class VendaController : BaseController
    {
        private readonly IVendaAppService _vendaAppService;

        public VendaController(IVendaAppService vendaAppService)
        {
            _vendaAppService = vendaAppService;
        }

        [HttpGet]
        [Route("BuscarVendasPorClienteId")]
        public IEnumerable<VendaViewModel> BuscarVendasPorClienteId(int clienteId)
        {
            try
            {
                return _vendaAppService.BuscarVendasPorClienteId(clienteId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("BuscarVendas")]
        public List<GraficoVendaViewModel> BuscarVendas(GraficoVendaConsultaViewModel graficoVendaConsultaViewModel)
        {
            try
            {
                if (!graficoVendaConsultaViewModel.DataInicio.HasValue)
                    graficoVendaConsultaViewModel.DataInicio = DateTime.Now.Date.AddDays(-90);
                if (!graficoVendaConsultaViewModel.DataFim.HasValue)
                    graficoVendaConsultaViewModel.DataFim = DateTime.Now.Date;
                return _vendaAppService.BuscarVendas(graficoVendaConsultaViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [Route("findById")]
        public VendaViewModel FindById(int id)
        {
            try
            {
                return _vendaAppService.FindById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IEnumerable<VendaViewModel> Get()
        {
            try
            {
                return _vendaAppService.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public void Post([FromBody] VendaViewModel vendaViewModel)
        {
            try
            {
                _vendaAppService.Add(vendaViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public void Put([FromBody] VendaViewModel vendaViewModel)
        {
            try
            {
                _vendaAppService.Update(vendaViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}