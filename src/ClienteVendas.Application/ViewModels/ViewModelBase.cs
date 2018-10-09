using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClienteVendas.Application.ViewModels
{
    public class ViewModelBase
    {
        [Key]
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        public FluentValidation.Results.ValidationResult ValidationResult { get; set; }
    }
}
