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
    }
}
