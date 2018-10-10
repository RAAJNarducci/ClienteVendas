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