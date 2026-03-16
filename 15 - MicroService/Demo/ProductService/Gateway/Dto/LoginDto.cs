using System.ComponentModel.DataAnnotations;

namespace Articles.Api.Dtos
{
    //DTO D'entrée : Ce que le client envoie pour se connecter
    public class LoginDto
    {
        [Required(ErrorMessage ="L'email est obligatoire")]
        [EmailAddress(ErrorMessage ="Format d'email invalide")]
        public required string Email { get; set; }

        [Required(ErrorMessage ="Le mot de passe est obligatoire")]
        public required string Password { get; set; }
    }
}
