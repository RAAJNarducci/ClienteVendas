using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace ClienteVendas.Application.ViewModels
{
    public class ProdutoViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "Descrição deve ser informado")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Valor deve ser informado")]
        public decimal Valor { get; set; }

        public string ValorFormatado
        {
            get { return Valor > 0 ? string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Valor) : "R$0,00"; }
            set { }
        }
    }
}
