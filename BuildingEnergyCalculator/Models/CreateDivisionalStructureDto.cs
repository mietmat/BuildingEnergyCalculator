﻿using BuildingEnergyCalculator.Entities;

namespace BuildingEnergyCalculator.Models
{
    public class CreateDivisionalStructureDto
    {
        public string Description { get; set; }
        public double DivisionalThickness { get; set; }// m
        public double λ { get; set; }//ThermalConductivity W/mK
        public double R { get; set; }//ThermalResistance m2K/W
        public double U { get; set; }//HeatTransferCoefficient W/m2K
        public double Rsi { get; set; }// m2K/W
        public double Rse { get; set; }// m2K/W
        public int Building { get; set; }
        public virtual List<BuildingMaterial> BuildingMaterials { get; set; }


    }
}
