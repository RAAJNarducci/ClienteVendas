using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Application.ViewModels
{
    public class ClienteResponseViewModel : ParametrosConsultaViewModel
    {
        public List<ClienteViewModel> Clientes { get; set; }
    }
}
