using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using VehicleCatalog.Business.DTO;

namespace VehicleCatalog.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private readonly ILogger _logger;
        
        public ManufacturerController(ILogger<ManufacturerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ListManufacturers([FromQuery] int page, [FromQuery] int items)
        {
            await Task.CompletedTask;
            return Ok(new { page, items });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufacturerById(int id)
        {
            await Task.CompletedTask;
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> AddManufacturer(ManufacturerPayloadDTO manufacturer)
        {
            await Task.CompletedTask;
            return Created("api/manufacturer", manufacturer);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditManufacturer(int id, ManufacturerPayloadDTO manufacturer)
        {
            await Task.CompletedTask;
            return Ok(id);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            await Task.CompletedTask;
            return Ok(id);
        }

        [HttpGet("{id}/model")]
        public async Task<IActionResult> ListManufacturerModels(int id,
                [FromQuery] int page,
                [FromQuery] int items)
        {
            await Task.CompletedTask;
            return Ok(new {id, page, items});
        }
        
        [HttpPost("{id}/model")]
        public async Task<IActionResult> AddModelToManufacturer(int id, ModelPayloadDTO model)
        {
            await Task.CompletedTask;
            return Created($"api/model/{id}", model);
        }
    }
}