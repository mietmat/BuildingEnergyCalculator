using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Calculator
{
    public class BuildingMaterialCalc : IBuildingMaterialCalc
    {
        void IBuildingMaterialCalc.CalculateR(CreateBuldingMaterialDto buildingMaterialDto)
        {
            buildingMaterialDto.R = buildingMaterialDto.Thickness / buildingMaterialDto.LambdaSW;           
        }
    }
}
