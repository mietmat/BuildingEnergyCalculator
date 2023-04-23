using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator
{
    public class EnergyCalculatorMappingProfile:Profile
    {
        public EnergyCalculatorMappingProfile()
        {
            CreateMap<BuildingMaterial, BuildingMaterialDto>().ReverseMap();
            CreateMap<BuildingMaterial, CreateBuldingMaterialDto>().ReverseMap();
            CreateMap<BuildingMaterial, UpdateBuildingMaterialDto>().ReverseMap();
            CreateMap<DivisionalStructure, CreateDivisionalStructureDto>().ReverseMap();
            CreateMap<DivisionalStructure, UpdateDivisionalStructureDto>().ReverseMap();
            CreateMap<DivisionalStructure, DivisionalStructureDto>().ReverseMap();
                


        }
    }
}
