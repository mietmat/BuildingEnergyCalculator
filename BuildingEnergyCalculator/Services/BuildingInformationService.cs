using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuildingEnergyCalculator.Services
{
    public class BuildingInformationService : IBuildingInformationService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;


        public BuildingInformationService(EnergyCalculatorDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Create(CreateBuildingInformationDto dto)
        {
            var buildingInformation = _mapper.Map<BuildingInformation>(dto);

            await _dbContext.BuildingInformation.AddAsync(buildingInformation);
            _dbContext.SaveChanges();

            return buildingInformation.Id;
        }

        public void Delete(int id)
        {
            var itemToRemove = _dbContext.BuildingInformation.FirstOrDefault(x => x.Id == id);
            _dbContext.BuildingInformation.Remove(itemToRemove);

            if (itemToRemove is null)
            {
                throw new NotFoundException("Investment not found");
            }

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<BuildingInformationDto>> GetAll()
        {
            var buildingInformations = await _dbContext.BuildingInformation
                .Include(b => b.Investor)
                .Include(b => b.Investor.Address)
                .Include(b => b.Address)
                .Include(b => b.BuildingParameters)
                .ToListAsync();

            if (buildingInformations is null)
            {
                throw new NotFoundException("Building informations not found");
            }

            var buildingInformationsDtos = _mapper.Map<List<BuildingInformationDto>>(buildingInformations);
            return buildingInformationsDtos;
        }

        public async Task<BuildingInformationDto> GetById(int id)
        {
            var existingBuildingInformation = await _dbContext.BuildingInformation
                .Include(b => b.Address)
                .Include(b => b.Investor)
                .Include(b => b.BuildingParameters)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingBuildingInformation is null)
            {
                throw new NotFoundException("Investment not found.");
            }

            var existingInvestmentDto = _mapper.Map<BuildingInformationDto>(existingBuildingInformation);

            return existingInvestmentDto;
        }

        public void Update(UpdateBuildingInformationDto dto, int id)
        {
            var investment = _dbContext.BuildingInformation.FirstOrDefault(x => x.Id == id);
            if (investment is null)
                throw new NotFoundException("Investment not found");

            investment.Id = id;
            investment.Address = dto.Address;
            investment.BuildingParameters = dto.BuildingParameters;
            investment.Description = dto.Description;
            investment.Name = dto.Name;
            investment.Investor = dto.Investor;


            _dbContext.SaveChanges();
        }

    }
}
