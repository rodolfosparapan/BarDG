namespace BarDG.Domain.Entities
{
    public class VendaItem
    {
        public int Id { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }
    }
}