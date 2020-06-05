using BarDG.Domain.Vendas.Dtos;

namespace BarDG.Domain.Vendas.Entities
{
    public class VendaItem
    {
        public int Id { get; private set; }
        public int VendaId { get; private set; }
        public int ProdutoId { get; private set; }
        public int Quantidade { get; private set; }
        public string ProdutoDescricao { get; private set; }
        public decimal Preco { get; private set; }
        public decimal Desconto { get; private set; }

        protected VendaItem() { }

        public static VendaItem Novo(ComandaItemDto comandaItem)
        {
            return new VendaItem
            {
                Id = comandaItem.VendaItemId,
                VendaId = comandaItem.VendaId,
                ProdutoId = comandaItem.ProdutoId,
                Quantidade = comandaItem.Quantidade,
                ProdutoDescricao = comandaItem.ProdutoDescricao,
                Preco = comandaItem.ProdutoPreco,
                Desconto = comandaItem.ProdutoDesconto
            };
        }
    }
}