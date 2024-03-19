using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface ISolutionService
    {
        Task<int> Create(CreateSolutionDto dto);
        Task<IEnumerable<SolutionDto>> GetAll();
        Task<IEnumerable<SolutionDto>> GetByProjectId(int projectId);
        Task<SolutionDto> GetById(int id);
        void Delete(int id);
        Task Update(UpdateSolutionDto dto, int id);

    }
}
