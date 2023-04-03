using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface IDivisionalStructureService
    {
        int Create(CreateDivisionalStructureDto dto);
        IEnumerable<DivisionalStructureDto> GetAll();
        DivisionalStructureDto GetById(int id);
        void Delete(int id);
        void Update(UpdateDivisionalStructureDto dto, int id);
    }
}
