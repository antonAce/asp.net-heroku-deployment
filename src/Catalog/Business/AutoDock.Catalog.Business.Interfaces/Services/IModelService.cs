using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AutoDock.Catalog.Business.Interfaces.DTO;

namespace AutoDock.Catalog.Business.Interfaces.Services
{
    public interface IModelService
    {
        Task<IReadOnlyCollection<ReadModelDto>> ModelPaginationAsync(int itemsCount, int pageNumber, CancellationToken token);
        Task<ReadModelDto> FindModelAsync(int id, CancellationToken token);
        Task CreateModel(CreateUpdateModelDto model, CancellationToken token);
        Task EditModel(int id, CreateUpdateModelDto model, CancellationToken token);
        Task DeleteModel(int id, CancellationToken token);
    }
}