using BuildingEnergyCalculator.Entities;

namespace BuildingEnergyCalculator.Models
{
    public class CreateInvestmentDto
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public string BuildingDescription { get; set; }
        public Address Address { get; set; }
        public Investor Investor { get; set; }
        public BuildingParameters BuildingParameters { get; set; }

    }
}
