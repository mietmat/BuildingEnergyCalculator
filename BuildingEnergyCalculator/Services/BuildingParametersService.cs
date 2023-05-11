using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<int> Create(CreateBuildingParametersDto dto)
        {
            var buildingParameters = _mapper.Map<BuildingParameters>(dto);

            await _dbContext.BuildingParameters.AddAsync(buildingParameters);
            _dbContext.SaveChanges();

            return buildingParameters.Id;
        }

        public void Delete(int id)
        {
            var itemToRemove = _dbContext.BuildingParameters.FirstOrDefault(x => x.Id == id);
            _dbContext.BuildingParameters.Remove(itemToRemove);

            if (itemToRemove is null)
            {
                throw new NotFoundException("Investment not found");
            }

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<BuildingParametersDto>> GetAll()
        {
            var buildingParameters = await _dbContext.BuildingParameters.ToListAsync();

            if (buildingParameters is null)
            {
                throw new NotFoundException("BuildingParameter not found");
            }

            var buildingParametersDtos = _mapper.Map<List<BuildingParametersDto>>(buildingParameters);
            return buildingParametersDtos;
        }

        public async Task<BuildingParametersDto> GetById(int id)
        {
            var existingBuildingParameters = await _dbContext.BuildingInformation.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBuildingParameters is null)
            {
                throw new NotFoundException("Investment not found.");
            }

            var existingBuildingParametersDto = _mapper.Map<BuildingParametersDto>(existingBuildingParameters);

            return existingBuildingParametersDto;
        }

        public void Update(UpdateBuildingParametersDto dto, int id)
        {
            var buildingParameters = _dbContext.BuildingParameters.FirstOrDefault(x => x.Id == id);
            if (buildingParameters is null)
                throw new NotFoundException("Investment not found");

            buildingParameters.Id = id;
            buildingParameters.BalconyLength = dto.BalconyLength;
            buildingParameters.BuildingArea = dto.BuildingArea;
            buildingParameters.BuildingLengthE = dto.BuildingLengthE;
            buildingParameters.BuildingLengthS = dto.BuildingLengthS;
            buildingParameters.BuildingLengthW = dto.BuildingLengthW;
            buildingParameters.BuildingLengthN = dto.BuildingLengthN;
            buildingParameters.AtticUsableArea = dto.AtticUsableArea;
            buildingParameters.CellarHeight = dto.CellarHeight;
            buildingParameters.DoorsZoneI = dto.DoorsZoneI;
            buildingParameters.HeatAtticArea = dto.HeatAtticArea;
            buildingParameters.PerimiterOfTheBuilding = dto.PerimiterOfTheBuilding;
            buildingParameters.StaircaseSurface = dto.StaircaseSurface;
            buildingParameters.StaircaseWidth = dto.StaircaseWidth;
            buildingParameters.StoreyHeightGross = dto.StoreyHeightGross;
            buildingParameters.StoreyHeightNet = dto.StoreyHeightNet;
            buildingParameters.StoreyQuantity = dto.StoreyQuantity;
            buildingParameters.TotalDoorAreaE = dto.TotalDoorAreaE;
            buildingParameters.TotalDoorAreaN = dto.TotalDoorAreaN;
            buildingParameters.TotalDoorAreaS = dto.TotalDoorAreaS;
            buildingParameters.TotalDoorAreaW = dto.TotalDoorAreaW;
            buildingParameters.TotalWindowAreaE = dto.TotalWindowAreaE;
            buildingParameters.TotalWindowAreaN = dto.TotalWindowAreaN;
            buildingParameters.TotalWindowAreaS = dto.TotalWindowAreaS;
            buildingParameters.TotalWindowAreaW = dto.TotalWindowAreaW;
            buildingParameters.PerimiterOfTheBuilding = dto.PerimiterOfTheBuilding;
            buildingParameters.StaircaseSurface = dto.StaircaseSurface;
            buildingParameters.StaircaseWidth = dto.StaircaseWidth;
            buildingParameters.UnheatedAtticArea = dto.UnheatedAtticArea;
            buildingParameters.UsableAreaOfTheBuilding = dto.UsableAreaOfTheBuilding;
            buildingParameters.UsableAreaOfTheStairCase = dto.UsableAreaOfTheStairCase;
            buildingParameters.WindowsZoneI = dto.WindowsZoneI;

            _dbContext.SaveChanges();
        }
    }
}
