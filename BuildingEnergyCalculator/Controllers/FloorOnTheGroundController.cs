using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingEnergyCalculator.Controllers
{
    [Route("api/floor-on-the-ground")]
    [ApiController]
    public class FloorOnTheGroundController : ControllerBase
    {
        private readonly IFloorOnTheGroundService _floorOnTheGroundService;

        public FloorOnTheGroundController(IFloorOnTheGroundService floorOnTheGroundService)
        {
            _floorOnTheGroundService = floorOnTheGroundService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateFloorOnTheGroundDto dto)
        {
            var id = await _floorOnTheGroundService.Create(dto);
            return Created($"/api/buildinginformation/{id}", null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FloorOnTheGroundDto>>> GetAll()
        {
            var floorOnTheGroundDtos = await _floorOnTheGroundService.GetAll();
            return Ok(floorOnTheGroundDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FloorOnTheGroundDto>> GetItem([FromRoute] int id)
        {
            var floorOnTheGround = await _floorOnTheGroundService.GetById(id);

            if (floorOnTheGround is null)
            {
                return NotFound();
            }

            return Ok(floorOnTheGround);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _floorOnTheGroundService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateFloorOnTheGroundDto dto, [FromRoute] int id)
        {
            var existingFloorOnTheGround = _floorOnTheGroundService.GetById(id);


            if (existingFloorOnTheGround is null)
            {
                return NotFound();
            }

            _floorOnTheGroundService.Update(dto, id);

            return Ok();
        }
    }
}
