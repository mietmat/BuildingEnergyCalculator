﻿namespace BuildingEnergyCalculator.Entities
{
    public class Investment
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public string BuildingDescription { get; set; }

        public Address Address { get; set; }
        public Investor Investor { get; set; }
        public int? InvestorId { get; set; }
        public BuildingParameters BuildingParameters { get; set; }
        public int? BuildingParametersId { get; set; }

    }
}