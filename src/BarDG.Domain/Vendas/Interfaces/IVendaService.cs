using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Vendas.Dtos.Request;
using BarDG.Domain.Vendas.Dtos.Response;
using BarDG.Domain.Vendas.Entities;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Interfaces
{
    public interface IVendaService : IService
    {
        AdicionarVendaItemResponse AdicionarItem(AdicionarVendaItemRequest vendaItemRequest);
        bool Finalizar(int vendaId);
        bool Resetar(int vendaId);
        IEnumerable<ComandaItemResponse> Listar(int vendaId);
        Venda Obter(int vendaId);
    }
}