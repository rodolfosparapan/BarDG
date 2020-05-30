using System;
using System.Collections.Generic;

namespace BarDG.Data.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var result = new Dictionary<Type, Type>
            {
                //{ typeof(IVendasRepository), typeof(VendasRepository) },
            };

            return result;
        }
    }
}