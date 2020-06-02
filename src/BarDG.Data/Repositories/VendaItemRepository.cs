using BarDG.Data.EFConfiguration;
using BarDG.Domain.Entities;
using BarDG.Domain.Interfaces.Repositories;

namespace BarDG.Data.Repositories
{
    internal class VendaItemRepository : Repository<VendaItem>, IVendaItemRepository
    {
        public VendaItemRepository(BarDGContext context) : base(context)
        {
        }
    }
}