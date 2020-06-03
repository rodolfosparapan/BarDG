using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Vendas.Dtos.Request;
using BarDG.Domain.Vendas.Dtos.Response;

namespace BarDG.Domain.Vendas.Interfaces
{
    public interface IVendaService : IService
    {
        AdicionarVendaItemResponse AdicionarItem(AdicionarVendaItemRequest vendaItemRequest);
        bool Finalizar(int vendaId);
        bool Resetar(int vendaId);
    }
}