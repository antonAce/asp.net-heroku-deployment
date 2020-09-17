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
        private IUnitOfWork UnitOfWork { get; }
        private IMapper Mapper { get; }
        
        public ManufacturerService(
            IManufacturerRepository manufacturerRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            ManufacturerRepository = manufacturerRepository;
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
        
        public async Task<IReadOnlyCollection<ReadManufacturerDto>> ManufacturerPaginationAsync(int itemsCount, 
                                                                                                int pageNumber, 
                                                                                                CancellationToken token) =>
            Mapper.Map<IEnumerable<Manufacturer>, IReadOnlyCollection<ReadManufacturerDto>>(
                await ManufacturerRepository.FetchAsync(
                    itemsCount,
                    itemsCount * (pageNumber - 1),
                    token));

        public async Task<ReadManufacturerDto> FindManufacturerAsync(int id, CancellationToken token) =>
            Mapper.Map<Manufacturer, ReadManufacturerDto>(await ManufacturerRepository.FindByIdAsync(id, token));
    }
}