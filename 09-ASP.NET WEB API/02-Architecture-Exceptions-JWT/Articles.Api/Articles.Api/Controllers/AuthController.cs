using Articles.Api.Dtos;
using Articles.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Articles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //Service d'authentification injecté par DI
        private readonly IAuthService _authService;

        // Constructeur : injecte automatiquement le service
        public AuthController(IAuthService authService)
        {
          _authService = authService;
        }

        /// <summary>
        /// Authentifie un utilisateur et retourne un JWT
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public ActionResult<LoginResponseDto> Login([FromBody] LoginDto dto) 
        {
            //Validation ddu model qui n'est plus obligatoire car APIController
            if(!ModelState.IsValid) return BadRequest(ModelState);

            //Appel au service d'authentification
            //Si succès => retourne le responsedto avec le token
            //Si echec => lance UnauthorizedAccessException => Middleware => 401
            var reponse = _authService.Authenticate(dto);

            return Ok(reponse);
        }

        //Retourner les informations de l'utilisateur actuellement connecté
        //Cette route lit les claims stockés dans le JWT
        //Le token est automatiquement décodé par le middleware d'authentification
        [Authorize] //Il faut etre connecté pour accéder à cette route
        [HttpGet("moi")]
        public ActionResult<object> GetCurrentUser()
        {
            // User : C'est une proprié héritée de controllerBase
            // Elle contient les claims extraits du jwt par le middlware

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            //Si aucun claim n'est trouvé c'est qu'il y a un probleme avec le token.
            if(userId == null ||email == null)
            {
                throw new UnauthorizedAccessException("Token invalide ou corrompu.");
            }

            // On retourne un objet anonyme avec les infos de l'utilisateur
            return Ok(new
            {
                Id = int.Parse(userId),
                Email = email,
                Role = role,
                Message = "Vous êtes bien authentifié !"
            });

        }

    }
}
