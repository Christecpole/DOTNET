using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AuthMicroService.Dtos
{
    //DTO D'entrée : Ce que le client envoie pour se connecter
    public class LoginDto
    {
        [JsonPropertyName("username")]
        [Required(ErrorMessage ="Le username est obligatoire")]
        public required string Username { get; set; }
        [JsonPropertyName("password")]
        [Required(ErrorMessage ="Le mot de passe est obligatoire")]
        public required string Password { get; set; }
    }
}
