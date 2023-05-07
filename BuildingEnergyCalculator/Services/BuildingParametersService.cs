using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public class BuildingParametersService : IBuildingParametersService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;

        public BuildingParametersService(EnergyCalculatorDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(CreateBuildingParametersDto dto)
        {
            var buildingParameters = _mapper.Map<BuildingParameters>(dto);

            _dbContext.BuildingParameters.Add(buildingParameters);
            _dbContext.SaveChanges();

            return buildingParameters.Id;
        }

        public IEnumerable<BuildingParametersDto> GetAll()
        {
            var buildingParameters = _dbContext.BuildingParameters.ToList();
            var buildingParametersDtos = _mapper.Map<List<BuildingParametersDto>>(buildingParameters);
            return buildingParametersDtos;
        }
    }
}
