namespace BuildingEnergyCalculator.Entities.Library
{
    public class KNR
    {
        public int Id { get; set; }
        public string KNRNo { get; set; }
        public string KNRName { get; set; }
        public string TableNo { get; set; }
        public string Topic { get; set; }
        public List<Occupation> OccupationList { get; set; }
        public List<Labor> LaborList { get; set; }
        public List<KNRMachine> MachineList { get; set; }
        public List<KNRMaterial> MaterialList { get; set; }
    }
}
