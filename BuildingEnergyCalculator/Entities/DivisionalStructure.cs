
namespace BuildingEnergyCalculator.Entities
{
    public class DivisionalStructure
    {
        public string Description { get; set; }
        public List<BuildingMaterial> BuildingMaterials { get; set; }
        public double LayerThickness { get; set; }// m
        public double DivisionalThickness { get; set; }// m
        public double λ { get; set; }//ThermalConductivity W/mK
        public double R { get; set; }//ThermalResistance m2K/W
        public double U { get; set; }//HeatTransferCoefficient W/m2K
        public double Rsi { get; set; }// m2K/W
        public double Rse { get; set; }// m2K/W


    }
}
