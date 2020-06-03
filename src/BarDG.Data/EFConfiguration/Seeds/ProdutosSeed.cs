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
                new Produto { Descricao = "Cerveja", Preco = 5, ProdutoTipo = ProdutoTipo.Cerveja },
                new Produto { Descricao = "Conhaque", Preco = 20, ProdutoTipo = ProdutoTipo.Conhaque },
                new Produto { Descricao = "Suco", Preco = 50, ProdutoTipo = ProdutoTipo.Suco },
                new Produto { Descricao = "Água", Preco = 70, ProdutoTipo = ProdutoTipo.Agua }
            };
        }
    }
}