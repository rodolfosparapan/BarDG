using BarDG.Domain.Produtos.Enums;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Regras.Descontos;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BarDG.Test.Domain.Vendas.Regras
{
    public class VendaDescontosTests
    {
        private VendaDescontos vendaDescontos;

        public VendaDescontosTests()
        {
            vendaDescontos = new VendaDescontos();
        }

        [Fact]
        public void Deve_Inserir_Desconto_Cerveja_Caso_Comanda_Tenha_1Cerjeva_E_1Suco()
        {
            var itens = new List<ComandaItemDto>()
            {
                new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja, ProdutoPreco = 10 },
                new ComandaItemDto { ProdutoTipo = ProdutoTipo.Suco, ProdutoPreco = 10 },
            };

            vendaDescontos.Aplicar(itens);

            Assert.Equal(3, itens.First(i => i.ProdutoTipo == ProdutoTipo.Cerveja).ProdutoPreco);
        }

        [Theory]
        [MemberData(nameof(ComandaItensData))]
        public void Nao_Deve_Inserir_Desconto_Caso_Comanda_Tenha_Combinacoes_Que_Nao_Disponibilizam_Desconto(IEnumerable<ComandaItemDto> itens)
        {
            vendaDescontos.Aplicar(itens);

            Assert.DoesNotContain(3, itens.Select(i => i.ProdutoPreco));
        }

        public static IEnumerable<object[]> ComandaItensData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<ComandaItemDto>
                    {
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque, ProdutoPreco = 10 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja, ProdutoPreco = 10 },
                    }
                },
                new object[]
                {
                    new List<ComandaItemDto>
                    {
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque, ProdutoPreco = 10 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja, ProdutoPreco = 10 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Agua, ProdutoPreco = 10 },
                    }
                },
                new object[]
                {
                    new List<ComandaItemDto>
                    {
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque, ProdutoPreco = 10 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja, ProdutoPreco = 10 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Agua, ProdutoPreco = 10 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Suco, ProdutoPreco = 10 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Suco, ProdutoPreco = 10 },
                    }
                },
                new object[]
                {
                    new List<ComandaItemDto>
                    {
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque, ProdutoPreco = 10 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque, ProdutoPreco = 10 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja, ProdutoPreco = 10 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja, ProdutoPreco = 10 },
                    }
                },
            };
    }
}
