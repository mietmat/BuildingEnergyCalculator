namespace BuildingEnergyCalculator.Entities.Project
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BuildingObject? BuildingObject { get; set; }
        //public EnergyDemand EnergyDemand { get; set; }
        //public OperatingCost OperatingCost { get; set; }
        //public InvestmentCost InvestmentCost { get; set; }
    }
}
