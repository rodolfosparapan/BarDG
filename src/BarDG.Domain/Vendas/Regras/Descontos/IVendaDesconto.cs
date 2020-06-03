using BarDG.Domain.Vendas.Entities;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Descontos
{
    public interface IVendaDesconto
    {
        bool Analisar(IEnumerable<VendaItem> itens);

        void Aplicar(VendaItem vendaItem);
    }
}