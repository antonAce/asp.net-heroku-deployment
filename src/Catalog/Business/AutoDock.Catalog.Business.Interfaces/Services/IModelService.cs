using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AutoDock.Catalog.Business.Interfaces.DTO;

namespace AutoDock.Catalog.Business.Interfaces.Services
{
    public interface IModelService
    {
        Task<IReadOnlyCollection<ReadModelDto>> ModelPaginationAsync(int pageNumber, int itemsCount, CancellationToken token);
        Task<ReadModelDto> FindModelAsync(int id, CancellationToken token);
        Task EditModelAsync(int id, CreateUpdateModelDto model, CancellationToken token);
        Task DeleteModelAsync(int id, CancellationToken token);
    }
}