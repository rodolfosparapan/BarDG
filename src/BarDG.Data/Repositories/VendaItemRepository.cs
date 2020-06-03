using BarDG.Data.EFConfiguration;
using BarDG.Domain.Vendas.Entities;
using BarDG.Domain.Vendas.Interfaces;

namespace BarDG.Data.Repositories
{
    internal class VendaItemRepository : RepositoryBase<VendaItem>, IVendaItemRepository
    {
        public VendaItemRepository(BarDGContext context) : base(context)
        {
        }
    }
}