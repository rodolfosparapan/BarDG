namespace BarDG.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        bool Login(string email, string senha);
    }
}