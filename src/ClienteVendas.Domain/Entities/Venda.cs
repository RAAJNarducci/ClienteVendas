using ClienteVendas.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Domain.Entities
{
    public class Venda : EntityBase<Venda>
    {
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
        public DateTime DataVenda { get; set; }
        public int Quantidade { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Produto Produto { get; set; }

        public override bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
