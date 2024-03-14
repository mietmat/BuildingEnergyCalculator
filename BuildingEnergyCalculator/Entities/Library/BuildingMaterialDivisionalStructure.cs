using BuildingEnergyCalculator.Entities.Project;

namespace BuildingEnergyCalculator.Entities.Library
{
    public class BuildingMaterialDivisionalStructure
    {
        public int BuildingMaterialId { get; set; }
        public BuildingMaterial BuildingMaterial { get; set; }
        public int DivisionalStructureId { get; set; }
        public DivisionalStructure DivisionalStructure { get; set; }
    }
}
