using ClienteVendas.Domain.Entities;
using ClienteVendas.Domain.Interfaces;
using ClienteVendas.Infra.Data.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace ClienteVendas.Infra.Data.Repositories
{
    public class VendaRepository : RepositoryBase<Venda>, IVendaRepository
    {
        public VendaRepository(MainContext mainContext) : base(mainContext)
        {
        }

        public IEnumerable<Venda> BuscarVendasPorClienteId(int clienteId)
        {
            var vendas = Db.Vendas
                .Include(vend => vend.Produto)
                .Where(vend => vend.ClienteId == clienteId)
                .ToList();
            return vendas;
        }

        public IEnumerable<Venda> BuscarVendas(DateTime? dataInicio, DateTime? dataFim)
        {
            var vendas = Db.Vendas
                .Include(vend => vend.Produto)
                .Where(vend => vend.DataVenda.Date >= dataInicio.Value.Date && vend.DataVenda <= dataFim.Value.Date)
                .ToList();
            return vendas;
        }

        public string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return config.GetConnectionString("DefaultConnection");
        }
    }
}
