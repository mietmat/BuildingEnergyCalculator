using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Calculator
{
    public interface IDivisionalStructureCalc
    {
        double CalculateThickness(List<BuildingMaterialDto> buildingMaterials);
        double CalculateU(double rSum);
        double CalculateRSum(CreateDivisionalStructureDto dto, List<BuildingMaterialDto> buildingMaterialDto);

    }
}
