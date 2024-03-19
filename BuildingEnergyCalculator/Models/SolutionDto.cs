using BuildingEnergyCalculator.Entities.Project;

namespace BuildingEnergyCalculator.Models
{
    public class SolutionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        //public EnergyDemand EnergyDemand { get; set; }
        //public OperatingCost OperatingCost { get; set; }
        //public InvestmentCost InvestmentCost { get; set; }

    }
}
