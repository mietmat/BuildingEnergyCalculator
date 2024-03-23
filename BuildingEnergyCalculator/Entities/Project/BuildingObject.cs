namespace BuildingEnergyCalculator.Entities.Project
{
    public class BuildingObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BuildingInformation BuildingInformation { get; set; }
        public DivisionalStructure DivisionalStructure { get; set; }
        public int BuildingParametersId { get; set; }
        public FloorOnTheGround FloorOnTheGround { get; set; }
    }
}
