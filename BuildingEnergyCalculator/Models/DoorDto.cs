using BuildingEnergyCalculator.Enums;

namespace BuildingEnergyCalculator.Models
{
    public class DoorDto
    {
        public int Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Perimeter { get; set; }
        public int Quantity { get; set; }
        public double SingleArea { get; set; }
        public double U { get; set; }

        public string cardinalDirection { get; set; }
        public int Floor { get; set; }
    }
}
