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
    public class ManufacturerService : IManufacturerService
    {
        private IManufacturerRepository ManufacturerRepository { get; }
        private IModelRepository ModelRepository { get; }
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }
        
        public ManufacturerService(
            IManufacturerRepository manufacturerRepository,
            IModelRepository modelRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            ManufacturerRepository = manufacturerRepository;
            ModelRepository = modelRepository;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        
        public async Task<IReadOnlyCollection<ReadManufacturerDto>> ManufacturerPaginationAsync(int pageNumber, 
                                                                                                int itemsCount, 
                                                                                                CancellationToken token) =>
            Mapper.Map<IEnumerable<Manufacturer>, IReadOnlyCollection<ReadManufacturerDto>>(
                await ManufacturerRepository.FetchAsync(
                    itemsCount,
                    itemsCount * (pageNumber - 1),
                    token));

        public async Task<ReadManufacturerDto> FindManufacturerAsync(int id, CancellationToken token) =>
            Mapper.Map<Manufacturer, ReadManufacturerDto>(await ManufacturerRepository.FindByIdAsync(id, token));

        public async Task CreateManufacturerAsync(CreateUpdateManufacturerDto manufacturer, CancellationToken token)
        {
            var manufacturerToCreate = new Manufacturer
            {
                Name = manufacturer.Name,
                Foundation = DateTime.Parse(manufacturer.Foundation)
            };

            await ManufacturerRepository.CreateAsync(manufacturerToCreate, token);
            await UnitOfWork.CommitAsync(token);
        }

        public async Task EditManufacturerAsync(int id, CreateUpdateManufacturerDto manufacturer, CancellationToken token)
        {
            var manufacturerToUpdate = new Manufacturer
            {
                Id = id,
                Name = manufacturer.Name,
                Foundation = DateTime.Parse(manufacturer.Foundation)
            };

            await ManufacturerRepository.UpdateAsync(manufacturerToUpdate, token);
            await UnitOfWork.CommitAsync(token);
        }

        public async Task DeleteManufacturerAsync(int id, CancellationToken token)
        {
            await ManufacturerRepository.DropAsync(id, token);
            await UnitOfWork.CommitAsync(token);
        }

        public async Task<IReadOnlyCollection<ReadModelDto>> GetManufacturerModelsAsync(int id, CancellationToken token)
        {
            var manufacturer = await ManufacturerRepository.FindByIdAsync(id, token);
            var models = Mapper.Map<IEnumerable<Model>, IReadOnlyCollection<ReadModelDto>>(manufacturer.Models);
            return models;
        }

        public async Task AttachModelToManufacturer(int id, CreateUpdateModelDto model, CancellationToken token)
        {
            var manufacturer = await ManufacturerRepository.FindByIdAsync(id, token);
            
            if (manufacturer == null)
                throw new ApplicationException("Manufacturer with given Id doesn't exist.");
            
            var modelToCreate = new Model
            {
                Name = model.Name,
                ProductionStart = DateTime.Parse(model.ProductionStart),
                ProductionEnd = DateTime.Parse(model.ProductionEnd),
                ManufacturerId = id,
            };
            
            await ModelRepository.CreateAsync(modelToCreate, token);
            await UnitOfWork.CommitAsync(token);
        }
    }
}