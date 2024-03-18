using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Entities.Library;
using BuildingEnergyCalculator.Entities.Project;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Models;
using CalcServer.BuildingParameters;
using Microsoft.EntityFrameworkCore;

namespace BuildingEnergyCalculator.Services
{
    public class SolutionService : ISolutionService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICalculator _calculator;
        private readonly DbContextOptions<EnergyCalculatorDbContext> _options;


        public SolutionService(
            EnergyCalculatorDbContext dbContext,
            IMapper mapper,
            ICalculator calculator,
            DbContextOptions<EnergyCalculatorDbContext> options)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _calculator = calculator;
            _options = options;
        }

        public async Task<int> Create(CreateSolutionDto dto)
        {
            var solutionModel = _mapper.Map<Solution>(dto);

            await _dbContext.Solutions.AddAsync(solutionModel);
            _dbContext.SaveChanges();

            return solutionModel.Id;
        }

        public void Delete(int id)
        {
            var itemToRemove = _dbContext.Solutions.FirstOrDefault(x => x.Id == id);
            _dbContext.Solutions.Remove(itemToRemove);

            if (itemToRemove is null)
            {
                throw new NotFoundException("solution not found");
            }

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<SolutionDto>> GetAll()
        {
            var solutions = await _dbContext.Solutions.ToListAsync();

            if (solutions is null)
            {
                throw new NotFoundException("Solutions not found");
            }

            var solutionsDtos = _mapper.Map<List<SolutionDto>>(solutions);
            return solutionsDtos;
        }

        public async Task<IEnumerable<SolutionDto>> GetByProjectId(int projectId)
        {
            var solutions = await _dbContext.Solutions.Where(x => x.ProjectId == projectId).ToListAsync();

            if (solutions is null)
            {
                throw new NotFoundException("Solutions not found");
            }

            var solutionsDtos = _mapper.Map<List<SolutionDto>>(solutions);
            return solutionsDtos;
        }

        public async Task<SolutionDto> GetById(int id)
        {
            using (var context = new EnergyCalculatorDbContext(_options))
            {
                var existingSolutions = await context.Solutions
                           .FirstOrDefaultAsync(x => x.ProjectId == id);

                var solutionDto = _mapper.Map<SolutionDto>(existingSolutions);

                return solutionDto;
            }
        }

        public async Task Update(UpdateSolutionDto dto, int id)
        {
            using (var context = new EnergyCalculatorDbContext(_options))
            {
                var solution = await context.Solutions.FirstOrDefaultAsync(x => x.Id == id);
                if (solution is null)
                    throw new NotFoundException("Solution not found");

                solution.Id = id;
                solution.Name = dto.Name;

                await context.SaveChangesAsync();
            }

        }
    }
}
