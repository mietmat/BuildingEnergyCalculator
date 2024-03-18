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
    public class ProjectModelService : IProjectModelService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICalculator _calculator;
        private readonly DbContextOptions<EnergyCalculatorDbContext> _options;

        public ProjectModelService(
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

        public async Task<int> Create(CreateProjectModelDto dto)
        {
            var projectModel = _mapper.Map<ProjectModel>(dto);

            await _dbContext.ProjectModels.AddAsync(projectModel);
            _dbContext.SaveChanges();

            return projectModel.Id;
        }

        public void Delete(int id)
        {
            var itemToRemove = _dbContext.ProjectModels.FirstOrDefault(x => x.Id == id);
            _dbContext.ProjectModels.Remove(itemToRemove);

            if (itemToRemove is null)
            {
                throw new NotFoundException("project not found");
            }

            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<ProjectModelDto>> GetAll()
        {
            var projects = await _dbContext.ProjectModels.ToListAsync();


            if (projects is null)
            {
                throw new NotFoundException("Projects not found");
            }

            var projectsDtos = _mapper.Map<List<ProjectModelDto>>(projects);
            return projectsDtos;
        }

        public async Task<ProjectModelDto> GetById(int id)
        {
            var existingProject = new ProjectModel();
            using (var context = new EnergyCalculatorDbContext(_options))
            {
                existingProject = await context.ProjectModels
                         .FirstOrDefaultAsync(x => x.Id == id);
            }

            if (existingProject == null)
            {
                throw new NotFoundException("Project not found.");
            }

            var projectModelDto = _mapper.Map<ProjectModelDto>(existingProject);

            return projectModelDto;
        }

        public async Task Update(UpdateProjectModelDto dto, int id)
        {
            using (var context = new EnergyCalculatorDbContext(_options))
            {
                var project = await context.ProjectModels.FirstOrDefaultAsync(x => x.Id == id);
                if (project is null)
                    throw new NotFoundException("Project not found");

                project.Id = id;
                project.Name = dto.Name;

                await context.SaveChangesAsync();
            }

        }
    }
}
