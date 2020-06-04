using BarDG.Domain.Vendas.Dtos.Request;

namespace BarDG.Domain.Vendas.Entities
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

        public static VendaItem Novo(AdicionarVendaItemRequest adicionarVendaItemRequest)
        {
            return new VendaItem
            {
                VendaId = adicionarVendaItemRequest.VendaId,
                ProdutoId = adicionarVendaItemRequest.ProdutoId,
                ProdutoDescricao = adicionarVendaItemRequest.ProdutoDescricao,
                Preco = adicionarVendaItemRequest.Preco,
                Desconto = adicionarVendaItemRequest.Desconto
            };
        }

        public void AtualizarPreco(decimal preco)
        {
            Preco = preco;
        }
    }
}