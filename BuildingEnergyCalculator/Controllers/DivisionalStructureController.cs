using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingEnergyCalculator.Controllers
{
    [Route("api/divisionalstructure")]
    [ApiController]
    public class DivisionalStructureController : ControllerBase
    {
        private readonly IDivisionalStructureService _divisionalStructureService;
        public DivisionalStructureController(IDivisionalStructureService divisionalStructureService)
        {
            _divisionalStructureService = divisionalStructureService;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateDivisionalStructure([FromBody] CreateDivisionalStructureDto dto)
        {
            var id = _divisionalStructureService.Create(dto);
            return Created($"/api/material/{id}", null);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult<IEnumerable<DivisionalStructureDto>> GetAll()
        {
            var divisionalStructureDto = _divisionalStructureService.GetAll();
            return Ok(divisionalStructureDto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _divisionalStructureService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateDivisionalStructureDto dto, [FromRoute] int id)
        {
            _divisionalStructureService.Update(dto, id);
            return Ok();
        }


    }
}
