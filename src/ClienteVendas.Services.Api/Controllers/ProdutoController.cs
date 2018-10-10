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
    public class ProdutoController : BaseController
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet]
        [Route("findById")]
        public ProdutoViewModel FindById(int id)
        {
            try
            {
                return _produtoAppService.FindById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IEnumerable<ProdutoViewModel> Get()
        {
            try
            {
                return _produtoAppService.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public void Post([FromBody] ProdutoViewModel produtoViewModel)
        {
            try
            {
                _produtoAppService.Add(produtoViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public void Put([FromBody] ProdutoViewModel produtoViewModel)
        {
            try
            {
                _produtoAppService.Update(produtoViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}