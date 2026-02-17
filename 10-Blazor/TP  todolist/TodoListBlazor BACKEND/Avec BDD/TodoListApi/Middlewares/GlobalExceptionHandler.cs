using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using TodoListApi.Exceptions;

namespace TodoListApi.Middlewares
{
    /// <summary>
    /// Middleware qui intercepte toutes les exceptions non gerees
    /// et les transforme en reponses JSON standardisees.
    /// 
    /// C'est comme un "filet de securite" pour toute l'application.
    /// </summary>
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new ProblemDetails
            {
                Title = "Une erreur est survenue.",
                Detail = exception.Message
            };

            // Selon le TYPE d'exception, on adapte le code HTTP
            switch (exception)
            {
                // Ressource non trouvee -> 404
                case NotFoundException:
                case KeyNotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Title = "Ressource introuvable.";
                    break;

                // Parametre invalide -> 400
                case ArgumentNullException:
                case ArgumentOutOfRangeException:
                case ArgumentException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Title = "Requete invalide.";
                    break;

                // Non autorise -> 401
                case UnauthorizedAccessException:
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    response.Title = "Acces refuse.";
                    break;

                // Tout le reste -> 500 (erreur serveur)
                default:
                    response.Title = "Erreur interne du serveur.";
                    break;
            }

            response.Status = context.Response.StatusCode;

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }
}
