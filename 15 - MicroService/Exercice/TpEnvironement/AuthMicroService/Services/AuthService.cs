using AuthMicroService.Data;
using AuthMicroService.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthMicroService.Models;

namespace AuthMicroService.Services
{
    public class AuthService : IAuthService
    {

        private readonly IConfiguration _config;

        private readonly AppDbContext _dbContext;

        public AuthService(IConfiguration config,AppDbContext dbContext)
        {
            _dbContext = dbContext;
           _config = config;
        }

        public LoginResponseDto Authenticate(LoginDto dto)
        {
            var user = _dbContext.Utilisateurs.FirstOrDefault(u=>u.Username == dto.Username);

            if(user == null || !PasswordService.VerifyPassword(dto.Password, user.MotDePasse))
            {
                throw new UnauthorizedAccessException("Email ou mot de passe incorrect");
            }
            
            var secretKey = _config["jwtSettings:SecretKey"]
                ?? throw new InvalidOperationException("jwtSettings:SecretKey manque dans appsettings.json");
            
            var expirationDays = int.Parse(_config["jwtSettings:ExpirationInDays"] ?? "1");
            
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var key = Encoding.ASCII.GetBytes(secretKey);
            
            var expiration = DateTime.Now.AddDays(expirationDays);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.Name, user.Username),

                }),
                
                Expires = expiration,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)

            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponseDto
            {
                Token = tokenHandler.WriteToken(token),
                Username = user.Username,
                Role = user.Role,
                Expiration = expiration,
            };
        }

        public LoginResponseDto Register(RegisterDto dto)
        {
            Utilisateur user = new Utilisateur()
            {
                Username = dto.Username,
                MotDePasse = PasswordService.HashPassword(dto.Password),
                Role = "User"
            };

            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return Authenticate(new LoginDto() { Username = dto.Username, Password = dto.Password });
        }
    }
}
