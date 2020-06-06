namespace BarDG.Domain.Vendas.Dtos.Response
{
    public class ComandaItemResponse
    {
        public int VendaItemId { get; set; }
        public int Quantidade { get; set; }
        public string ProdutoDescricao { get; set; }
        public decimal ProdutoPreco { get; set; }
        public decimal ProdutoDesconto { get; set; }
        public bool Brinde { get; set; }
        public decimal Total => Brinde ? 0 : ProdutoPreco * Quantidade - ProdutoDesconto;
    }
}