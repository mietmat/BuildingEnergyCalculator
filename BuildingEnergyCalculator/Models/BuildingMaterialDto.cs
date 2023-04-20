﻿using BuildingEnergyCalculator.Entities;

namespace BuildingEnergyCalculator.Models
{
    public class BuildingMaterialDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double GammaSW { get; set; }
        public double GammaW { get; set; }
        public double Ro { get; set; }
        public double Cw { get; set; }
        public double Thickness { get; set; }
    }
}
