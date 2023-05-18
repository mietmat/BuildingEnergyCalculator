using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface IWindowService
    {
        Task<int> Create(CreateWindowDto dto);
        Task<IEnumerable<WindowDto>> GetAll();
        Task<WindowDto> GetById(int id);
        void Delete(int id);
        void Update(UpdateWindowDto dto, int id);
    }
}
