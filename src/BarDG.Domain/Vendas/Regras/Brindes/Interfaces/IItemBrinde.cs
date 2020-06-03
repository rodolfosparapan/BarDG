using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Entities;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Brindes.Interfaces
{
    public interface IItemBrinde
    {
        bool Analisar(IEnumerable<ComandaItemDto> itens);
        VendaItem Obter();
    }
}