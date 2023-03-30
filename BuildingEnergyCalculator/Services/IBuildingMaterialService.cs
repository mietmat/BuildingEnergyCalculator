using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface IBuildingMaterialService
    {
        int Create(CreateBuldingMaterialDto dto);
        IEnumerable<BuildingMaterialDto> GetAll();
        BuildingMaterialDto GetById(int id);
        void Delete(int id);
        void Update(UpdateBuildingMaterialDto dto,int id);
    }
}
