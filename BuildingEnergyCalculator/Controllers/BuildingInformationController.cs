using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingEnergyCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingInformationController : ControllerBase
    {
        private readonly IBuildingInformationService _buildingInformationService;

        public BuildingInformationController(IBuildingInformationService buildingInformationService)
        {
            _buildingInformationService = buildingInformationService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateBuildingInformationDto dto)
        {
            var id = _buildingInformationService.Create(dto);
            return Created($"/api/investment/{id}", null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingInformationDto>>> GetAll()
        {
            var investmentDtos = await _buildingInformationService.GetAll();
            return Ok(investmentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingInformationDto>> GetItem([FromRoute] int id)
        {
            var buildingInformation = await _buildingInformationService.GetById(id);

            if (buildingInformation is null)
            {
                return NotFound();
            }

            return Ok(buildingInformation);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _buildingInformationService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateBuildingInformationDto dto, [FromRoute] int id)
        {
            var existingInvestment = _buildingInformationService.GetById(id);


            if (existingInvestment is null)
            {
                return NotFound();
            }

            _buildingInformationService.Update(dto, id);

            return Ok();
        }
    }
}
