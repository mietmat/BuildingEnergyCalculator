using BuildingEnergyCalculator.Entities.Project;
using System.ComponentModel.DataAnnotations;

namespace BuildingEnergyCalculator.Models
{
    public class CreateBuildingInformationDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public Investor Investor { get; set; }
        //public BuildingParameters BuildingParameters { get; set; }

    }
}
