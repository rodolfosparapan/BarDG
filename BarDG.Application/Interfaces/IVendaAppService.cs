using BarDG.Domain.Entities;

namespace BarDG.Application.Interfaces
{
    public interface IVendaAppService
    {
        int AdicionarItem(VendaItem vendaItem);
        bool Finalizar(int vendaId);
        bool Resetar(int vendaId);
    }
}