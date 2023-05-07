using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingEnergyCalculator.Controllers
{
    [Route("api/buildingparameters")]
    [ApiController]
    public class BuildingParameters : ControllerBase
    {
        private readonly IBuildingParametersService _buildingParametersService;
        public BuildingParameters(IBuildingParametersService buildingParametersService)
        {
            _buildingParametersService = buildingParametersService;
        }

        [HttpPost]
        public ActionResult CreateBuildingParameters([FromBody] CreateBuildingParametersDto dto)
        {
            var id = _buildingParametersService.Create(dto);
            return Created($"/api/buildingparameters/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<BuildingParametersDto>> GetAll()
        {
            var buildingParametersDtos = _buildingParametersService.GetAll();
            return Ok(buildingParametersDtos);
        }
    }
}
