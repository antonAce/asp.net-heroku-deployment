using System;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDock.Catalog.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task CommitAsync(CancellationToken token);
    }
}