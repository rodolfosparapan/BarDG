using BarDG.Domain.Produtos.Enums;
using BarDG.Domain.Produtos.Interfaces;
using BarDG.Domain.Vendas.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BarDG.Domain.Vendas.Regras.Brindes
{
    internal class BrindeAgua : IVendaBrinde
    {
        private const string codigoProdutoBrinde = "001";
        private readonly IProdutoRepository produtoRepository;

        public BrindeAgua(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public bool Analisar(IEnumerable<VendaItem> itens, VendaItem vendaItem)
        {
            itens.ToList().Add(vendaItem);
            var vendaProdutoIds = itens.Select(i => i.ProdutoId);
 
            var conhaquesECervejas = produtoRepository.ListarConhaqueECervejas();
            var conhaques = conhaquesECervejas.Count(p => p.ProdutoTipo == ProdutoTipo.Conhaque && vendaProdutoIds.Contains(p.Id));
            var cervejas = conhaquesECervejas.Count(p => p.ProdutoTipo == ProdutoTipo.Cerveja && vendaProdutoIds.Contains(p.Id));

            return conhaques == 3 && cervejas == 2;
        }

        public VendaItem Obter()
        {
            var produtoBrinde = produtoRepository.ObterPorCodigo(codigoProdutoBrinde);
            
            return new VendaItem(vendaId: 0, produtoBrinde.Id, produtoBrinde.Descricao, produtoBrinde.Preco, desconto: 0);
        }
    }
}