using BarDG.Domain.Vendas.Entities;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras
{
    internal static class VendaRegras
    {
        public static void Aplicar(IEnumerable<VendaItem> vendaItens, VendaItem novoItem)
        {
            var vendaRegras = new List<IVendaRegra>()
            {
                //new VendaItemBrinde(),
                //new VendaItemDesconto(),
                //new VendaItemLimite(),
            };

            foreach(var vendaRegra in vendaRegras)
            {
                vendaRegra.Aplicar(vendaItens, novoItem);
            }
        }
    }
}