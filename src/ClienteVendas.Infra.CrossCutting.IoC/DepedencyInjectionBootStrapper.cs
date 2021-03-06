﻿using AutoMapper;
using ClienteVendas.Application.Interfaces;
using ClienteVendas.Application.Services;
using ClienteVendas.Domain.Core;
using ClienteVendas.Domain.Interfaces;
using ClienteVendas.Domain.Services;
using ClienteVendas.Infra.Data;
using ClienteVendas.Infra.Data.Context;
using ClienteVendas.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ClienteVendas.Infra.CrossCutting.IoC
{
    public class DepedencyInjectionBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IVendaAppService, VendaAppService>();

            //Domain
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IVendaService, VendaService>();

            //Infra.Data
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MainContext>();
        }
    }
}
