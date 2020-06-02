using BarDG.Data.EFConfiguration;
using BarDG.Domain.Entities;
using BarDG.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BarDG.Data.Repositories
{
    internal class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
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