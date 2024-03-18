using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface IProjectModelService
    {
        Task<int> Create(CreateProjectModelDto dto);
        Task <IEnumerable<ProjectModelDto>> GetAll();
        Task <ProjectModelDto> GetById(int id);
        void Delete(int id);
        Task Update(UpdateProjectModelDto dto, int id);

    }
}
