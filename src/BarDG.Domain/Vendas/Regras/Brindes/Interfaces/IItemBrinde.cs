using BarDG.Domain.Vendas.Dtos;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Brindes.Interfaces
{
    public interface IItemBrinde
    {
        bool Analisar(IEnumerable<ComandaItemDto> itens);
        void Adicionar(IList<ComandaItemDto> itens);
    }
}