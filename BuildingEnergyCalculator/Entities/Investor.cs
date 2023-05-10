namespace BuildingEnergyCalculator.Entities
{
    public class Investor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        //public List<Investment> Investments { get; set; }
    }
}
