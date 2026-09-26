using MainAppBackend.Application.Dtos.ClientLookup;
using MainAppBackend.Application.Interfaces.ClientLookup;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MainAppBackend.API.Controllers.ClientLookup
{
    [ApiController]
    [Route("api/ClientLookupController")]
    public class ClientLookupController : ControllerBase
    {
        private readonly IClientLookupService _service;

        public ClientLookupController(IClientLookupService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UpdateCreateClientLookupDto input)
        {
            var result = await _service.CreateAsync(input);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UpdateCreateClientLookupDto input)
        {
            var result = await _service.UpdateAsync(id, input);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            return Ok(await _service.GetAllAsync(skip, take));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }
    }
}