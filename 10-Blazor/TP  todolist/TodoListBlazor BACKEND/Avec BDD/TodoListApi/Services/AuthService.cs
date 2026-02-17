using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TodoListApi.DTOs;
using TodoListApi.Models;
using TodoListApi.Repositories;

namespace TodoListApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            // Verifier que le username n'existe pas deja
            var existingUser = await _userRepository.GetByUsernameAsync(dto.Username);
            if (existingUser != null)
            {
                throw new ArgumentException("Ce nom d'utilisateur est deja pris.");
            }

            // Creer l'utilisateur avec le mot de passe hashe
            var user = new User
            {
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            await _userRepository.AddAsync(user);

            // Retourner un token JWT directement apres l'inscription
            return GenerateJwtToken(user);
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            // Chercher l'utilisateur
            var user = await _userRepository.GetByUsernameAsync(dto.Username);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Nom d'utilisateur ou mot de passe incorrect.");
            }

            // Verifier le mot de passe
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Nom d'utilisateur ou mot de passe incorrect.");
            }

            // Generer et retourner le token JWT
            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            // Recuperer la cle secrete depuis la configuration
            var secretKey = _configuration["JWT:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("La cle JWT n'est pas configuree.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Les informations qu'on met dans le token
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            // Creer le token
            var token = new JwtSecurityToken(
                issuer: "TodoListApi",
                audience: "TodoListApi",
                claims: claims,
                expires: DateTime.Now.AddHours(24),  // Expire dans 24 heures
                signingCredentials: credentials
            );

            // Convertir en string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
