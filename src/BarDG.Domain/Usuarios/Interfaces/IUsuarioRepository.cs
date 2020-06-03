using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Usuarios.Entities;

namespace BarDG.Domain.Usuarios.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        bool Login(string email, string senha);
    }
}