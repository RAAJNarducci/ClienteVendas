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

        public IEnumerable<Cliente> BuscarClientes(string nome, string cpf, int pagina, int quantidadePagina, out int total)
        {
            using (SqlConnection conexao = new SqlConnection(
                GetConnectionString()))
            {
                StringBuilder sbQuerySelect = new StringBuilder();
                StringBuilder sbQueryWhere = new StringBuilder();
                StringBuilder sbQueryPaginate = new StringBuilder();
                sbQuerySelect.Append(
                    "SELECT * " +
                    "FROM dbo.Cliente C " +
                    "INNER JOIN dbo.Endereco E ON C.EnderecoId = E.Id ");

                #region WHERE
                var condicaoWhere = "WHERE ";
                if (nome != null)
                {
                    sbQueryWhere.Append($"{condicaoWhere} C.Nome LIKE '%{nome}%' collate Latin1_General_CI_AI ");
                    condicaoWhere = "AND ";
                }
                if (cpf != null)
                {
                    sbQueryWhere.Append($"{condicaoWhere} C.Cpf = {cpf} ");
                    condicaoWhere = "AND ";
                }
                #endregion

                #region PAGINATE
                sbQueryPaginate.Append("ORDER BY C.Nome ");
                sbQueryPaginate.Append($"OFFSET {(pagina - 1) * quantidadePagina} ROWS ");
                sbQueryPaginate.Append($"FETCH NEXT {quantidadePagina} ROWS ONLY ");
                #endregion

                var query = string.Concat(sbQuerySelect.ToString(), sbQueryWhere.ToString(), sbQueryPaginate.ToString());

                var pessoasJoin = conexao.Query<Cliente, Endereco, Cliente>(query, (c, e) =>
                {
                    c.Endereco = e;
                    return c;
                }, splitOn: "EnderecoId");

                var queryCount = string.Concat("SELECT COUNT(C.Id) FROM dbo.Cliente C INNER JOIN dbo.Endereco E ON C.EnderecoId = E.Id ", sbQueryWhere.ToString());

                total = conexao.Query<int>(queryCount).SingleOrDefault();
                return pessoasJoin;
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
