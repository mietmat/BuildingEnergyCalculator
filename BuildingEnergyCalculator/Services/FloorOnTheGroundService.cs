using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuildingEnergyCalculator.Services
{
    public class FloorOnTheGroundService : IFloorOnTheGroundService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;


        public FloorOnTheGroundService(EnergyCalculatorDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> Create(CreateFloorOnTheGroundDto dto)
        {
            var floorOnTheGround = _mapper.Map<FloorOnTheGround>(dto);

            await _dbContext.FloorOnTheGround.AddAsync(floorOnTheGround);
            _dbContext.SaveChanges();

            return floorOnTheGround.Id;
        }

        public void Delete(int id)
        {
            var itemToRemove = _dbContext.FloorOnTheGround.FirstOrDefault(x => x.Id == id);
            _dbContext.FloorOnTheGround.Remove(itemToRemove);

            if (itemToRemove is null)
            {
                throw new NotFoundException("FloorOnTheGround not found");
            }

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<FloorOnTheGroundDto>> GetAll()
        {
            var floorOnTheGround = await _dbContext.FloorOnTheGround                
                .ToListAsync();

            if (floorOnTheGround is null)
            {
                throw new NotFoundException("Floor On The Ground not found");
            }

            var floorOnTheGroundDtos = _mapper.Map<List<FloorOnTheGroundDto>>(floorOnTheGround);
            return floorOnTheGroundDtos;
        }

        public async Task<FloorOnTheGroundDto> GetById(int id)
        {
            var existingFloorOnTheGround = await _dbContext.FloorOnTheGround                
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingFloorOnTheGround is null)
            {
                throw new NotFoundException("FloorOnTheGround not found.");
            }

            var existingFloorOnTheGroundDto = _mapper.Map<FloorOnTheGroundDto>(existingFloorOnTheGround);

            return existingFloorOnTheGroundDto;
        }

        public void Update(UpdateFloorOnTheGroundDto dto, int id)
        {
            var floorOnTheGround = _dbContext.FloorOnTheGround.FirstOrDefault(x => x.Id == id);
            if (floorOnTheGround is null)
                throw new NotFoundException("FloorOnTheGround not found");           

            _dbContext.SaveChanges();
        }

    }
}
