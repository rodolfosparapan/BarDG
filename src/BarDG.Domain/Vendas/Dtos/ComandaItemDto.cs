using BarDG.Domain.Produtos.Enums;

namespace BarDG.Domain.Vendas.Dtos
{
    public class ComandaItemDto
    {
        public int ProdutoId { get; set; }
        public string ProdutoDescricao { get; set; }
        public ProdutoTipo ProdutoTipo { get; set; }
        public decimal ProdutoPreco { get; set; }
        public decimal ProdutoDesconto { get; set; }
    }
}