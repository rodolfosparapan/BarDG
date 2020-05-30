using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace BarDG.CrossCutting
{
    public static class DependencyInjection
    {
        public static void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            RegisterDataProject(serviceCollection);
            RegisterDomainProject(serviceCollection);
        }

        private static void RegisterDataProject(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterTypes(Data.IoC.Module.GetTypes());
        }

        private static void RegisterDomainProject(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterTypes(Domain.IoC.Module.GetTypes());
        }

        private static void RegisterTypes(this IServiceCollection serviceCollection, Dictionary<Type, Type> types)
        {
            foreach (var item in types)
            {
                serviceCollection.AddTransient(item.Key, item.Value);
            }
        }
    }
}