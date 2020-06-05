using BarDG.Domain.Produtos.Entities;
using BarDG.Domain.Produtos.Enums;
using BarDG.Domain.Produtos.Interfaces;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Regras.Brindes;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BarDG.Test.Domain.Vendas.Regras
{
    public class VendaBrindesTests
    {
        private const string codigoProdutoBrinde = "004";
        private IProdutoRepository produtoRepository;
        private VendaBrindes vendaBrindes;

        public VendaBrindesTests()
        {
            produtoRepository = Substitute.For<IProdutoRepository>();
            vendaBrindes = new VendaBrindes(produtoRepository);
        }

        [Fact]
        public void Deve_Inserir_Brinde_Agua_Caso_Comanda_Tenha_3Conhaques_E_2Cervejas()
        {
            produtoRepository.ObterPorCodigo(codigoProdutoBrinde).Returns(new Produto { 
                Tipo = ProdutoTipo.Agua
            });

            var itens = new List<ComandaItemDto>()
            {
                new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque, Quantidade = 3 },
                new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja, Quantidade = 2 },
            };

            var brindes = vendaBrindes.Listar(itens);
            Assert.Contains(ProdutoTipo.Agua, brindes.Select(b => b.ProdutoTipo));
        }

        [Theory]
        [MemberData(nameof(ComandaItensData))]
        public void Nao_Deve_Inserir_Brinde_Caso_Comanda_Tenha_Itens_Que_Nao_Disponibilizam_Brindes(IEnumerable<ComandaItemDto> itens)
        {
            var brindes = vendaBrindes.Listar(itens);
            Assert.False(brindes.Any());
        }

        public static IEnumerable<object[]> ComandaItensData =>
            new List<object[]>
            {
                new object[]
                {
                    new List<ComandaItemDto>
                    {
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque, Quantidade = 1 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja, Quantidade = 1 },
                    }
                },
                new object[]
                {
                    new List<ComandaItemDto>
                    {
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque, Quantidade = 1 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja, Quantidade = 1 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Agua, Quantidade = 1 },
                    }
                },
                new object[]
                {
                    new List<ComandaItemDto>
                    {
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque, Quantidade = 1 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja, Quantidade = 1 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Agua, Quantidade = 1 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Suco, Quantidade = 1 },
                    }
                },
                new object[]
                {
                    new List<ComandaItemDto>
                    {
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Conhaque, Quantidade = 2 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja, Quantidade = 2 },
                        new ComandaItemDto { ProdutoTipo = ProdutoTipo.Cerveja },
                    }
                },
            };
        
    }
}