using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using AutoDock.Catalog.Business.Interfaces.DTO;
using AutoDock.Catalog.Business.Interfaces.Services;

namespace AutoDock.Catalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelController : ControllerBase
    {
        private IModelService ModelService { get; }

        public ModelController(IModelService modelService) =>
            ModelService = modelService;

        [HttpGet]
        public async Task<IReadOnlyCollection<ReadModelDto>> FetchModels(
            [FromQuery] int page,
            [FromQuery] int items,
            CancellationToken token) => await ModelService.ModelPaginationAsync(page, items, token);

        [HttpGet("{id}")]
        public async Task<ReadModelDto> GetModelById(int id, CancellationToken token) =>
            await ModelService.FindModelAsync(id, token);

        [HttpPost]
        public async Task CreateModel(CreateUpdateModelDto model, CancellationToken token) =>
            await ModelService.CreateModel(model, token);

        [HttpPut("{id}")]
        public async Task UpdateModel(int id, CreateUpdateModelDto model, CancellationToken token) =>
            await ModelService.EditModel(id, model, token);

        [HttpDelete("{id}")]
        public async Task DeleteModel(int id, CancellationToken token) =>
            await ModelService.DeleteModel(id, token);
    }
}