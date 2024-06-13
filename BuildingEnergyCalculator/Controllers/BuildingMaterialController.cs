using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using Microsoft.AspNetCore.Mvc;

namespace BuildingEnergyCalculator.Controllers
{
    [Route("api/material")]
    [ApiController]
    public class BuildingMaterialController : ControllerBase
    {
        private readonly IBuildingMaterialService _buildingMaterialService;
        public BuildingMaterialController(IBuildingMaterialService buildingMaterialService)
        {
            _buildingMaterialService = buildingMaterialService;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateBuildingMaterial([FromBody] CreateBuildingMaterialDto dto)
        {
            var id = _buildingMaterialService.Create(dto);
            return Created($"/api/material/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<BuildingMaterialDto>> GetAll()
        {
            var buildingMaterialDtos = _buildingMaterialService.GetAll();
            return Ok(buildingMaterialDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<BuildingMaterialDto> GetItem([FromRoute] int id)
        {
            var buildingMaterial = _buildingMaterialService.GetById(id);

            if (buildingMaterial is null)
            {
                return NotFound();
            }

            return Ok(buildingMaterial);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _buildingMaterialService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateBuildingMaterialDto dto, [FromRoute] int id)
        {
            var existingMaterial = _buildingMaterialService.GetById(id);


            if (existingMaterial is null)
            {
                return NotFound();
            }

            _buildingMaterialService.Update(dto, id);

            return Ok();
        }
    }
}
