using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Calculator
{
    public class BuildingMaterialCalc : IBuildingMaterialCalc
    {
        void IBuildingMaterialCalc.CalculateR(CreateBuildingMaterialDto buildingMaterialDto)
        {
            buildingMaterialDto.R = buildingMaterialDto.Thickness / buildingMaterialDto.LambdaSW;           
        }
    }
}
