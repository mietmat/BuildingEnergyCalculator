using BuildingEnergyCalculator.Entities.Project;
using System.ComponentModel.DataAnnotations;

namespace BuildingEnergyCalculator.Models
{
    public class CreateProjectModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Solution> Solutions { get; set; }
        //public EnergyDemand EnergyDemand { get; set; }
        //public OperatingCost OperatingCost { get; set; }
        //public InvestmentCost InvestmentCost { get; set; }

    }
}
