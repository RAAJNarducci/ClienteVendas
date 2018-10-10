using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClienteVendas.Application.ViewModels
{
    public class ProdutoViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "Descrição deve ser informado")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Valor deve ser informado")]
        public decimal Valor { get; set; }
    }
}
