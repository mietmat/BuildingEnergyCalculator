using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface IBuildingParametersService
    {
        Task<int> Create(CreateBuildingParametersDto dto,int solutionId);
        Task<IEnumerable<BuildingParametersDto>> GetAll();
        Task<BuildingParametersDto> GetById(int id);
        Task<BuildingParametersDto> GetBySolutionId(int solutionId);
        void Delete(int id);
        void Update(UpdateBuildingParametersDto dto, int id);
    }
}
