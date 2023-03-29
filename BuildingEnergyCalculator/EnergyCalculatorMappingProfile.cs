using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator
{
    public class EnergyCalculatorMappingProfile:Profile
    {
        public EnergyCalculatorMappingProfile()
        {
            CreateMap<CreateBuldingMaterialDto, BuildingMaterial>();
           
        }
    }
}
