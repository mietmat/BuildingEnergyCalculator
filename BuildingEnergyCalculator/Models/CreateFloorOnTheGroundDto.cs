using BuildingEnergyCalculator.Entities;
using System.ComponentModel.DataAnnotations;

namespace BuildingEnergyCalculator.Models
{
    public class CreateFloorOnTheGroundDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Ag { get; set; }
        public double P { get; set; }
        public double B { get; set; }
        public string GroundMaterial { get; set; }
        public double λgr { get; set; }
        public double w { get; set; }
        public double df { get; set; }
        public double λf { get; set; }
        public double Rf { get; set; }
        public double dt { get; set; }
        public double Ugr { get; set; }

    }
}
