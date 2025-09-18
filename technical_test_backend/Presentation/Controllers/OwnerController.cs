using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using technical_test.Application.DTOs.Owner;
using technical_test.Application.Interfaces;
using technical_test.Application.Services;
using technical_test.Core.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace technical_test.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly ILogger<OwnerController> _logger;
        private readonly IOwnerService service;
        
        public OwnerController(ILogger<OwnerController> logger, IOwnerService service)
        {
            _logger = logger;
            this.service = service;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public async Task<ActionResult<List<Owner>>> Get()
        {
            try
            {
                var data = await service.GetAllOwnersAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving owners.");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> Get(string id)
        {
            try
            {
                return await service.GetOwnerByIdAsync(id);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving owner with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}/foto")]
        public async Task<IActionResult> GetFoto(string id)
        {
            try
            {
                var usuario = await service.GetOwnerByIdAsync(id);
                if (usuario == null || usuario.Photo == null) return NotFound();

                return File(usuario.Photo, "image/jpeg");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving photo for owner with ID {id}.");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST api/<OwnerController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] CreateOwnerDto value)
        {
            try
            {
                await service.CreateOwnerAsync(value);
                return Ok("Owner created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating an owner.");
                return StatusCode(500, "Error creating owner");
            }
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public string Put(string id, [FromForm] UpdateOwnerDto update)
        {
            try
            {
                var result = service.UpdateOwnerAsync(id,update);
                return "Owner updated";
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating an owner.");
                return "Error updating owner";
            }
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            try
            {
                var result = service.DeleteOwnerAsync(id);
                return "Owner deleted";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting an owner.");
                return "Error deleting owner";
            }
        }
    }
}
