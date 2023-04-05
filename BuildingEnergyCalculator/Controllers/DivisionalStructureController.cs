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
        private readonly IDivisionalStructureService _idivisionalStructureService;
        public DivisionalStructureController(IDivisionalStructureService idivisionalStructureService)
        {
            _idivisionalStructureService = idivisionalStructureService;
        }

        [HttpPost]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult CreateDivisionalStructure([FromBody] CreateDivisionalStructureDto dto)
        {
            var id = _idivisionalStructureService.Create(dto);
            return Created($"/api/material/{id}", null);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin,Manager")]
        public ActionResult<IEnumerable<DivisionalStructureDto>> GetAll()
        {
            var divisionalStructureDto = _idivisionalStructureService.GetAll();
            return Ok(divisionalStructureDto);
        }


    }
}
