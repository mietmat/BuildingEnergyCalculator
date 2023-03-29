using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingEnergyCalculator.Services
{
    public class BuildingMaterialService : IBuildingMaterialService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;
        public BuildingMaterialService(EnergyCalculatorDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Create(CreateBuldingMaterialDto dto)
        {
            var buildingMaterial = _mapper.Map<BuildingMaterial>(dto);
            _dbContext.BuildingMaterials.Add(buildingMaterial);
            _dbContext.SaveChanges();

            return buildingMaterial.Id;
        }
    }
}
