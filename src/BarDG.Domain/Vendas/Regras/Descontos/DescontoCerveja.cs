using BarDG.Domain.Produtos.Enums;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Enums;
using BarDG.Domain.Vendas.Regras.Descontos.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BarDG.Domain.Vendas.Regras.Descontos
{
    internal class DescontoCerveja : IItemDesconto
    {
        public bool Analisar(IEnumerable<ComandaItemDto> itens)
        {
            var totalCervejas = itens.Where(i => i.ProdutoTipo == ProdutoTipo.Cerveja).Sum(i => i.Quantidade);
            var totalSucos = itens.Where(i => i.ProdutoTipo == ProdutoTipo.Suco).Sum(i => i.Quantidade);

            return totalCervejas >= 1 && totalSucos >= 1;
        }

        public void AplicarDesconto(IEnumerable<ComandaItemDto> itens)
        {
            var cerveja = itens.FirstOrDefault(i => i.ProdutoTipo == ProdutoTipo.Cerveja);
            if(cerveja != null)
            {
                cerveja.ProdutoDesconto = 2;
                cerveja.State = Tracking.Modified;
            }
        }
    }
}