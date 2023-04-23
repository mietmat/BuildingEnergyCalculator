using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Calculator
{
    public interface IBuildingMaterialCalc
    {
        void CalculateR(CreateBuldingMaterialDto buildingMaterialDto);
       
    }
}
