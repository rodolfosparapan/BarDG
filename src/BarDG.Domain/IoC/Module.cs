using System;
using System.Collections.Generic;

namespace BarDG.Domain.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var result = new Dictionary<Type, Type>
            {
                //{ typeof(IVendasService), typeof(VendasService) },
            };

            return result;
        }
    }
}