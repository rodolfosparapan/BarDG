using BarDG.Domain.Produtos.Entities;
using BarDG.Domain.Produtos.Enums;
using BarDG.Domain.Vendas.Dtos.Request;
using BarDG.Domain.Vendas.Enums;

namespace BarDG.Domain.Vendas.Dtos
{
    public class ComandaItemDto
    {
        public int VendaItemId { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public string ProdutoDescricao { get; set; }
        public ProdutoTipo ProdutoTipo { get; set; }
        public decimal ProdutoPreco { get; set; }
        public decimal ProdutoDesconto { get; set; }
        public bool Brinde { get; set; }
        public Tracking State { get; set; }
        public string ProdutoCodigo { get; set; }

        public static ComandaItemDto Novo(AdicionarVendaItemRequest request, Produto produto)
        {
            return new ComandaItemDto
            {
                VendaId = request.VendaId,
                Quantidade = request.Quantidade,
                ProdutoDescricao = produto.Descricao,
                ProdutoId = produto.Id,
                ProdutoPreco = produto.Preco,
                ProdutoTipo = produto.Tipo,
                State = Tracking.Inserted
            };
        }

        public void Atualizar(AdicionarVendaItemRequest request, Produto produto)
        {
            ProdutoDescricao = produto.Descricao;
            ProdutoPreco = produto.Preco;
            Quantidade += request.Quantidade;
            State = Tracking.Modified;
        }
    }
}