using BarDG.Domain.Produtos.Entities;
using BarDG.Domain.Produtos.Enums;
using System.Linq;

namespace BarDG.Data.EFConfiguration.Seeds
{
    public static class ProdutosSeed
    {
        public static void Executar(BarDGContext context)
        {
            if (context.Produtos.Any())
            {
                return;
            }

            foreach (var produto in Listar())
            {
                context.Produtos.Add(produto);
            }

            context.SaveChanges();
        }

        private static Produto[] Listar()
        {
            return new Produto[]
            {
                new Produto { Descricao = "Cerveja", Codigo = "001", Preco = 5, Tipo = ProdutoTipo.Cerveja },
                new Produto { Descricao = "Conhaque", Codigo = "002", Preco = 20, Tipo = ProdutoTipo.Conhaque },
                new Produto { Descricao = "Suco", Codigo = "003", Preco = 50, Tipo = ProdutoTipo.Suco },
                new Produto { Descricao = "Água", Codigo = "004", Preco = 70, Tipo = ProdutoTipo.Agua }
            };
        }
    }
}