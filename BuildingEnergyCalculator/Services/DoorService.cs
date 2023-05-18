using AutoMapper;
using BuildingEnergyCalculator.Calculator;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BuildingEnergyCalculator.Services
{
    public class DoorService : IDoorService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICalculator _calculator;


        public DoorService(EnergyCalculatorDbContext dbContext, IMapper mapper, ICalculator calculator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _calculator = calculator;
        }

        public async Task<int> Create(CreateDoorDto createDoorDto)
        {

            var door = _mapper.Map<Door>(createDoorDto);
            door.Perimeter = _calculator.CalculateRectanglePerimeter(createDoorDto.Height, createDoorDto.Width);
            door.SingleArea = _calculator.CalculateRectangleArea(createDoorDto.Height, createDoorDto.Width);

            await _dbContext.Doors.AddAsync(door);
            _dbContext.SaveChangesAsync();

            return door.Id;

        }

        public void Delete(int id)
        {
            var door = _dbContext.Doors.FirstOrDefault(x => x.Id == id);

            if (door is null)
            {
                throw new NotFoundException("Door not found");

            }
            _dbContext.Doors.Remove(door);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<DoorDto>> GetAll()
        {
            var doors = await _dbContext.Doors.ToListAsync();
            if (doors is null)
            {
                throw new NotFoundException("Doors not found");
            }
            var doorsDto = _mapper.Map<List<DoorDto>>(doors);
            return doorsDto;
        }

        public async Task<DoorDto> GetById(int id)
        {
            var door = await _dbContext.Doors.FirstOrDefaultAsync(x => x.Id == id);

            var doorDto = _mapper.Map<DoorDto>(door);

            return doorDto;
        }

        public void Update(UpdateDoorDto dto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
