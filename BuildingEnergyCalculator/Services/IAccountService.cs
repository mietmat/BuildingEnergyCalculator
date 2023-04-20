using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Models;
using System.Security.Claims;

namespace BuildingEnergyCalculator.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJwt(LoginDto dto);
        string GenerateRefreshToken(LoginDto dto);
        ClaimsPrincipal GetPrincipleFromExpiredToken(string token);
        List<User> GetAll();
        User GetUserByEmail(string email);
        void SaveModifiedPassword(User user);
    }
}
