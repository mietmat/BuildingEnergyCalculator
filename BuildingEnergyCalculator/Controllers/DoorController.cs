using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingEnergyCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoorController : ControllerBase
    {
        private readonly IDoorService _doorService;
        public DoorController(IDoorService doorService)
        {
            _doorService = doorService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateDoorDto dto)
        {
            var id = _doorService.Create(dto);
            return Created($"/api/door/{id}", null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoorDto>>> GetAll()
        {
            var doorDtos = await _doorService.GetAll();
            return Ok(doorDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoorDto>> GetItem([FromRoute] int id)
        {
            var door = await _doorService.GetById(id);

            if (door is null)
            {
                return NotFound();
            }

            return Ok(door);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _doorService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateDoorDto dto, [FromRoute] int id)
        {
            var door = _doorService.GetById(id);


            if (door is null)
            {
                return NotFound();
            }

            _doorService.Update(dto, id);

            return Ok();
        }
    }
}
