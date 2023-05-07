using BuildingEnergyCalculator.Enums;

namespace BuildingEnergyCalculator.Entities
{
    public abstract class BuildingHole
    {
        public int Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Perimiter { get; set; }
        public int Quantity { get; set; }
        public double Area { get; set; }
        public double U { get; set; }
        public double λ { get; set; }

        public CardinalDirection CardinalDirection { get; set; }
        public string Floor { get; set; }
    }
}
