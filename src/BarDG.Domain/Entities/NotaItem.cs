namespace BarDG.Domain.Entities
{
    public class NotaItem
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
        public decimal Desconto { get; set; }
    }
}