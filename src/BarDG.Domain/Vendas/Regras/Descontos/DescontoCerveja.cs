using BarDG.Domain.Produtos.Interfaces;
using BarDG.Domain.Vendas.Entities;
using System;
using System.Collections.Generic;

namespace BarDG.Domain.Vendas.Regras.Descontos
{
    internal class DescontoCerveja : IVendaDesconto
    {
        private readonly IProdutoRepository produtoRepository;

        public DescontoCerveja(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public bool Analisar(IEnumerable<VendaItem> itens)
        {
            //produtoRepository.li
            throw new NotImplementedException();
        }

        public void Aplicar(VendaItem vendaItem)
        {
            throw new NotImplementedException();
        }
    }
}
