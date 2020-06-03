using BarDG.Domain.Produtos.Interfaces;
using BarDG.Domain.Vendas.Regras.Brindes;
using BarDG.Domain.Vendas.Regras.Brindes.Interfaces;
using BarDG.Domain.Vendas.Regras.Descontos;
using BarDG.Domain.Vendas.Regras.Descontos.Interfaces;
using BarDG.Domain.Vendas.Regras.Limites.Interfaces;
using BBarDG.Domain.Vendas.Regras.Limites;

namespace BarDG.Domain.Vendas.Regras
{
    internal class VendaRegras : IVendaRegras
    {
        public IVendaBrindes Brindes { get; }
        public IVendaDescontos Descontos { get; }
        public IVendaLimites Limites { get; }
        
        public VendaRegras(IProdutoRepository produtoRepository)
        {
            Brindes = new VendaBrindes(produtoRepository);
            Descontos = new VendaDescontos();
            Limites = new VendaLimites();
        }
    }
}