using BarDG.Domain.Usuarios.Entities;
using System.Linq;

namespace BarDG.Data.EFConfiguration.Seeds
{
    public static class UsuariosSeed
    {
        public static void Executar(BarDGContext context)
        {
            if (context.Usuarios.Any())
            {
                return;
            }

            foreach (var usuario in Listar())
            {
                context.Usuarios.Add(usuario);
            }

            context.SaveChanges();
        }

        public static Usuario[] Listar()
        {
            return new Usuario[]
            {
                new Usuario { Nome = "Administrador", Email = "adm@bardg.com", Senha= "123456" },
                new Usuario { Nome = "Caixa", Email = "caixa@bardg.com", Senha= "123456" },
            };
        }
    }
}