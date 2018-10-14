using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Application.ViewModels
{
    public abstract class ParametrosConsultaViewModel
    {
        public int TotalItens { get; set; }

        public int QuantidadePagina { get; set; }

        public int Pagina { get; set; }

        public string Ordenacao { get; set; }
    }
}
