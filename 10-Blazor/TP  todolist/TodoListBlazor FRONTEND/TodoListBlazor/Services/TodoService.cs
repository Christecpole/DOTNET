
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TodoListBlazor.Dtos;

namespace TodoListBlazor.Services
{
    public class TodoService : ITodoService
    {
        //Permet d'envoyer des requetes http
        private readonly HttpClient _http;

        //Pour récupéré le token jwt dans le localstorage
        private readonly IAuthService _authService;

        public TodoService(HttpClient http, IAuthService authService)
        {
            _http = http;
            _authService = authService;
        }
        //Recupère touutes les tâches de l'utilisateur connecté
        public async Task<List<TodoItem>> GetAllAsync()
        {
            try
            {
                //Sans cette ligne l'api retourne 401 unauthorize
                await SetAuthorizationHeaderAsync();

                var url = "api/todo";

                //if(IsCon)

                var taches = await _http.GetFromJsonAsync<List<TodoItem>>(url);

                //retourne la liste ou une liste vide si null
                return taches ?? new List<TodoItem>();
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("Error 401 : Token invalide ou expiré. reconnectez-vous");
                return new List<TodoItem>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                return new List<TodoItem>();
            }
        }

        //Récupération d'une tache par son id
        public async Task<TodoItem?> GetByIdAsync(int id)
        {
            try
            {
                await SetAuthorizationHeaderAsync();

                return await _http.GetFromJsonAsync<TodoItem>($"api/todo/{id}");

            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                // 404 not found
                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Erreur : {ex.Message}");
                return null;
            }
        }


        public async Task<TodoItem?> CreateAsync(CreateTodoDto todo)
        {
            try
            {
                await SetAuthorizationHeaderAsync();

                var response = await _http.PostAsJsonAsync("api/todo", todo);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TodoItem>();
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la création : {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateAsync(TodoItem todo)
        {
            try
            {
                await SetAuthorizationHeaderAsync();

                var response = await _http.PutAsJsonAsync($"api/todo/{todo.Id}", todo);
                return response.IsSuccessStatusCode;
            
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la modification : {ex.Message}");
                return false;
            }
        }


        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await SetAuthorizationHeaderAsync();

                var response = await _http.DeleteAsync($"api/todo/{id}");
                return response.IsSuccessStatusCode;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la suppression : {ex.Message}");
                return false;
            }
        }

       

        public async Task<bool> ToggleAsync(int id)
        {
            try
            {
                await SetAuthorizationHeaderAsync();

                var response = await _http.PatchAsync($"api/todo/{id}/complete",null);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Erreur lors de la modification du status : {ex.Message}");
                return false;
            }
        }

       

        //Configuration du header authorization
        //recupère le token et l'ajoute dans le header
        private async Task SetAuthorizationHeaderAsync()
        {
            //Recupérer le token
            var token = await _authService.GetTokenAsync();

            //si le token existe alors l'ajouter au header http
            if (!string.IsNullOrEmpty(token))
            {
                //créer le header "Authorization : Bearer <token>
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
