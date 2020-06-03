using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Vendas.Dtos;

namespace BarDG.Domain.Vendas.Interfaces
{
    public interface IVendaService : IService
    {
        int AdicionarItem(VendaItemRequest vendaItemRequest);
        bool Finalizar(int vendaId);
        bool Resetar(int vendaId);
    }
}