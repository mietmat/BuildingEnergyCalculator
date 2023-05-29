using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface IFloorOnTheGroundService
    {
        Task<int> Create(CreateFloorOnTheGroundDto dto);
        Task <IEnumerable<FloorOnTheGroundDto>> GetAll();
        Task <FloorOnTheGroundDto> GetById(int id);
        void Delete(int id);
        void Update(UpdateFloorOnTheGroundDto dto, int id);

    }
}
