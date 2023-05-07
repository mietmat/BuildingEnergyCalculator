using BuildingEnergyCalculator.Entities;

namespace BuildingEnergyCalculator.Models
{
    public class CreateDivisionalStructureDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<CreateBuildingMaterialDto> BuildingMaterials { get; set; }
        public double DivisionalThickness { get; set; }// m
        public double RSum { get; set; }//ThermalResistance m2K/W
        public double U { get; set; }//HeatTransferCoefficient W/m2K
        public double Rsi { get; set; }// m2K/W
        public double Rse { get; set; }// m2K/W


    }
}
