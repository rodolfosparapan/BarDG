using BarDG.Data.EFConfiguration;
using BarDG.Domain.Vendas.Entities;
using BarDG.Domain.Vendas.Interfaces;

namespace BarDG.Data.Repositories
{
    internal class VendaRepository : RepositoryBase<Venda>, IVendaRepository
    {
        public VendaRepository(BarDGContext context) : base(context)
        {
        }
    }
}