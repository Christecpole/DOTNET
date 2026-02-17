using TodoListBlazor.Dtos;

namespace TodoListBlazor.Services
{
    // gère les opérations d'authentification
    public interface IAuthService
    {
        // connecte l'utilisateur et stocke le token
        Task<(bool Success, string? ErrorMessage)> LoginAsync(LoginDto loginDto);

        //Inscrit un nouvel utilisateur
        Task<(bool Success, string? ErrorMessage)> RegisterAsync(RegisterDto registerDto);

        //Deconnecte l'utilisateur (supprime le jwt)
        Task LogoutAsync();

        //Recupèrer le jwt stocké
        Task<string?> GetTokenAsync();

        //Verifie si l'utilisateur est connecté
        Task<bool> IsAuthenticatedAsync();

    }
}
