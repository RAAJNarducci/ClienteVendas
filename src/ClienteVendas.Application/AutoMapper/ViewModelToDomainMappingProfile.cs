using AutoMapper;
using ClienteVendas.Application.ViewModels;
using ClienteVendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteVendas.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<ProdutoViewModel, Produto>();
        }
    }
}
