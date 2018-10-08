using ClienteVendas.Domain.Core;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Domain.Entities
{
    public class Endereco : EntityBase<Endereco>
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public virtual Cliente Cliente { get; set; }

        public override bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
