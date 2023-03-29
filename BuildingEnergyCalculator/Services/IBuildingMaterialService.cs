using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface IBuildingMaterialService
    {
        int Create(CreateBuldingMaterialDto dto);
    }
}
