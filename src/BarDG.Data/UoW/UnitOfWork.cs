using BarDG.Data.EFConfiguration;
using BarDG.Domain.Common.Interfaces;

namespace BarDG.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BarDGContext context;

        public UnitOfWork(BarDGContext context)
        {
            this.context = context;
        }

        public bool Commit()
        {
            return context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}