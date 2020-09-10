using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using AutoDock.Catalog.Business.Interfaces.DTO;
using AutoDock.Catalog.Business.Interfaces.Services;

using AutoDock.Catalog.Domain.Core;
using AutoDock.Catalog.Domain.Interfaces.Repositories;

namespace AutoDock.Catalog.Business.Implementation.Services
{
    public class ModelService : IModelService
    {
        private IModelRepository ModelRepository { get; }
        private IMapper Mapper { get; }

        public ModelService(
            IModelRepository modelRepository,
            IMapper mapper)
        {
            ModelRepository = modelRepository;
            Mapper = mapper;
        }

        public async Task<IReadOnlyCollection<ReadModelDto>> ModelPaginationAsync(
            int itemsCount,
            int pageNumber,
            CancellationToken token) =>
            Mapper.Map<IEnumerable<Model>, IReadOnlyCollection<ReadModelDto>>(await ModelRepository.FetchAsync(
                itemsCount,
                itemsCount * pageNumber,
                token));

        public async Task<ReadModelDto> FindModelAsync(int id, CancellationToken token) =>
            Mapper.Map<Model, ReadModelDto>(await ModelRepository.FindByIdAsync(id, token));
    }
}