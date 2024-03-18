using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingEnergyCalculator.Controllers
{
    [Route("api/project")]
    [ApiController]
    //[Authorize]
    public class ProjectModelController : ControllerBase
    {
        private readonly IProjectModelService _projectModelService;

        public ProjectModelController(IProjectModelService projectModelService)
        {
            _projectModelService = projectModelService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateProjectModelDto dto)
        {
            var id = await _projectModelService.Create(dto);
            return Created($"/api/project/{id}", null);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProjectModelDto>>> GetAll()
        {
            var investmentDtos = await _projectModelService.GetAll();
            return Ok(investmentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModelDto>> GetItem([FromRoute] int id)
        {
            var buildingInformation = await _projectModelService.GetById(id);

            if (buildingInformation is null)
            {
                return NotFound();
            }

            return Ok(buildingInformation);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _projectModelService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateProjectModelDto dto, [FromRoute] int id)
        {
            var existingInvestment = _projectModelService.GetById(id);


            if (existingInvestment is null)
            {
                return NotFound();
            }

            _projectModelService.Update(dto, id);

            return Ok();
        }
    }
}
