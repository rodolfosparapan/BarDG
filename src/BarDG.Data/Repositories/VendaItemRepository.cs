using BarDG.Data.EFConfiguration;
using BarDG.Domain.Produtos.Entities;
using BarDG.Domain.Vendas.Dtos;
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
                    ProdutoDesconto = vendaItem.Desconto,
                    ProdutoDescricao = vendaItem.ProdutoDescricao,
                    ProdutoId = vendaItem.ProdutoId,
                    ProdutoPreco = vendaItem.Preco,
                    ProdutoTipo = produto.Tipo
                };
        }
    }
}