﻿using BuildingEnergyCalculator.Entities.Project;

namespace BuildingEnergyCalculator.Models
{
    public class BuildingInformationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public Investor Investor { get; set; }
        public BuildingParameters BuildingParameters { get; set; }

    }
}
