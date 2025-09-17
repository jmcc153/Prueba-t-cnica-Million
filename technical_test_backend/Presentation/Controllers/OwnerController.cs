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
        public readonly ILogger<OwnerController> _logger;
        public readonly IOwnerService service;
        
        public OwnerController(ILogger<OwnerController> logger, IOwnerService service)
        {
            _logger = logger;
            this.service = service;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public async Task<ActionResult<List<Owner>>> Get()
        {
            var data = await service.GetAllOwnersAsync();
            return Ok(data);
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OwnerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
