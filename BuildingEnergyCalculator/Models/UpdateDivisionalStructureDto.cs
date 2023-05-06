﻿using BuildingEnergyCalculator.Entities;

namespace BuildingEnergyCalculator.Models
{
    public class UpdateDivisionalStructureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<BuildingMaterialDto> BuildingMaterials { get; set; }
        public double RSum { get; set; }//ThermalResistance m2K/W
        public double U { get; set; }//HeatTransferCoefficient W/m2K
        public double Rsi { get; set; }// m2K/W
        public double Rse { get; set; }// m2K/W
    }
}
