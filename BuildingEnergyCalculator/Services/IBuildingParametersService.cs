using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface IBuildingParametersService
    {
        int Create(CreateBuildingParametersDto dto);
        IEnumerable<BuildingParametersDto> GetAll();
        //DivisionalStructureDto GetById(int id);
        //void Delete(int id);
        //void Update(UpdateDivisionalStructureDto dto, int id);
    }
}
