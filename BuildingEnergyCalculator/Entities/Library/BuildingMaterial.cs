using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BuildingEnergyCalculator.Entities.Project;

namespace BuildingEnergyCalculator.Entities.Library
{
    public class BuildingMaterial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LambdaSW { get; set; }
        public double LambdaW { get; set; }
        public double λ { get; set; }//ThermalConductivity W/mK
        public double Ro { get; set; }// Density [kg/m3]
        public double R { get; set; }//ThermalResistance m2K/W
        public double Cw { get; set; }
        public double Thickness { get; set; }
        public virtual List<DivisionalStructure> DivisionalStructures { get; set; }



    }
}
