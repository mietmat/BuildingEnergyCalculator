using BuildingEnergyCalculator.Entities.Library;

namespace BuildingEnergyCalculator.Models
{
    public class BuildingParametersDto
    {
        public int Id { get; set; }
        //public string BuildingName { get; set; }
        //public string BuildingDescription { get; set; }
        public double BuildingLengthN { get; set; }
        public double BuildingLengthE { get; set; }
        public double BuildingLengthS { get; set; }
        public double BuildingLengthW { get; set; }
        public double StoreyHeightNet { get; set; }
        public double StoreyHeightGross { get; set; }
        public double CellarHeight { get; set; }
        public int StoreyQuantity { get; set; } //only for storeys where you have penetration into heated rooms
        public double BuildingArea { get; set; }
        public double StaircaseSurface { get; set; }
        public double UsableAreaOfTheStairCase { get; set; }
        public double StaircaseWidth { get; set; }
        public double HeatAtticArea { get; set; }
        public double UnheatedAtticArea { get; set; }
        public double UsableAreaOfTheBuilding { get; set; }
        public double AtticUsableArea { get; set; }
        public double PerimiterOfTheBuilding { get; set; }
        public double BalconyLength { get; set; }
        public double TotalWindowAreaN { get; set; }
        public double TotalWindowAreaE { get; set; }
        public double TotalWindowAreaS { get; set; }
        public double TotalWindowAreaW { get; set; }
        public double TotalDoorAreaN { get; set; }
        public double TotalDoorAreaE { get; set; }
        public double TotalDoorAreaS { get; set; }
        public double TotalDoorAreaW { get; set; }
        public List<Window> WindowsZoneI { get; set; }
        public List<Door> DoorsZoneI { get; set; }
        public List<Window> WindowsZoneII { get; set; }
        public List<Door> DoorsZoneII { get; set; }
    }
}
