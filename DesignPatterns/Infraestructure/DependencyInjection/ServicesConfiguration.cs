using System;
using DesignPatterns.Factories;
using DesignPatterns.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Infraestructure.DependencyInjection
{
    public class ServicesConfiguration
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // 1) Registra el tipo concreto MyVehiclesRepository
            services.AddTransient<MyVehiclesRepository>();

            // 2) Registra IVehicleRepository envolviendo ese concreto con el Decorator
            services.AddTransient<IVehicleRepository>(sp =>
                new DefaultPropertiesVehicleRepository(
                    sp.GetRequiredService<MyVehiclesRepository>()
                )
            );

            // Resto de tus servicios…
            services.AddTransient<CarFactory, FordMustangFactory>();
            services.AddTransient<CarFactory, FordExplorerFactory>();
            services.AddTransient<CarFactory, FordEscapeFactory>();
            services.AddSingleton<CarFactoryProvider>();
        }
    }
}

