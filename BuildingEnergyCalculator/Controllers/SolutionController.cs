using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuildingEnergyCalculator.Controllers
{
    [Route("api/solution")]
    [ApiController]
    //[Authorize]
    public class SolutionController : ControllerBase
    {
        private readonly ISolutionService _solutionService;

        public SolutionController(ISolutionService solutionService)
        {
            _solutionService = solutionService;
        }

        [AllowAnonymous]
        [HttpPost("{projectId}")]
        public async Task<ActionResult<int>> Create(int projectId, [FromBody] CreateSolutionDto dto)
        {
            dto.ProjectId = projectId;
            var id = await _solutionService.Create(dto);
            return Created($"/api/solution/{id}", null);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SolutionDto>>> GetAll()
        {
            var solutionDtos = await _solutionService.GetAll();
            return Ok(solutionDtos);
        }

        [AllowAnonymous]
        [HttpGet("{projectId}/solutions")]
        public async Task<ActionResult<IEnumerable<SolutionDto>>> GetByProjectId([FromRoute] int projectId)
        {
            var solutionDtos = await _solutionService.GetByProjectId(projectId);
            return Ok(solutionDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SolutionDto>> GetItem([FromRoute] int id)
        {
            var solution = await _solutionService.GetById(id);

            if (solution is null)
            {
                return NotFound();
            }

            return Ok(solution);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _solutionService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateSolutionDto dto, [FromRoute] int id)
        {
            var existingSolution = _solutionService.GetById(id);


            if (existingSolution is null)
            {
                return NotFound();
            }

            _solutionService.Update(dto, id);

            return Ok();
        }
    }
}
