using BarDG.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace BarDG.CrossCutting
{
    public static class DependencyInjection
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            RegisterDatabase(services, configuration);

            RegisterDataServices(services);
            RegisterDomainServices(services);
            RegisterApplicationServices(services);
        }

        private static void RegisterDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BarDGContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        private static void RegisterApplicationServices(IServiceCollection services)
        {
            services.RegisterTypes(Application.IoC.Module.GetTypes());
        }

        private static void RegisterDataServices(IServiceCollection services)
        {
            services.RegisterTypes(Data.IoC.Module.GetTypes());
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.RegisterTypes(Domain.IoC.Module.GetTypes());
        }

        private static void RegisterTypes(this IServiceCollection services, Dictionary<Type, Type> types)
        {
            foreach (var item in types)
            {
                services.AddTransient(item.Key, item.Value);
            }
        }
    }
}