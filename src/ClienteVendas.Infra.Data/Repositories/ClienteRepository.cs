using ClienteVendas.Domain.Core;
using ClienteVendas.Domain.Entities;
using ClienteVendas.Domain.Interfaces;
using ClienteVendas.Infra.Data.Context;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace ClienteVendas.Infra.Data.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(MainContext mainContext) : base(mainContext)
        {
        }

        public override Cliente FindById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(
                   GetConnectionString()))
            {
                StringBuilder sbQuerySelect = new StringBuilder();
                StringBuilder sbQueryWhere = new StringBuilder();
                sbQuerySelect.Append(
                    "SELECT * " +
                    "FROM dbo.Cliente C " +
                    "INNER JOIN dbo.Endereco E ON C.EnderecoId = E.Id ");
                #region WHERE
                var condicaoWhere = "WHERE ";
                sbQueryWhere.Append($"{condicaoWhere} C.Id = {id} ");
                #endregion

                var query = string.Concat(sbQuerySelect.ToString(), sbQueryWhere.ToString());

                return conexao.Query<Cliente, Endereco, Cliente>(query, (p, e) =>
                {
                    p.Endereco = e;
                    return p;
                }, splitOn: "EnderecoId").FirstOrDefault();
            }
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
