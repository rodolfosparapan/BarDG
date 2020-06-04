using BarDG.Domain.Produtos.Enums;
using BarDG.Domain.Vendas.Dtos.Request;

namespace BarDG.Domain.Vendas.Dtos
{
    public class ComandaItemDto
    {
        public int ProdutoId { get; set; }
        public string ProdutoDescricao { get; set; }
        public ProdutoTipo ProdutoTipo { get; set; }
        public decimal ProdutoPreco { get; set; }
        public decimal ProdutoDesconto { get; set; }

        public static ComandaItemDto Novo(AdicionarVendaItemRequest adicionarVendaItemRequest)
        {
            return new ComandaItemDto
            {
                ProdutoDesconto = adicionarVendaItemRequest.Desconto,
                ProdutoDescricao = adicionarVendaItemRequest.ProdutoDescricao,
                ProdutoId = adicionarVendaItemRequest.ProdutoId,
                ProdutoPreco = adicionarVendaItemRequest.Preco,
                ProdutoTipo = adicionarVendaItemRequest.ProdutoTipo
            };
        }
    }
}