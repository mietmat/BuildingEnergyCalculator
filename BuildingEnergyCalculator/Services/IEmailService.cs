using BuildingEnergyCalculator.Entities;

namespace BuildingEnergyCalculator.Services
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}
