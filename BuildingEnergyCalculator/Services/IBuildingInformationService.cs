using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface IBuildingInformationService
    {
        Task<int> Create(CreateBuildingInformationDto dto);
        Task <IEnumerable<BuildingInformationDto>> GetAll();
        Task <BuildingInformationDto> GetById(int id);
        void Delete(int id);
        void Update(UpdateBuildingInformationDto dto, int id);

    }
}
