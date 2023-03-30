using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Exceptions;
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

        public void Delete(int id)
        {
            var buildingMaterial = _dbContext.BuildingMaterials.FirstOrDefault(x => x.Id == id);
            if (buildingMaterial is null)
            {
                throw new NotFoundException("Material not found");
            }

            _dbContext.BuildingMaterials.Remove(buildingMaterial);
            _dbContext.SaveChanges();
        }

        public IEnumerable<BuildingMaterialDto> GetAll()
        {
            var buildingMaterials = _dbContext.BuildingMaterials.ToList();
            var buildingMaterialsDtos = _mapper.Map<List<BuildingMaterialDto>>(buildingMaterials);
            return buildingMaterialsDtos;
        }

        public BuildingMaterialDto GetById(int id)
        {
            var buildingMaterial = _dbContext.BuildingMaterials.FirstOrDefault(x => x.Id == id);

            if (buildingMaterial is null)
                throw new NotFoundException("Material not found");

            var buildingMaterialDto = _mapper.Map<BuildingMaterialDto>(buildingMaterial);

            return buildingMaterialDto;
        }

        public void Update(UpdateBuildingMaterialDto dto, int id)
        {
            var buildingMaterial = _dbContext.BuildingMaterials.FirstOrDefault(x => x.Id == id);
            if (buildingMaterial is null)
                throw new NotFoundException("Material not found");

            buildingMaterial.Id = id;
            buildingMaterial.Name = dto.Name;
            buildingMaterial.Description = dto.Description;
            buildingMaterial.Cw = dto.Cw;
            buildingMaterial.GammaSW = dto.GammaSW;
            buildingMaterial.GammaW = dto.GammaW;
            buildingMaterial.Ro = dto.Ro;

            _dbContext.SaveChanges();

        }
    }
}
