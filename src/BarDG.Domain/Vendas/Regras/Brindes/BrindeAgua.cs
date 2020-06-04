﻿using BarDG.Domain.Produtos.Enums;
using BarDG.Domain.Produtos.Interfaces;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Regras.Brindes.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BarDG.Domain.Vendas.Regras.Brindes
{
    internal class BrindeAgua : IItemBrinde
    {
        private const string codigoProdutoBrinde = "001";
        private readonly IProdutoRepository produtoRepository;

        public BrindeAgua(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public bool Analisar(IEnumerable<ComandaItemDto> itens)
        {
            var conhaques = itens.Count(p => p.ProdutoTipo == ProdutoTipo.Conhaque);
            var cervejas = itens.Count(p => p.ProdutoTipo == ProdutoTipo.Cerveja);

            return conhaques == 3 && cervejas == 2;
        }

        public ComandaItemDto Obter()
        {
            var produtoBrinde = produtoRepository.ObterPorCodigo(codigoProdutoBrinde);

            return new ComandaItemDto
            {
                ProdutoId = produtoBrinde.Id,
                ProdutoDescricao = produtoBrinde.Descricao,
                ProdutoPreco = produtoBrinde.Preco,
                ProdutoTipo = produtoBrinde.Tipo
            };
        }
    }
}