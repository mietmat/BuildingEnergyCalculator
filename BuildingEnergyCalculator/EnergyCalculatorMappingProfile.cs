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

            CreateMap<Door, CreateDoorDto>().ReverseMap();
            CreateMap<Door, DoorDto>().ReverseMap();
            CreateMap<Door, UpdateDoorDto>().ReverseMap();

            CreateMap<Window, CreateWindowDto>().ReverseMap();
            CreateMap<Window, WindowDto>().ReverseMap();
            CreateMap<Window, UpdateWindowDto>().ReverseMap();

            
            CreateMap<FloorOnTheGround, CreateFloorOnTheGroundDto>().ReverseMap();
            CreateMap<FloorOnTheGround, FloorOnTheGroundDto>().ReverseMap();
            CreateMap<FloorOnTheGround, UpdateFloorOnTheGroundDto>().ReverseMap();






        }
    }
}
