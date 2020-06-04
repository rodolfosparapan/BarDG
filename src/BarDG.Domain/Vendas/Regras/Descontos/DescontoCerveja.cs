using BarDG.Domain.Produtos.Enums;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Regras.Descontos.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BarDG.Domain.Vendas.Regras.Descontos
{
    internal class DescontoCerveja : IItemDesconto
    {
        public bool Analisar(IEnumerable<ComandaItemDto> itens)
        {
            var totalCervejas = itens.Count(i => i.ProdutoTipo == ProdutoTipo.Cerveja);
            var totalSucos = itens.Count(i => i.ProdutoTipo == ProdutoTipo.Suco);

            return totalCervejas == 1 && totalSucos == 1;
        }

        public void AplicarDesconto(IEnumerable<ComandaItemDto> itens)
        {
            var cerveja = itens.FirstOrDefault(i => i.ProdutoTipo == ProdutoTipo.Cerveja);
            if(cerveja != null)
            {
                cerveja.ProdutoPreco = 3;
            }
        }
    }
}