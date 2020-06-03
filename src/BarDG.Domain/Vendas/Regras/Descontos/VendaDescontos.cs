using BarDG.Domain.Vendas.Entities;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Descontos
{
    internal class VendaDescontos : IVendaRegra
    {
        public void Aplicar(IEnumerable<VendaItem> vendaItens, VendaItem novoItem)
        {
            
        }
    }
}
