using BarDG.Data.Configuration.Seed;
using System.Linq;

namespace BarDG.Data.Configuration
{
    public static class DBInitializer
    {
        public static void Initialize(BarDGContext context)
        {
            context.Database.EnsureCreated();
            IniciarProdutos(context);
        }

        private static void IniciarProdutos(BarDGContext context)
        {
            if (context.Produtos.Any())
            {
                return;
            }

            foreach (var produto in ProdutosSeed.Obter())
            {
                context.Produtos.Add(produto);
            }

            context.SaveChanges();
        }
    }
}