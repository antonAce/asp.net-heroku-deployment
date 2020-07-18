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
    public class LocationController : ControllerBase
    {
        private readonly ILogger _logger;
        
        public LocationController(ILogger<LocationController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public async Task<IActionResult> ListLocations([FromQuery] int page, [FromQuery] int items)
        {
            await Task.CompletedTask;
            return Ok(new {page, items});
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            await Task.CompletedTask;
            return Ok(id);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddLocation(LocationPayloadDTO location)
        {
            await Task.CompletedTask;
            return Created("api/location", location);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> EditLocation(int id, LocationPayloadDTO location)
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