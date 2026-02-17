using Articles.Api.Data;
using Articles.Api.Dtos;
using Articles.Api_AvecBDD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Articles.Api.Services
{
    public class AuthService : IAuthService
    {
        // IConfiguration => accès à appsettings.json
        // Injecté automatiquement pas ASP.NEt via le constructeur
        private readonly IConfiguration _config;

        // petite entorse à la bonne pratique on injecte le dbcontext dans le service
        // pour ne pas créer le Repo par manque de temps
        private readonly ApplicationDbContext _context;
        public AuthService(IConfiguration config, ApplicationDbContext context)
        {
           _config = config;
            _context = context;
        }

        public async Task<LoginResponseDto> AuthenticateAsync(LoginDto dto)
        {
            var user = await _context.Utilisateurs.FirstOrDefaultAsync(u=>u.Email == dto.Email);

            if(user == null || !PasswordService.VerifyPassword(dto.Password, user.MotDePasse))
            {
                throw new UnauthorizedAccessException("Email ou mot de passe incorrect");
            }

            // Recupération de la configuration JWT
            //On lit la clé secrère depuis appsettings.json
            // Si elle es=xiste pas , on envoie une exception avec un message clair
            var secretKey = _config["jwtSettings:SecretKey"]
                ?? throw new InvalidOperationException("jwtSettings:SecretKey manque dans appsettings.json");

            // duree de validité du token , par defaut un jours si non configuré
            var expirationDays = int.Parse(_config["jwtSettings:ExpirationInDays"] ?? "1");

            // Generation du token

            //L'outil qui sait créer et lire des jwt
            var tokenHandler = new JwtSecurityTokenHandler();

            // pour l'algo de signature
            // on a besoin que clé secrete soit converti en tableau de bytes
            var key = Encoding.ASCII.GetBytes(secretKey);

            //Date d'expiration du token
            var expiration = DateTime.Now.AddDays(expirationDays);

            // Recette du token : ce qu'il contient et comment le signer
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //On va mettre les infos de la "carte magnétique"
                Subject = new ClaimsIdentity(new[]
                {
                    // CLaim 1 : L'id de l'utilisateur 
                    // Utile pour savori qui fait la requete coté server
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),

                    //Claim 2 : Le role de l'utilisateur
                    //Utilisé pour vérifier les droits [authorize(Roles="Admin")]
                    new Claim(ClaimTypes.Role, user.Role),

                    //Claime 3 : L'email de l'utilisateur
                    //utile pour afficher coté client ou dans les logs
                    new Claim(ClaimTypes.Email, user.Email),

                }),

                //Date d'expiration
                Expires = expiration,

                //Donner une signature numérique
                // Empeche la falsification du token
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)

            };

            // Fabrication du token à partir de la recette
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new LoginResponseDto
            {
                // Writetoken converti l'objet token en string "eyj...."
                Token = tokenHandler.WriteToken(token),
                Email = user.Email,
                Role = user.Role,
                Expiration = expiration,
            };
        }
    }
}
