﻿using BarDG.Data.EFConfiguration;
using BarDG.Domain.Produtos.Entities;
using BarDG.Domain.Produtos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BarDG.Data.Repositories
{
    internal class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(BarDGContext context) : base(context)
        {
        }

        public Produto ObterPorCodigo(string codigo)
        {
            return DbSet.AsNoTracking().FirstOrDefault(p => p.Codigo == codigo);
        }
    }
}