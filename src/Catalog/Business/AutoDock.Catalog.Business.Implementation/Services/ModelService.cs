using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

using AutoDock.Catalog.Business.Interfaces.DTO;
using AutoDock.Catalog.Business.Interfaces.Services;

using AutoDock.Catalog.Domain.Core;
using AutoDock.Catalog.Domain.Interfaces.Repositories;
using AutoDock.Catalog.Domain.Interfaces.UnitOfWork;

namespace AutoDock.Catalog.Business.Implementation.Services
{
    public class ModelService : IModelService
    {
        private IModelRepository ModelRepository { get; }
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }

        public ModelService(
            IModelRepository modelRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            ModelRepository = modelRepository;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<IReadOnlyCollection<ReadModelDto>> ModelPaginationAsync(
            int itemsCount,
            int pageNumber,
            CancellationToken token) =>
            Mapper.Map<IEnumerable<Model>, IReadOnlyCollection<ReadModelDto>>(await ModelRepository.FetchAsync(
                itemsCount,
                itemsCount * (pageNumber - 1),
                token));

        public async Task<ReadModelDto> FindModelAsync(int id, CancellationToken token) =>
            Mapper.Map<Model, ReadModelDto>(await ModelRepository.FindByIdAsync(id, token));

        public async Task CreateModel(CreateUpdateModelDto model, CancellationToken token)
        {
            var modelToCreate = new Model
            {
                Name = model.Name,
                ProductionStart = DateTime.Parse(model.ProductionStart),
                ProductionEnd = DateTime.Parse(model.ProductionEnd)
            };
            
            await ModelRepository.CreateAsync(modelToCreate, token);
            await UnitOfWork.CommitAsync(token);
        }

        public async Task EditModel(int id, CreateUpdateModelDto model, CancellationToken token)
        {
            var modelToUpdate = new Model
            {
                Id = id,
                Name = model.Name,
                ProductionStart = DateTime.Parse(model.ProductionStart),
                ProductionEnd = DateTime.Parse(model.ProductionEnd)
            };
            
            await ModelRepository.UpdateAsync(modelToUpdate, token);
            await UnitOfWork.CommitAsync(token);
        }

        public async Task DeleteModel(int id, CancellationToken token)
        {
            await ModelRepository.DropAsync(id, token);
            await UnitOfWork.CommitAsync(token);
        }
    }
}
