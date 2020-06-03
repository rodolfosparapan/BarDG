using BarDG.Domain.Produtos.Interfaces;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Entities;
using BarDG.Domain.Vendas.Regras.Brindes.Interfaces;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Brindes
{
    public class VendaBrindes : IVendaBrindes
    {
        private List<IItemBrinde> brindes;

        public VendaBrindes(IProdutoRepository produtoRepository)
        {
            brindes = new List<IItemBrinde>
            {
                new BrindeAgua(produtoRepository)
            };
        }

        public IEnumerable<VendaItem> Listar(IEnumerable<ComandaItemDto> itens)
        {    
            var produtoBrindes = new List<VendaItem>();
            
            foreach(var brinde in brindes)
            {
                if(brinde.Analisar(itens))
                {
                    produtoBrindes.Add(brinde.Obter());
                }
            }

            return produtoBrindes;
        }
    }
}