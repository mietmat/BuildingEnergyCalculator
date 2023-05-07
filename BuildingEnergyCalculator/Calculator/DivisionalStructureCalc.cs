using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Calculator
{
    public class DivisionalStructureCalc : IDivisionalStructureCalc
    {
        private double Thickness { get; set; } = 0;
        private double RSum { get; set; }//ThermalResistance m2K/W


        public double CalculateRSum(CreateDivisionalStructureDto divisionalStructureDto, List<CreateBuildingMaterialDto> buildingMaterialDto)
        {
            foreach (var material in buildingMaterialDto)
            {
                RSum += material.R;
            }
            RSum += divisionalStructureDto.Rsi;
            RSum += divisionalStructureDto.Rse;

            return Math.Round(RSum,2);
        }

        public double CalculateThickness(List<CreateBuildingMaterialDto> buildingMaterials)
        {
            foreach (var buildingMaterial in buildingMaterials)
            {
                Thickness += buildingMaterial.Thickness;
            }

            return Thickness;
        }

        public double CalculateU(double rSum)
        {
            var u = 1 / rSum;
            return Math.Round(u,2);

        }
    }
}
