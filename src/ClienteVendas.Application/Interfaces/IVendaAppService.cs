using ClienteVendas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Application.Interfaces
{
    public interface IVendaAppService : IAppServiceBase<VendaViewModel>
    {
        List<GraficoVendaViewModel> BuscarVendas(GraficoVendaConsultaViewModel graficoVendaConsultaViewModel);
        IEnumerable<VendaViewModel> BuscarVendasPorClienteId(int clienteId);
    }
}
