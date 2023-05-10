using BuildingEnergyCalculator.Models;

namespace BuildingEnergyCalculator.Services
{
    public interface IInvestmentService
    {
        Task<int> Create(CreateInvestmentDto dto);
        Task <IEnumerable<InvestmentDto>> GetAll();
        Task <InvestmentDto> GetById(int id);
        void Delete(int id);
        void Update(UpdateInvestmentDto dto, int id);

    }
}
