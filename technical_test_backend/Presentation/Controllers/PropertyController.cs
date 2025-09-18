using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<List<Property>>> Get()
        {
            var data = await service.GetAllPropertiesAsync();
            return Ok(data);

        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyOwnerResponseDto>> GetPropertyOwner(string id)
        {
            var data = await service.GetPropertyOwnerById(id);
            return Ok(data);
        }

        // POST api/<PropertyController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PropertyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PropertyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
