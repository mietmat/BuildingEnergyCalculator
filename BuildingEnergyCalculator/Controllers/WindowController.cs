using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingEnergyCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly IWindowService _windowService;
        public WindowController(IWindowService windowService)
        {
            _windowService = windowService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateWindowDto dto)
        {
            var id = _windowService.Create(dto);
            return Created($"/api/window/{id}", null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoorDto>>> GetAll()
        {
            var doorDtos = await _windowService.GetAll();
            return Ok(doorDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WindowDto>> GetItem([FromRoute] int id)
        {
            var door = await _windowService.GetById(id);

            if (door is null)
            {
                return NotFound();
            }

            return Ok(door);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _windowService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateWindowDto dto, [FromRoute] int id)
        {
            var door = _windowService.GetById(id);


            if (door is null)
            {
                return NotFound();
            }

            _windowService.Update(dto, id);

            return Ok();
        }
    }
}
