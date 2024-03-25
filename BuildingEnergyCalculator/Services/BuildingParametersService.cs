using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Entities.Project;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Migrations;
using BuildingEnergyCalculator.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildingEnergyCalculator.Services
{
    public class BuildingParametersService : IBuildingParametersService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly DbContextOptions<EnergyCalculatorDbContext> _options;


        public BuildingParametersService(EnergyCalculatorDbContext dbContext, IMapper mapper, DbContextOptions<EnergyCalculatorDbContext> options)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _options = options;
        }

        public async Task<int> Create(CreateBuildingParametersDto dto, int solutionId)
        {
            dto.SolutionId = solutionId;
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
        public async Task<BuildingParametersDto> GetBySolutionId(int solutionId)
        {
            using (var context = new EnergyCalculatorDbContext(_options))
            {
                var existingBuildingParameters = await _dbContext.BuildingParameters.FirstOrDefaultAsync(x => x.SolutionId == solutionId);

                //if (existingBuildingParameters is null)
                //{
                //    throw new NotFoundException($"Building parameters for solutionId = {solutionId} not found.");
                //}

                var existingBuildingParametersDto = _mapper.Map<BuildingParametersDto>(existingBuildingParameters);
                return existingBuildingParametersDto;
            }
        }

        public async Task Update(UpdateBuildingParametersDto dto, int solutionId)
        {
            using (var context = new EnergyCalculatorDbContext(_options))
            {
                var buildingParameters = await context.BuildingParameters.FirstOrDefaultAsync(x => x.SolutionId == solutionId);
                if (buildingParameters is null)
                    throw new NotFoundException("Investment not found");

                buildingParameters.BalconyLength = dto.BalconyLength;
                buildingParameters.BuildingArea = dto.BuildingArea;
                buildingParameters.BuildingLengthE = dto.BuildingLengthE;
                buildingParameters.BuildingLengthS = dto.BuildingLengthS;
                buildingParameters.BuildingLengthW = dto.BuildingLengthW;
                buildingParameters.BuildingLengthN = dto.BuildingLengthN;
                buildingParameters.AtticUsableArea = dto.AtticUsableArea;
                buildingParameters.CellarHeight = dto.CellarHeight;
                buildingParameters.HeatAtticArea = dto.HeatAtticArea;
                buildingParameters.PerimeterOfTheBuilding = dto.PerimeterOfTheBuilding;
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
                buildingParameters.PerimeterOfTheBuilding = dto.PerimeterOfTheBuilding;
                buildingParameters.StaircaseSurface = dto.StaircaseSurface;
                buildingParameters.StaircaseWidth = dto.StaircaseWidth;
                buildingParameters.UnheatedAtticArea = dto.UnheatedAtticArea;
                buildingParameters.UsableAreaOfTheBuilding = dto.UsableAreaOfTheBuilding;
                buildingParameters.UsableAreaOfTheStairCase = dto.UsableAreaOfTheStairCase;

                await context.SaveChangesAsync();

            }


        }
    }
}
