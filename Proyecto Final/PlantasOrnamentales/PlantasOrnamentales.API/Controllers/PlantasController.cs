using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using PlantasOrnamentales.Application.Contracts;
using PlantasOrnamentales.Application.DTOs;

namespace PlantasOrnamentales.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantasController : ControllerBase
    {
        private readonly IPlantaService _service;

        public PlantasController(IPlantaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlantaReadDto>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PlantaReadDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] PlantaCreateDto dto)
        {
            var ok = await _service.CreateAsync(dto);
            if (!ok) return BadRequest();
            return Ok(); // <- simple, evita el 500 por CreatedAtAction sin id
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] PlantaUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest("Id de ruta y body no coinciden.");
            var ok = await _service.UpdateAsync(dto);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
