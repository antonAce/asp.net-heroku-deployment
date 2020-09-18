using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AutoDock.Catalog.Business.Interfaces.DTO;

namespace AutoDock.Catalog.Business.Interfaces.Services
{
    public interface IManufacturerService
    {
        Task<IReadOnlyCollection<ReadManufacturerDto>> ManufacturerPaginationAsync(int itemsCount, 
                                                                                   int pageNumber, CancellationToken token);
        Task<ReadManufacturerDto> FindManufacturerAsync(int id, CancellationToken token);
        Task CreateManufacturerAsync(CreateUpdateManufacturerDto manufacturer, CancellationToken token);
        Task EditManufacturerAsync(int id, CreateUpdateManufacturerDto manufacturer, CancellationToken token);
        Task DeleteManufacturerAsync(int id, CancellationToken token);
    }
}