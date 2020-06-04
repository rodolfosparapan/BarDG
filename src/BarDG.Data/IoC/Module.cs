using BarDG.Data.Repositories;
using BarDG.Data.UoW;
using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Produtos.Interfaces;
using BarDG.Domain.Usuarios.Interfaces;
using BarDG.Domain.Vendas.Interfaces;
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
                { typeof(IUnitOfWork), typeof(UnitOfWork) },
                { typeof(IVendaRepository), typeof(VendaRepository) },
                { typeof(IVendaItemRepository), typeof(VendaItemRepository) },
                { typeof(IUsuarioRepository), typeof(UsuarioRepository) },
                { typeof(IProdutoRepository), typeof(ProdutoRepository) },
            };

            return result;
        }
    }
}