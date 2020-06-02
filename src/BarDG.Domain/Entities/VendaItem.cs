namespace BarDG.Domain.Entities
{
    public class VendaItem
    {
        public int Id { get; private set; }
        public int VendaId { get; private set; }
        public int ProdutoId { get; private set; }
        public string ProdutoDescricao { get; private set; }
        public decimal Preco { get; private set; }
        public decimal Desconto { get; private set; }

        protected VendaItem() { }

        public VendaItem(int vendaId, int produtoId, string produtoDescricao, decimal preco, decimal desconto)
        {
            VendaId = vendaId;
            ProdutoId = produtoId;
            ProdutoDescricao = produtoDescricao;
            Preco = preco;
            Desconto = desconto;
        }

        public void VincularVenda(int vendaId)
        {
            VendaId = vendaId;
        }
    }
}