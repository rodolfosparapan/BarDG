using BarDG.Domain.Produtos.Enums;

namespace BarDG.Domain.Vendas.Dtos
{
    public class ComandaItemDto
    {
        public ProdutoTipo ProdutoTipo { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }
    }
}