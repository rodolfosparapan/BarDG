﻿using BarDG.Domain.Vendas;
using BarDG.Domain.Vendas.Interfaces;
using System;
using System.Collections.Generic;

namespace BarDG.Domain.Common.IoC
{
    public static class Module
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var result = new Dictionary<Type, Type>
            {
                { typeof(IVendaService), typeof(VendaService) },
            };

            return result;
        }
    }
}