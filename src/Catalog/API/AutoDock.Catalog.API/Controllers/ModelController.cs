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
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService) =>
            _modelService = modelService;

        [HttpGet]
        public async Task<IReadOnlyCollection<ReadModelDto>> FetchModels(
            [FromQuery] int page,
            [FromQuery] int items,
            CancellationToken token) => await _modelService.ModelPaginationAsync(page, items, token);

        [HttpGet("{id}")]
        public async Task<ReadModelDto> GetModelById(int id, CancellationToken token) =>
            await _modelService.FindModelAsync(id, token);

        [HttpPost]
        public async Task CreateModel(CreateUpdateModelDto model, CancellationToken token) =>
            await _modelService.CreateModel(model, token);
    }
}