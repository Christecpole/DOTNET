namespace TodoListBlazor.Dtos
{
    //Reponse de l'API après le login ou l'inscription
    public class AuthResponse
    {
        public string Token { get; set; } = string.Empty;
        public DateTime? Expiration { get; set; }
    }
}
