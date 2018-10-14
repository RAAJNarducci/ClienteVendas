using ClienteVendas.Domain.Core;
using ClienteVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Domain.Interfaces
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        IEnumerable<Cliente> BuscarClientes(string nome, string cpf, int pagina, int quantidadePagina, out int total);
    }
}
