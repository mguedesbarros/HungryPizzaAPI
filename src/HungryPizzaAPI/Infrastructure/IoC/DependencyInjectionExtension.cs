using HungryPizzariaAPI.Application.Services;
using HungryPizzariaAPI.Application.Services.Interfaces;
using HungryPizzariaAPI.Domain.Interfaces.Repositories;
using HungryPizzariaAPI.Domain.Interfaces.Services;
using HungryPizzariaAPI.Domain.Services;
using HungryPizzariaAPI.Infrastructure.Data;
using HungryPizzariaAPI.Infrastructure.Data.Repositories;
using HungryPizzariaAPI.Infrastructure.Data.UnitOfWork;
using HungryPizzariaAPI.Infrastructure.Mapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HungryPizzariaAPI.Infrastructure.IoC
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services
                .AddSingleton<ITypeAdapterFactory, AutoMapperTypeAdapterFactory>()
                .AddSingleton<ITypeAdapter, AutoMapperTypeAdapter>()
                .AddDbContext<PizzariaContext>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddTransient<IClienteAppService, ClienteAppService>()
                .AddTransient<IClienteService, ClienteService>()
                .AddTransient<IClienteRepository, ClienteRepository>()
                .AddTransient<IPedidoAppService, PedidoAppService>()
                .AddTransient<IPedidoService, PedidoService>()
                .AddTransient<IPedidoRepository, PedidoRepository>()
                .AddTransient<IPizzaAppService, PizzaAppService>()
                .AddTransient<IPizzaService, PizzaService>()
                .AddTransient<IPizzaRepository, PizzaRepository>()
                .AddTransient<IItemPedidoAppService, ItemPedidoAppService>()
                .AddTransient<IItemPedidoService, ItemPedidoService>()
                .AddTransient<IItemPedidoRepository, ItemPedidoRepository>();


            var sp = services.BuildServiceProvider();
            TypeAdapterFactory.SetCurrent(sp.GetService<ITypeAdapterFactory>());

            return services;
        }
    }
}
