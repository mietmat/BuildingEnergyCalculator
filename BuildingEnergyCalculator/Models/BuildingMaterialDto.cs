namespace BuildingEnergyCalculator.Models
{
    public class BuildingMaterialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double GammaSW { get; set; }
        public double GammaW { get; set; }
        public double Ro { get; set; }
        public double Cw { get; set; }
    }
}
