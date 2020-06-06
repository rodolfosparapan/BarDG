namespace BarDG.Domain.Fiscal.Entities
{
    public class NotaItem
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public decimal Desconto { get; set; }
    }
}