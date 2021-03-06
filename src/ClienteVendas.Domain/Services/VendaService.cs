﻿using ClienteVendas.Domain.Core;
using ClienteVendas.Domain.Entities;
using ClienteVendas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Domain.Services
{
    public class VendaService : ServiceBase<Venda, IVendaRepository>, IVendaService
    {
        public VendaService(IVendaRepository repository) : base(repository)
        {
        }

        public IEnumerable<Venda> BuscarVendasPorClienteId(int clienteId)
        {
            return _repository.BuscarVendasPorClienteId(clienteId);
        }

        public IEnumerable<Venda> BuscarVendas(DateTime? dataInicio, DateTime? dataFim)
        {
            return _repository.BuscarVendas(dataInicio, dataFim);
        }
    }
}
