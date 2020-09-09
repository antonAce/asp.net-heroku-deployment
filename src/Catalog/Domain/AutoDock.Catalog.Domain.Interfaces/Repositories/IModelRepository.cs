using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoDock.Catalog.Domain.Core;

namespace AutoDock.Catalog.Domain.Interfaces.Repositories
{
    public interface IModelRepository
    {
        Task CreateAsync(Model model, CancellationToken token);
        Task<IEnumerable<Model>> FetchAsync(int limit, int offset, CancellationToken token);
        Task<Model> FindByIdAsync(int id, CancellationToken token);
        Task UpdateAsync(Model model, CancellationToken token);
        Task DropAsync(int id, CancellationToken token);
    }
}