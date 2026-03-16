using System.Text.Json.Serialization;

namespace AuthMicroService.Dtos
{
    // Dto de sortie : Ce qu'on remonte au client après la connexion reussie
    public class LoginResponseDto
    {
        [JsonPropertyName("Token")]
        public required string Token { get; set; }
        [JsonPropertyName("username")]
        public required string Username { get; set; }
        [JsonPropertyName("role")]
        public required string Role { get; set; }
        [JsonPropertyName("expiration")]
        public DateTime Expiration {  get; set; }
    }
}
