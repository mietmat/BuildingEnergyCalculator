using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingEnergyCalculator.Controllers
{
    [Route("api/buildingparameters")]
    [ApiController]
    public class BuildingParametersController : ControllerBase
    {
        private readonly IBuildingParametersService _buildingParametersService;
        public BuildingParametersController(IBuildingParametersService buildingParametersService)
        {
            _buildingParametersService = buildingParametersService;
        }

        [HttpPost("{solutionId}")]
        public ActionResult CreateBuildingParameters([FromBody] CreateBuildingParametersDto dto, [FromRoute] int solutionId)
        {
            var id = _buildingParametersService.Create(dto, solutionId);
            return Created($"/api/buildingparameters/{id}", null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingParametersDto>>> GetAll()
        {
            var buildingParametersDtos = await _buildingParametersService.GetAll();
            return Ok(buildingParametersDtos);
        }

        [HttpGet("{solutionId}")]
        public async Task<ActionResult<BuildingParametersDto>> GetBySolutionId([FromRoute] int solutionId)
        {
            var buildingParameters = await _buildingParametersService.GetBySolutionId(solutionId);

            if (buildingParameters is null)
            {
                return NotFound();
            }

            return Ok(buildingParameters);
        }

        //[HttpGet("{id}")]
        //public ActionResult<BuildingParametersDto> GetItem([FromRoute] int id)
        //{
        //    var buildingParameters = _buildingParametersService.GetById(id);

        //    if (buildingParameters is null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(buildingParameters);
        //}

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _buildingParametersService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateBuildingParametersDto dto, [FromRoute] int id)
        {
            var existingBuildingParameters = _buildingParametersService.GetById(id);


            if (existingBuildingParameters is null)
            {
                return NotFound();
            }

            _buildingParametersService.Update(dto, id);

            return Ok();
        }
    }
}
