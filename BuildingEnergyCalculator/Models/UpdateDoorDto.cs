namespace BuildingEnergyCalculator.Models
{
    public class UpdateDoorDto
    {
        public int Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Perimiter { get; set; }
        public int Quantity { get; set; }
        public double SingleArea { get; set; }
        public double U { get; set; }
        public string cardinalDirection { get; set; }
        public int Floor { get; set; }
    }
}
