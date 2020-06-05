using BarDG.Domain.Common.Interfaces;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Dtos.Response;
using BarDG.Domain.Vendas.Entities;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Interfaces
{
    public interface IVendaItemRepository : IRepository<VendaItem>
    {
        IEnumerable<ComandaItemDto> ListarComandaItens(int vendaId);
        IEnumerable<ComandaItemResponse> ListarComandaItensResponse(int vendaId);
        void LimparItens(int vendaId);
        void Salvar(List<VendaItem> itensInserir, List<VendaItem> itensAtualizar);
    }
}