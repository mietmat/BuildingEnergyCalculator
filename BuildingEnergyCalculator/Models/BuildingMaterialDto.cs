using BuildingEnergyCalculator.Entities;

namespace BuildingEnergyCalculator.Models
{
    public class BuildingMaterialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LambdaSW { get; set; }
        public double LambdaW { get; set; }
        public double Ro { get; set; }// Density [kg/m3]
        public double R { get; set; }//ThermalResistance m2K/W
        public double Cw { get; set; }
        public double Thickness { get; set; }
    }
}
