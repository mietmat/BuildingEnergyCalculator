using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuildingEnergyCalculator.Entities
{
    public class BuildingMaterial
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double GammaSW { get; set; }
        public double GammaW { get; set; }
        public double Ro { get; set; }
        public double Cw { get; set; }
        public double Thickness { get; set; }
        public virtual List<DivisionalStructure> DivisionalStructures { get; set; }



    }
}
