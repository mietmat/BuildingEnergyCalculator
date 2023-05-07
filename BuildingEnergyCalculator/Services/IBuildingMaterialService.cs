using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface IBuildingMaterialService
    {
        int Create(CreateBuildingMaterialDto dto);
        IEnumerable<BuildingMaterialDto> GetAll();
        BuildingMaterialDto GetById(int id);
        void Delete(int id);
        BuildingMaterialDto Update(UpdateBuildingMaterialDto dto,int id);
    }
}
