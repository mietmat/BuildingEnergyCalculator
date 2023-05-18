using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface IDoorService
    {
        Task<int> Create(CreateDoorDto dto);
        Task<IEnumerable<DoorDto>> GetAll();
        Task<DoorDto> GetById(int id);
        void Delete(int id);
        void Update(UpdateDoorDto dto, int id);
    }
}
