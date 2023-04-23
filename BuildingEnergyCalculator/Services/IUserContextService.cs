using System.Security.Claims;

namespace BuildingEnergyCalculator.Services
{
    public interface IUserContextService
    {
        public ClaimsPrincipal User { get; }
        public int? GetUserId { get; }
    }
}
