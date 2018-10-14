using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ClienteVendas.Application.ViewModels
{
    public class GraficoVendaViewModel
    {
        public string Mes { get; set; }
        public decimal Total { get; set; }
        public string TotalFormatado
        {
            get { return Total > 0 ? string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Total) : "R$0,00"; }
            set { }
        }
        public bool Exibir
        {
            get { return Total > 0 ? true : false; }
            set { }
        }
    }
}
