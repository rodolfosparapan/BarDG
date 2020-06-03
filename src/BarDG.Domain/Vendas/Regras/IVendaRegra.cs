using BarDG.Domain.Vendas.Entities;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras
{
    internal interface IVendaRegra
    {
        void Aplicar(IEnumerable<VendaItem> vendaItens, VendaItem novoItem);
    }
}