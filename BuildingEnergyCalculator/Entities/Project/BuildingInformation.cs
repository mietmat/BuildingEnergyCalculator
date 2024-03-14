namespace BuildingEnergyCalculator.Entities.Project
{
    public class BuildingInformation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Address Address { get; set; }
        public Investor Investor { get; set; }
        public int? InvestorId { get; set; }
        public BuildingParameters? BuildingParameters { get; set; }
        public int? BuildingParametersId { get; set; }

    }
}
