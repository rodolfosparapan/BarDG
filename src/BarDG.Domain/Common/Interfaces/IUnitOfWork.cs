using System;

namespace BarDG.Domain.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}