using BarDG.Domain.Entities;

namespace BarDG.Application.Interfaces
{
    public interface IVendaAppService : IAppService
    {
        int AdicionarItem(VendaItem vendaItem);
        bool Finalizar(int vendaId);
        bool Resetar(int vendaId);
    }
}