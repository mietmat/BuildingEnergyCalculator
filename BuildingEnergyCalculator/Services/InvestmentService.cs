using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuildingEnergyCalculator.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;


        public InvestmentService(EnergyCalculatorDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Create(CreateInvestmentDto dto)
        {
            var investment = _mapper.Map<Investment>(dto);

            await _dbContext.Investments.AddAsync(investment);
            _dbContext.SaveChanges();

            return investment.Id;
        }

        public void Delete(int id)
        {
            var itemToRemove = _dbContext.Investments.FirstOrDefault(x => x.Id == id);
            _dbContext.Investments.Remove(itemToRemove);

            if (itemToRemove is null)
            {
                throw new NotFoundException("Investment not found");
            }

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<InvestmentDto>> GetAll()
        {
            var investments = await _dbContext.Investments.ToListAsync();
            var investmentsDtos = _mapper.Map<IEnumerable<InvestmentDto>>(investments);
            return investmentsDtos;
        }

        public async Task<InvestmentDto> GetById(int id)
        {
            var existingInvestment = await _dbContext.Investments.FirstOrDefaultAsync(x => x.Id == id);

            if (existingInvestment is null)
            {
                throw new NotFoundException("Investment not found.");
            }

            var existingInvestmentDto = _mapper.Map<InvestmentDto>(existingInvestment);

            return existingInvestmentDto;
        }

        public void Update(UpdateInvestmentDto dto, int id)
        {
            var investment = _dbContext.Investments.FirstOrDefault(x => x.Id == id);
            if (investment is null)
                throw new NotFoundException("Investment not found");

            investment.Id = id;
            investment.Address = dto.Address;
            investment.BuildingParameters = dto.BuildingParameters;
            investment.BuildingDescription = dto.BuildingDescription;
            investment.BuildingName = dto.BuildingName;
            investment.Investor = dto.Investor;


            _dbContext.SaveChanges();
        }

    }
}
