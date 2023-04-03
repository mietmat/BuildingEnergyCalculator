using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using Microsoft.AspNetCore.Http;
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
        public ActionResult CreateBuildingMaterial([FromBody] CreateBuldingMaterialDto dto)
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
        public ActionResult<BuildingMaterialDto> Get([FromRoute] int id)
        {
            var buildingMaterial = _buildingMaterialService.GetById(id);

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
            _buildingMaterialService.Update(dto, id);
            return Ok();
        }
    }
}
