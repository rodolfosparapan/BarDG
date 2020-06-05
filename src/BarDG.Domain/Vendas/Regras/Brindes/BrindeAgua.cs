using BarDG.Domain.Produtos.Enums;
using BarDG.Domain.Produtos.Interfaces;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Regras.Brindes.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BarDG.Domain.Vendas.Regras.Brindes
{
    internal class BrindeAgua : IItemBrinde
    {
        private const string codigoProdutoBrinde = "004";
        private readonly IProdutoRepository produtoRepository;

        public BrindeAgua(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public bool Analisar(IEnumerable<ComandaItemDto> itens)
        {
            var conhaques = itens.Where(i => i.ProdutoTipo == ProdutoTipo.Conhaque).Sum(i => i.Quantidade);
            var cervejas = itens.Where(i => i.ProdutoTipo == ProdutoTipo.Cerveja).Sum(i => i.Quantidade);

            return conhaques == 3 && cervejas == 2;
        }

        public ComandaItemDto Obter()
        {
            var produtoBrinde = produtoRepository.ObterPorCodigo(codigoProdutoBrinde);

            return new ComandaItemDto
            {
                ProdutoId = produtoBrinde.Id,
                Quantidade = 1,
                ProdutoDescricao = produtoBrinde.Descricao,
                ProdutoPreco = produtoBrinde.Preco,
                ProdutoTipo = produtoBrinde.Tipo
            };
        }
    }
}