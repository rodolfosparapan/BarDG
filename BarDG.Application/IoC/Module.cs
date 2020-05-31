using BarDG.Application.Interfaces;
using BarDG.Application.Services;
using System;
using System.Collections.Generic;

namespace BarDG.Application.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var result = new Dictionary<Type, Type>
            {
                { typeof(IVendaAppService), typeof(VendaAppService) },
            };

            return result;
        }
    }
}