using BarDG.Domain.Vendas.Dtos;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Descontos.Interfaces
{
    public interface IVendaDescontos
    {
        void Aplicar(IEnumerable<ComandaItemDto> itens);
    }
}