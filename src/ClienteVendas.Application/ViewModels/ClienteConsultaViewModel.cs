using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Application.ViewModels
{
    public class ClienteConsultaViewModel : ParametrosConsultaViewModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
