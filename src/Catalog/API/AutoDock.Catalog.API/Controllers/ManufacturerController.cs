using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AutoDock.Catalog.API.Filters.Providers;
using AutoDock.Catalog.Business.Interfaces.DTO;
using AutoDock.Catalog.Business.Interfaces.Services;

namespace AutoDock.Catalog.API.Controllers
{
    [ApiController]
    [BadRequestFilter]
    [Route("api/[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private IManufacturerService ManufacturerService { get; }

        public ManufacturerController(IManufacturerService manufacturerService) =>
            ManufacturerService = manufacturerService;
        
        [HttpGet]
        [FetchItemsEndpoint]
        public async Task<IReadOnlyCollection<ReadManufacturerDto>> FetchManufacturers(
            [FromQuery] int page,
            [FromQuery] int items,
            CancellationToken token) => await ManufacturerService.ManufacturerPaginationAsync(page, items, token);
        
        [HttpGet("{id}")]
        public async Task<ReadManufacturerDto> GetManufacturerById(int id, CancellationToken token) =>
            await ManufacturerService.FindManufacturerAsync(id, token);

        [HttpPost]
        public async Task CreateManufacturerAsync(CreateUpdateManufacturerDto manufacturer, CancellationToken token) =>
            await ManufacturerService.CreateManufacturerAsync(manufacturer, token);

        [HttpPut("{id}")]
        public async Task EditManufacturerAsync(int id, CreateUpdateManufacturerDto manufacturer,
            CancellationToken token) =>
            await ManufacturerService.EditManufacturerAsync(id, manufacturer, token);

        [HttpDelete("{id}")]
        public async Task DeleteManufacturerAsync(int id, CancellationToken token) =>
            await ManufacturerService.DeleteManufacturerAsync(id, token);

        [HttpGet("{id}/model")]
        public async Task<IReadOnlyCollection<ReadModelDto>> GetManufacturerModelsAsync(int id, CancellationToken token) =>
            await ManufacturerService.GetManufacturerModelsAsync(id, token);

        [HttpPost("{id}/model")]
        public async Task AttachModelToManufacturer(int id, CreateUpdateModelDto model, CancellationToken token) =>
            await ManufacturerService.AttachModelToManufacturer(id, model, token);
    }
}