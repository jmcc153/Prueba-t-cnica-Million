using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using technical_test.Application.DTOs.Property;
using technical_test.Application.Interfaces;
using technical_test.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace technical_test.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {

        private readonly ILogger<PropertyController> _logger;
        private readonly IPropertyService service;

        public PropertyController(ILogger<PropertyController> logger, IPropertyService service)
        {
            _logger = logger;
            this.service = service;
        }
        // GET: api/<PropertyController>
        [HttpGet]
        public async Task<ActionResult<List<PropertyResponseDto>>> Get([FromQuery] string? name, [FromQuery] string? address, [FromQuery] double? priceMin, [FromQuery] double? priceMax
        )
        {
            try
            {
                var data = await service.GetAllPropertiesAsync(name, address, priceMin, priceMax);
                return Ok(data);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving properties.");
                return StatusCode(500, "Internal server error");
            }

        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyOwnerResponseDto>> GetPropertyOwner(string id)
        {
            try
            {
                var data = await service.GetPropertyOwnerById(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving property with ID {id}.");
                return StatusCode(500, "Internal server error");
            }                                   
        }

        // POST api/<PropertyController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreatePropertyDto value)
        {
            try
            {
                await service.CreatePropertyAsync(value);
                return Ok("Property created");
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
