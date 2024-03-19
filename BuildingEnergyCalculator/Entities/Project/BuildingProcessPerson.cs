using BuildingEnergyCalculator.Enums;

namespace BuildingEnergyCalculator.Entities.Project
{
    public class BuildingProcessPerson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Occupation Occupation { get; set; }
        public int ProjectId { get; set; }
    }
}
