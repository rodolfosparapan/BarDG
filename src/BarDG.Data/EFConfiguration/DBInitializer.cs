using BarDG.Data.EFConfiguration.Seeds;

namespace BarDG.Data.EFConfiguration
{
    public static class DBInitializer
    {
        public static void Initialize(BarDGContext context)
        {
            context.Database.EnsureCreated();

            ProdutosSeed.Executar(context);
            UsuariosSeed.Executar(context);
        }
    }
}