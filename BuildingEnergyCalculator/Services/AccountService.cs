using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Exceptions;
using BuildingEnergyCalculator.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BuildingEnergyCalculator.Services
{
    public class AccountService : IAccountService
    {
        private readonly EnergyCalculatorDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public AccountService(EnergyCalculatorDbContext dbContext, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }
        public string GenerateJwt(LoginDto dto)
        {
            var user = _dbContext.Users
                            .Include(u => u.Role)
                            .FirstOrDefault(u => u.Email == dto.Email);
            if (user == null)
            {
                throw new BadRequestException("Invalid username or password");
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Email}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}"),
                new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd"))
            };

            if (!string.IsNullOrEmpty(user.Nationality))
            {
                claims.Add(new Claim("Nationality", user.Nationality));

            }

            //1st way
            //var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_authenticationSettings.JwtKey));
            //var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            //var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
            //    _authenticationSettings.JwtIssuer,
            //    claims,
            //    expires: expires,
            //    signingCredentials: credentials);


            //2nd way
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("this is my custom Secret key for authentication");
            var identity = new ClaimsIdentity(claims);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken(LoginDto dto)
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(tokenBytes);

            var tokenInUser = _dbContext.Users
                .Any(a => a.RefreshToken == refreshToken);

            if (tokenInUser)
            {
                return GenerateRefreshToken(dto);
            }

            _dbContext.Users.FirstOrDefault(u => u.Email == dto.Email).RefreshToken = refreshToken;
            _dbContext.Users.FirstOrDefault(u => u.Email == dto.Email).RefreshTokenExpireTime = DateTime.Now.AddDays(5);
            _dbContext.SaveChanges();
            return refreshToken;
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public ClaimsPrincipal GetPrincipleFromExpiredToken(string token)
        {
            var key = Encoding.UTF8.GetBytes("this is my custom Secret key for authentication");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = false,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg
                .Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("This is invalid token");
            }
            return principal;
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Email == email);
        }

        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                Nationality = dto.Nationality,
                RoleId = dto.RoleId,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PasswordHash = hashedPassword;

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public void SaveModifiedPassword(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        //public string GenerateNewAccessToken(TokenApiDto tokenApiDto)
        //{
        //    string accessToken = tokenApiDto.AccessToken;
        //    string refreshToken = tokenApiDto.RefreshToken;

        //    var principal = GetPrincipleFromExpiredToken(accessToken);
        //    var email = principal.Identity.Name;

        //    var user = _dbContext.Users.FirstOrDefault(x => x.Email == email);

        //    if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpireTime <= DateTime.Now)
        //    {
        //        throw new BadRequestException("Invalid request");
        //    }
        //    var newAccessToken = GenerateJwt(user);
        //    var newRefreshToken = GenerateRefreshToken();
        //}
    }
}
