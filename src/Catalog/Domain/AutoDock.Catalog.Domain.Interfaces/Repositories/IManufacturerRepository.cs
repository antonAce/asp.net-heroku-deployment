using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoDock.Catalog.Domain.Core;

namespace AutoDock.Catalog.Domain.Interfaces.Repositories
{
    public interface IManufacturerRepository
    {
        Task CreateAsync(Manufacturer manufacturer, CancellationToken token);
        Task<IReadOnlyCollection<Manufacturer>> FetchAsync(int limit, int offset, CancellationToken token);
        Task<Manufacturer> FindByIdAsync(int id, CancellationToken token);
        Task UpdateAsync(Manufacturer manufacturer, CancellationToken token);
        Task DropAsync(int id, CancellationToken token);
    }
}