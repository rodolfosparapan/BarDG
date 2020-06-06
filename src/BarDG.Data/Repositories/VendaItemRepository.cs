using BarDG.Data.EFConfiguration;
using BarDG.Domain.Produtos.Entities;
using BarDG.Domain.Vendas.Dtos;
using BarDG.Domain.Vendas.Dtos.Response;
using BarDG.Domain.Vendas.Entities;
using BarDG.Domain.Vendas.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BarDG.Data.Repositories
{
    internal class VendaItemRepository : RepositoryBase<VendaItem>, IVendaItemRepository
    {
        private readonly BarDGContext context;

        public VendaItemRepository(BarDGContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<ComandaItemDto> ListarComandaItens(int vendaId)
        {
            return
                from vendaItem in context.Set<VendaItem>()
                join produto in context.Set<Produto>()
                    on vendaItem.ProdutoId equals produto.Id
                where vendaItem.VendaId == vendaId
                select new ComandaItemDto
                {
                    VendaId = vendaItem.VendaId,
                    VendaItemId = vendaItem.Id,
                    Quantidade = vendaItem.Quantidade,
                    ProdutoDesconto = vendaItem.Desconto,
                    ProdutoDescricao = vendaItem.ProdutoDescricao,
                    ProdutoId = vendaItem.ProdutoId,
                    ProdutoPreco = vendaItem.Preco,
                    ProdutoTipo = produto.Tipo,
                    Brinde = vendaItem.Brinde,
                    ProdutoCodigo = produto.Codigo
                };
        }

        public IEnumerable<ComandaItemResponse> ListarComandaItensResponse(int vendaId)
        {
            return DbSet.Where(vi => vi.VendaId == vendaId).Select(vi => new ComandaItemResponse
            {
                VendaItemId = vi.Id,
                Quantidade = vi.Quantidade,
                ProdutoDescricao = vi.ProdutoDescricao,
                ProdutoPreco = vi.Preco,
                ProdutoDesconto = vi.Desconto,
                Brinde = vi.Brinde
            });
        }

        public void LimparItens(int vendaId)
        {
            var itens = DbSet.Where(vi => vi.VendaId == vendaId);
            DbSet.RemoveRange(itens);            
        }

        public void Salvar(List<VendaItem> itensInserir, List<VendaItem> itensAtualizar)
        {
            DbSet.AddRange(itensInserir);
            DbSet.UpdateRange(itensAtualizar);
        }
    }
}