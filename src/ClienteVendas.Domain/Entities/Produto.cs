using ClienteVendas.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Domain.Entities
{
    public class Produto : EntityBase<Produto>
    {
        public Produto()
        {
            Vendas = new HashSet<Venda>();
        }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal Valor { get; set; }

        public virtual ICollection<Venda> Vendas { get; set; }

        public override bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
