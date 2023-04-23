namespace BuildingEnergyCalculator.Entities
{
    public class BuildingMaterialDivisionalStructure
    {
        public int BuildingMaterialId { get; set; }
        public BuildingMaterial BuildingMaterial { get; set; }
        public int DivisionalStructureId { get; set; }
        public DivisionalStructure DivisionalStructure { get; set; }
    }
}
