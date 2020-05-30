﻿using BarDG.Domain.Produtos.Entity;

namespace BarDG.Data.Config.Seed
{
    public static class ProdutosSeed
    {
        public static Produto[] Obter()
        {
            return new Produto[]
            {
                new Produto { Descricao = "Cerveja", Preco = 5 },
                new Produto { Descricao = "Conhaque", Preco = 20 },
                new Produto { Descricao = "Suco", Preco = 50 },
                new Produto { Descricao = "Água", Preco = 70 }
            };
        }
    }
}