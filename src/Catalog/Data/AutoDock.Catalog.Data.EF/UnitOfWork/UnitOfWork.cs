using System.Threading;
using System.Threading.Tasks;

using AutoDock.Catalog.Data.EF.Context;
using AutoDock.Catalog.Domain.Interfaces.UnitOfWork;

namespace AutoDock.Catalog.Data.EF.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AutoDockContext _context;

        public UnitOfWork(AutoDockContext context) =>
            _context = context;

        public async Task CommitAsync(CancellationToken token) =>
            await _context.SaveChangesAsync(token);

        public async ValueTask DisposeAsync() =>
            await _context.DisposeAsync();
    }
}