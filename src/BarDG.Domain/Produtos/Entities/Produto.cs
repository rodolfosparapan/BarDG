using BarDG.Domain.Produtos.Enums;

namespace BarDG.Domain.Produtos.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public ProdutoTipo Tipo { get; set; }
    }
}