﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace ClienteVendas.Application.ViewModels
{
    public class EnderecoViewModel : ViewModelBase
    {
        [Required(ErrorMessage = "O logradouro deve ser informado")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do logradouro é 2 caracteres")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do logradouro é 150 caracteres")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O numero deve ser informado")]
        [MinLength(1, ErrorMessage = "O tamanho minimo do numero é 1 caracteres")]
        [MaxLength(10, ErrorMessage = "O tamanho máximo do numero é 10 caracteres")]
        public string Numero { get; set; }

        [MaxLength(100, ErrorMessage = "O tamanho máximo do complemento é 100 caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O bairro deve ser informado")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do bairro é 2 caracteres")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do bairro é 50 caracteres")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O CEP deve ser informado")]
        [MaxLength(9, ErrorMessage = "O tamanho máximo do CEP é 9 caracteres")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "A cidade deve ser informado")]
        [MinLength(2, ErrorMessage = "O tamanho minimo da cidade é 2 caracteres")]
        [MaxLength(100, ErrorMessage = "O tamanho máximo da cidade é 100 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O estado deve ser informado")]
        public string Estado { get; set; }

        [ScaffoldColumn(false)]
        public string CEPSemMascara
        {
            get { return CEP != null ? Regex.Replace(CEP, "[^0-9a-zA-Z]+", "") : null; }
            set { }
        }

        public override string ToString()
        {
            return $"{Logradouro} , {Numero} - {Complemento} - {Bairro}, {Cidade}/{Estado}";
        }

        public SelectList Estados()
        {
            return new SelectList(EstadoViewModel.ListarEstados(), "UF", "Nome");
        }
    }
}
