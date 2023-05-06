using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Calculator
{
    public interface IDivisionalStructureCalc
    {
        double CalculateThickness(List<CreateBuildingMaterialDto> buildingMaterials);
        double CalculateU(double rSum);
        double CalculateRSum(CreateDivisionalStructureDto dto, List<CreateBuildingMaterialDto> buildingMaterialDto);

    }
}
