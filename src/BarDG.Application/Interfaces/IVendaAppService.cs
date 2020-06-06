using BarDG.Application.Dtos;

namespace BarDG.Application.Interfaces
{
    public interface IVendaAppService : IAppService
    {
        int AdicionarItem(AdicionarVendaItemRequest vendaItemRequest);
        bool Finalizar(int vendaId);
        bool Resetar(int vendaId);
    }
}