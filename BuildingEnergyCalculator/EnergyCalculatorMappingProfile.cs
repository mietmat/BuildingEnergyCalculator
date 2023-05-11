using AutoMapper;
using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator
{
    public class EnergyCalculatorMappingProfile : Profile
    {
        public EnergyCalculatorMappingProfile()
        {
            CreateMap<BuildingMaterial, BuildingMaterialDto>().ReverseMap();
            CreateMap<BuildingMaterial, CreateBuildingMaterialDto>().ReverseMap();
            CreateMap<BuildingMaterial, UpdateBuildingMaterialDto>().ReverseMap();

            CreateMap<DivisionalStructure, CreateDivisionalStructureDto>().ReverseMap();
            CreateMap<DivisionalStructure, UpdateDivisionalStructureDto>().ReverseMap();
            CreateMap<DivisionalStructure, DivisionalStructureDto>().ReverseMap();

            CreateMap<BuildingParameters, CreateBuildingParametersDto>().ReverseMap();
            CreateMap<BuildingParameters, BuildingParametersDto>().ReverseMap();


            CreateMap<BuildingInformation, CreateBuildingInformationDto>().ReverseMap();
            CreateMap<BuildingInformation, BuildingInformationDto>().ReverseMap();





        }
    }
}
