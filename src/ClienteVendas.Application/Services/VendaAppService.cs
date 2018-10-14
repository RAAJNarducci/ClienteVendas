using AutoMapper;
using ClienteVendas.Application.Interfaces;
using ClienteVendas.Application.ViewModels;
using ClienteVendas.Domain.Core;
using ClienteVendas.Domain.Entities;
using ClienteVendas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ClienteVendas.Data.CrossCutting.Helpers;

namespace ClienteVendas.Application.Services
{
    public class VendaAppService : AppServicebase<Venda, VendaViewModel, IVendaService>, IVendaAppService
    {
        public VendaAppService(IUnitOfWork uow, IVendaService service, IMapper mapper) : base(uow, service, mapper)
        {
        }

        public IEnumerable<VendaViewModel> BuscarVendasPorClienteId(int clienteId)
        {
            return _mapper.Map<IEnumerable<VendaViewModel>>(_service.BuscarVendasPorClienteId(clienteId));
        }

        public List<GraficoVendaViewModel> BuscarVendas(GraficoVendaConsultaViewModel graficoVendaConsultaViewModel)
        {
            List<GraficoVendaViewModel> graficoVendaViewModels = new List<GraficoVendaViewModel>();
            var vendas = _service.BuscarVendas(graficoVendaConsultaViewModel.DataInicio, graficoVendaConsultaViewModel.DataFim).ToList();
            for (int mes = graficoVendaConsultaViewModel.DataInicio.Value.Month; mes <= graficoVendaConsultaViewModel.DataFim.Value.Month; mes++)
            {
                EnumMeses enumMes = (EnumMeses)mes;
                var total = vendas.Where(x => x.DataVenda.Month == mes).Sum(p => p.Quantidade * p.Produto.Valor);
                GraficoVendaViewModel graficoVendaViewModel = new GraficoVendaViewModel
                {
                    Mes = enumMes.ToString(),
                    Total = total
                };
                graficoVendaViewModels.Add(graficoVendaViewModel);
            }
            return graficoVendaViewModels;
        }
    }
}
