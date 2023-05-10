using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildingEnergyCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestmentController : ControllerBase
    {
        private readonly IInvestmentService _investmentService;

        public InvestmentController(IInvestmentService investmentService)
        {
            _investmentService = investmentService;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateInvestmentDto dto)
        {
            var id = _investmentService.Create(dto);
            return Created($"/api/investment/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<InvestmentDto>> GetAll()
        {
            var investmentDtos = _investmentService.GetAll();
            return Ok(investmentDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<InvestmentDto> GetItem([FromRoute] int id)
        {
            var buildingMaterial = _investmentService.GetById(id);

            if (buildingMaterial is null)
            {
                return NotFound();
            }

            return Ok(buildingMaterial);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _investmentService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateInvestmentDto dto, [FromRoute] int id)
        {
            var existingInvestment = _investmentService.GetById(id);


            if (existingInvestment is null)
            {
                return NotFound();
            }

            _investmentService.Update(dto, id);

            return Ok();
        }
    }
}
