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
    public class ModelController : ControllerBase
    {
        private readonly ILogger _logger;
        
        public ModelController(ILogger<ModelController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> ListModels([FromQuery] int page, [FromQuery] int items)
        {
            await Task.CompletedTask;
            return Ok(new {page, items});
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetModelById(int id)
        {
            await Task.CompletedTask;
            return Ok(id);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditModel(int id, ModelPayloadDTO model)
        {
            await Task.CompletedTask;
            return Ok(id);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            await Task.CompletedTask;
            return Ok(id);
        }
    }
}