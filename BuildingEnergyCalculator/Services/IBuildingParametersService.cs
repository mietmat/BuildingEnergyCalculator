using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface IBuildingParametersService
    {
        Task<int> Create(CreateBuildingParametersDto dto);
        Task<IEnumerable<BuildingParametersDto>> GetAll();
        Task<BuildingParametersDto> GetById(int id);
        void Delete(int id);
        void Update(UpdateBuildingParametersDto dto, int id);
    }
}
