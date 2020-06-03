using BarDG.Data.EFConfiguration;
using BarDG.Domain.Usuarios.Entities;
using BarDG.Domain.Usuarios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BarDG.Data.Repositories
{
    internal class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BarDGContext context) : base(context)
        {
        }

        public bool Login(string email, string senha)
        {
            return DbSet.AsNoTracking().Any(u => u.Email == email && u.Senha == senha);
        }
    }
}