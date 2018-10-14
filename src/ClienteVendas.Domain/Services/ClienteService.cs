using ClienteVendas.Domain.Core;
using ClienteVendas.Domain.Entities;
using ClienteVendas.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente, IClienteRepository>, IClienteService
    {
        public ClienteService(IClienteRepository repository) : base(repository)
        {
        }

        public IEnumerable<Cliente> BuscarClientes(string nome, string cpf, int pagina, int quantidadePagina, out int total)
        {
            return _repository.BuscarClientes(nome, cpf, pagina, quantidadePagina, out total);
        }
    }
}
