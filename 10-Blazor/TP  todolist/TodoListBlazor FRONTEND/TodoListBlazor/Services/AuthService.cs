using Blazored.LocalStorage;
using System.Net.Http.Json;
using TodoListBlazor.Dtos;

namespace TodoListBlazor.Services
{
    //Service qui gère l'authentification avec l'api
    public class AuthService : IAuthService
    {
        //clé utilisée pour stocker dans le localstorage
        private const string TOKEN_KEY = "authToken";

        //Pour faire les appels api
        private readonly HttpClient _http;

        //Pour stocker le token dans le navigateur
        private readonly ILocalStorageService _localStorage;

        //Blazor va créé et injecter automatiquement httpclient et Ilocalstorage
        public AuthService(HttpClient http, ILocalStorageService localStorage)
        {
            _http = http;
            _localStorage = localStorage;
        }

        // Connecter l'utilisateur
        //Envoie POST api/auth/login avec les identifiants
        //si succès => stocke le token dans le localstorage
        //Retourne le resultat.
        public async Task<(bool Success, string? ErrorMessage)> LoginAsync(LoginDto loginDto)
        {
            try
            {
                //Envoyer les identifiants à l'API
                var response = await _http.PostAsJsonAsync("api/Auth/login", loginDto);

                //Verifie si la requete a réussi (Code 2xx)
                if (response.IsSuccessStatusCode)
                {
                    //Lire la réponse Json
                    var authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();

                    if(authResponse?.Token != null)
                    {
                        //Stocker le token dans le localstorage.
                        //Il sera récupéré par le TODOService pour les requêtes protégées.
                        await _localStorage.SetItemAsStringAsync(TOKEN_KEY, authResponse.Token);
                        return (true, null);
                    }
                }

                //Si echec essayer de lire le message d'erreur de l'API
                var errorContent = await response.Content.ReadAsStringAsync();
                return (false, errorContent ?? "Identifiants incorrects.");


            }
            catch (HttpRequestException)
            {
                return (false, "Impossible de contacter le server. Vérifier que l'api est démarré.");
            }
            catch (Exception ex)
            {

                return (false, $"Erreur : {ex.Message}");
            }
        }
        //Inscrire un nouvel utilisateur
        //On ne stocke pas le token après l'inscription
        //L'utilisateur doit se connecter manuellement.
        public async Task<(bool Success, string? ErrorMessage)> RegisterAsync(RegisterDto registerDto)
        {
            try
            {
                //ENvoyer les données d'inscription à l'API
                var response = await _http.PostAsJsonAsync("api/Auth/register", registerDto);

                if (response.IsSuccessStatusCode)
                { 
                    return (true, null);
                }

                //Lire le message d'erreur envoyé par l'API (par ex : Ce nom existe déjà)
                var errorContent = await response.Content.ReadAsStringAsync();
                return (false, errorContent ?? "Erreur lors de l'inscription");

            }
            catch (HttpRequestException)
            {
                return (false, "Impossible de contacter le server. Vérifier que l'api est démarré.");
            }
            catch (Exception ex)
            {

                return (false, $"Erreur : {ex.Message}");
            }
        }

        //Deconnecte un utilisateur en supprimant son token
        public async Task LogoutAsync()
        {
            //supprime le token du localstorage
            await _localStorage.RemoveItemAsync(TOKEN_KEY);
        }

        //Recupérer le jwt stocké dans le localstorage
        public async Task<string?> GetTokenAsync()
        {
            return await _localStorage.GetItemAsStringAsync(TOKEN_KEY);
        }

        //Vérifie si l'utilisateur est connecté
        public async Task<bool> IsAuthenticatedAsync()
        {
            var token = await GetTokenAsync();

            return !string.IsNullOrEmpty(token);
        }

      

    
    }
}
