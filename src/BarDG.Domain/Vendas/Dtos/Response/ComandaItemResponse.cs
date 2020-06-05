namespace BarDG.Domain.Vendas.Dtos.Response
{
    public class ComandaItemResponse
    {
        public int VendaItemId { get; set; }
        public int Quantidade { get; set; }
        public string ProdutoDescricao { get; set; }
        public decimal ProdutoPreco { get; set; }
        public decimal ProdutoDesconto { get; set; }
    }
}
