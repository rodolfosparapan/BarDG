using BarDG.Domain.Vendas.Entities;
using BarDG.Domain.Vendas.Regras;
using System;
using System.Collections.Generic;

namespace BBarDG.Domain.Vendas.Regras.Limites
{
    internal class VendaLimites : IVendaRegra
    {
        public void Aplicar(IEnumerable<VendaItem> vendaItens, VendaItem novoItem)
        {
            throw new NotImplementedException();
        }
    }
}