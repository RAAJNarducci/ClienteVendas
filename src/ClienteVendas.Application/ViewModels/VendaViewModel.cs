using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Application.ViewModels
{
    public class VendaViewModel : ViewModelBase
    {
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
        public DateTime DataVenda { get; set; }
        public string DataVendaFormatada
        {
            get { return DataVenda.ToShortDateString(); }
            set { }
        }
        public int Quantidade { get; set; }

        public virtual ProdutoViewModel Produto { get; set; }
    }
}
