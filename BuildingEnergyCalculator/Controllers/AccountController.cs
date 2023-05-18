using BuildingEnergyCalculator.Entities;
using BuildingEnergyCalculator.Helpers;
using BuildingEnergyCalculator.Models;
using BuildingEnergyCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BuildingEnergyCalculator.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly EnergyCalculatorDbContext _dbContext;

        public AccountController(EnergyCalculatorDbContext dbContext, IAccountService accountService, IConfiguration configuration, IEmailService emailService,
            IPasswordHasher<User> passwordHasher)
        {
            _accountService = accountService;
            _configuration = configuration;
            _emailService = emailService;
            _passwordHasher = passwordHasher;
            _dbContext = dbContext;
        }

        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
        {
            _accountService.RegisterUser(dto);

            return Ok(new { Message = "New User Registered!" });
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto dto)
        {
            string token = _accountService.GenerateJwt(dto);

            var newAccessToken = token;
            string newRefreshToken = _accountService.GenerateRefreshToken(dto);


            return Ok(new TokenApiDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }

        [HttpPost("refresh")]
        public ActionResult Refresh([FromHeader] TokenApiDto tokenApiDto, [FromBody] LoginDto dto)
        {
            if (tokenApiDto is null)
            {
                return BadRequest("Invalid client request");
            }

            string accessToken = tokenApiDto.AccessToken;
            string refreshToken = tokenApiDto.RefreshToken;

            var principal = _accountService.GetPrincipleFromExpiredToken(accessToken);
            var email = principal.Identity.Name;

            var user = _dbContext.Users.FirstOrDefault(x => x.Email == email);

            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpireTime <= DateTime.Now)
            {
                return BadRequest("Invalid request");
            }
            var newAccessToken = _accountService.GenerateJwt(dto);
            var newRefreshToken = _accountService.GenerateRefreshToken(dto);

            return Ok(new TokenApiDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken

            });

        }


        [HttpGet]
        //[Authorize(Roles = "User")]
        public ActionResult<LoginDto> GetAllUsers()
        {
            var users = _accountService.GetAll();
            return Ok(users.ToList());
        }

        [HttpPost("send-reset-email/{email}")]
        public ActionResult<LoginDto> SendEmail(string email)
        {
            var user = _accountService.GetUserByEmail(email);
            if (user is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "Email doesn't exist"
                });
            }

            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var emailToken = Convert.ToBase64String(tokenBytes);
            user.ResetPasswordToken = emailToken;
            user.ResetPasswordExpiry = DateTime.Now.AddMinutes(15);
            string from = _configuration["EmailSettings:From"];
            var emailModel = new Email(email, "Reset Password!", EmailBody.EmailStringBody(email, emailToken));
            _emailService.SendEmail(emailModel);

            _accountService.SaveModifiedPassword(user);


            return Ok(new
            {
                StatusCode = 200,
                Message = "Email Sent!"
            });

        }

        [HttpPost("reset-password")]
        public ActionResult<LoginDto> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var newToken = resetPasswordDto.EmailToken.Replace(" ", "+");
            var user = _dbContext.Users.AsNoTracking().FirstOrDefault(x => x.Email == resetPasswordDto.Email);
            if (user is null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "User doesn't exist"
                });
            }
            var tokenCode = user.ResetPasswordToken;
            DateTime emailTokenExpiry = user.ResetPasswordExpiry;
            if (tokenCode != resetPasswordDto.EmailToken || emailTokenExpiry < DateTime.Now)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Invalid reset link"
                });
            }

            user.PasswordHash = _passwordHasher.HashPassword(user, resetPasswordDto.NewPassword);
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return Ok(new
            {
                StatusCode = 200,
                Message = "Password reset successfully"
            });


        }

    }
}
