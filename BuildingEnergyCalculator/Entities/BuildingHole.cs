using BuildingEnergyCalculator.Enums;

namespace BuildingEnergyCalculator.Entities
{
    public abstract class BuildingHole
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Perimeter { get; set; }
        public int Quantity { get; set; }
        public double SingleArea { get; set; }
        public double U { get; set; }
        public string CardinalDirection { get; set; }
        public int Floor { get; set; }
    }
}
