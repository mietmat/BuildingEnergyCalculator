using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Entities.Library;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Models;
using CalcServer.BuildingParameters;

namespace BuildingEnergyCalculator.Services
{
    public class BuildingMaterialService : IBuildingMaterialService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICalculator _calculator;

        public BuildingMaterialService(EnergyCalculatorDbContext dbContext,
            IMapper mapper, ICalculator calculator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _calculator = calculator;
        }
        public int Create(CreateBuildingMaterialDto dto)
        {
            var r = _calculator.CalculateR(dto.Thickness, dto.LambdaSW);

            dto.R = r;
            var buildingMaterial = _mapper.Map<BuildingMaterial>(dto);
            _dbContext.BuildingMaterials.Add(buildingMaterial);
            _dbContext.SaveChanges();

            return default;
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

        public BuildingMaterialDto Update(UpdateBuildingMaterialDto dto, int id)
        {
            var buildingMaterial = _dbContext.BuildingMaterials.FirstOrDefault(x => x.Id == id);
            if (buildingMaterial is null)
                throw new NotFoundException("Material not found");

            buildingMaterial.Id = id;
            buildingMaterial.Name = dto.Name;
            buildingMaterial.Description = dto.Description;
            buildingMaterial.Cw = dto.Cw;
            buildingMaterial.LambdaSW = dto.LambdaSW;
            buildingMaterial.LambdaW = dto.LambdaW;
            buildingMaterial.Ro = dto.Ro;
            buildingMaterial.Thickness = dto.Thickness;

            _dbContext.SaveChanges();
            var buildingMaterialDto = _mapper.Map<BuildingMaterialDto>(buildingMaterial);


            return buildingMaterialDto;

        }
    }
}
