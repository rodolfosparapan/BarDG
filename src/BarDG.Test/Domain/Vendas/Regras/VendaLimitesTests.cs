﻿using BarDG.Domain.Produtos.Enums;
using BarDG.Domain.Vendas.Dtos;
using BBarDG.Domain.Vendas.Regras.Limites;
using System.Collections.Generic;
using Xunit;

namespace BarDG.Test.Domain.Vendas.Regras
{
    public class VendaLimitesTests
    {
        private VendaLimites vendaLimites;

        public VendaLimitesTests()
        {
            vendaLimites = new VendaLimites();
        }

        [Fact]
        public void Deve_Retornar_Mensagem_De_Limite_Caso_Comanda_Tenha_Mais_De_3_Sucos()
        {
            var itens = new List<ComandaItemDto>()
            {
                new ComandaItemDto { ProdutoTipo = ProdutoTipo.Suco },
                new ComandaItemDto { ProdutoTipo = ProdutoTipo.Suco },
                new ComandaItemDto { ProdutoTipo = ProdutoTipo.Suco },
                new ComandaItemDto { ProdutoTipo = ProdutoTipo.Suco }
            };

            vendaLimites.Analisar(itens);

            Assert.NotEmpty(vendaLimites.ListarMensagens());
        }

        [Theory]
        [MemberData(nameof(ComandaItensData))]
        public void Nao_Deve_Retornar_Mesagem_De_Limite_Caso_Comanda_Nao_Tenha_Combinacoes_De_Limite_De_Itens(IEnumerable<ComandaItemDto> itens)
        {
            vendaLimites.Analisar(itens);

            Assert.Empty(vendaLimites.ListarMensagens());
        }

        public static IEnumerable<object[]> ComandaItensData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<ComandaItemDto>
                    {
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja },
                    }
                },
                new object[]
                {
                    new List<ComandaItemDto>
                    {
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Agua },
                    }
                },
                new object[]
                {
                    new List<ComandaItemDto>
                    {
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Agua },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Suco },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Suco },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Suco }
                    }
                },
                new object[]
                {
                    new List<ComandaItemDto>
                    {
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja },
                    }
                },
            };
    }
}