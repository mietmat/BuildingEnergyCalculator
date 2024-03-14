using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Entities.Library;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Models;
using CalcServer.BuildingParameters;
using Microsoft.EntityFrameworkCore;

namespace BuildingEnergyCalculator.Services
{
    public class WindowService : IWindowService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICalculator _calculator;


        public WindowService(EnergyCalculatorDbContext dbContext, IMapper mapper, ICalculator calculator)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _calculator = calculator;
        }

        public async Task<int> Create(CreateWindowDto createWindowDto)
        {
            var window = _mapper.Map<Window>(createWindowDto);
            window.Perimeter = _calculator.CalculateRectanglePerimeter(createWindowDto.Height, createWindowDto.Width);
            window.SingleArea = _calculator.CalculateRectangleArea(createWindowDto.Height, createWindowDto.Width);


            await _dbContext.Windows.AddAsync(window);
            _dbContext.SaveChangesAsync();

            return window.Id;
        }

        public void Delete(int id)
        {
            var window = _dbContext.Windows.FirstOrDefault(x => x.Id == id);

            if (window is null)
            {
                throw new NotFoundException("Door not found");

            }
            _dbContext.Windows.Remove(window);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<WindowDto>> GetAll()
        {
            var windows = await _dbContext.Windows.ToListAsync();
            if (windows is null)
            {
                throw new NotFoundException("Windows not found");
            }
            var windowDto = _mapper.Map<List<WindowDto>>(windows);
            return windowDto;
        }

        public async Task<WindowDto> GetById(int id)
        {
            var window = await _dbContext.Windows.FirstOrDefaultAsync(x => x.Id == id);

            var windowDto = _mapper.Map<WindowDto>(window);

            return windowDto;
        }

        public void Update(UpdateWindowDto dto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
