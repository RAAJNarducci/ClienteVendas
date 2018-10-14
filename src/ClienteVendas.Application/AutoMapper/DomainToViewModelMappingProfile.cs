using AutoMapper;
using ClienteVendas.Application.ViewModels;
using ClienteVendas.Data.CrossCutting.Helpers;
using ClienteVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<Venda, VendaViewModel>();
        }
    }
}
