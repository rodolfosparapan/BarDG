using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Regras.Descontos.Interfaces;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Descontos
{
    internal class VendaDescontos : IVendaDescontos
    {
        private List<IItemDesconto> descontos;

        public VendaDescontos()
        {
            descontos = new List<IItemDesconto>
            {
                new DescontoCerveja()
            };
        }

        public void Aplicar(IEnumerable<ComandaItemDto> itens)
        {
            foreach (var desconto in descontos)
            {
                if (desconto.Analisar(itens))
                {
                    desconto.AplicarDesconto(itens);
                }
            }
        }
    }
}