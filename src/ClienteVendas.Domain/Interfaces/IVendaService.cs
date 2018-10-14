using ClienteVendas.Domain.Core;
using ClienteVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Domain.Interfaces
{
    public interface IVendaService : IServiceBase<Venda>
    {
        IEnumerable<Venda> BuscarVendas(DateTime? dataInicio, DateTime? dataFim);
        IEnumerable<Venda> BuscarVendasPorClienteId(int clienteId);
    }
}
