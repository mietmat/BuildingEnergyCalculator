using BuildingEnergyCalculator.Entities;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace BuildingEnergyCalculator.Models
{
    public class UpdateBuildingMaterialDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double GammaSW { get; set; }
        public double GammaW { get; set; }
        public double Ro { get; set; }
        public double Cw { get; set; }
        public int DivisionalStructureId { get; set; }
        public double Thickness { get; set; }


    }
}
