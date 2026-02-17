namespace Articles.Api.Dtos
{
    // Dto de sortie : Ce qu'on remonte au client après la connexion reussie
    public class LoginResponseDto
    {
        public required string Token { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public DateTime Expiration {  get; set; }
    }
}
