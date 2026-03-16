using System.Text.Json.Serialization;

namespace Articles.Api.Dtos
{
    // Dto de sortie : Ce qu'on remonte au client après la connexion reussie
    public class LoginResponseDto
    {
        [JsonPropertyName("token")]
        public  string Token { get; set; }
        [JsonPropertyName("email")]
        public  string Email { get; set; }
        [JsonPropertyName("role")]
        public  string Role { get; set; }
        [JsonPropertyName("expiration")]
        public DateTime Expiration {  get; set; }
    }
}
