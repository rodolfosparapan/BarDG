using BarDG.Domain.Vendas.Entities;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Brindes
{
    public interface IVendaBrinde
    {
        bool Analisar(IEnumerable<VendaItem> itens, VendaItem vendaItem);
        VendaItem Obter();
    }
}