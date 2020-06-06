using BarDG.Domain.Vendas.Dtos;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Descontos.Interfaces
{
    public interface IItemDesconto
    {
        bool Analisar(IEnumerable<ComandaItemDto> itens);
        void AplicarDesconto(IEnumerable<ComandaItemDto> item);
    }
}