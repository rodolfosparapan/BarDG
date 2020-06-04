using BarDG.Domain.Vendas.Dtos;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Brindes.Interfaces
{
    public interface IVendaBrindes
    {
        IEnumerable<ComandaItemDto> Listar(IEnumerable<ComandaItemDto> itens);
    }
}