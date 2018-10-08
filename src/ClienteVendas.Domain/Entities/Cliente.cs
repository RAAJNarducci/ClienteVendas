using ClienteVendas.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Domain.Entities
{
    public class Cliente : EntityBase<Cliente>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Celular { get; set; }
        public int EnderecoId { get; set; }

        public virtual Endereco Endereco { get; set; }

        public override bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
