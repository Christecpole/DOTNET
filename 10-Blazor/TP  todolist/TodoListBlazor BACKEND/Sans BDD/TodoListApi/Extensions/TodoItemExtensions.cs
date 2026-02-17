using TodoListApi.DTOs;
using TodoListApi.Models;

namespace TodoListApi.Extensions
{
    /// <summary>
    /// Methodes d'extension pour convertir entre Model et DTOs.
    /// </summary>
    public static class TodoItemExtensions
    {
        /// <summary>
        /// Convertit un TodoItem (Model) en TodoItemDto.
        /// Utilise quand on RENVOIE des donnees au client.
        /// </summary>
        public static TodoItemDto ToDto(this TodoItem item)
        {
            return new TodoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                Priority = item.Priority,
                DueDate = item.DueDate,
                CreatedAt = item.CreatedAt
            };
        }

        /// <summary>
        /// Convertit un TodoItemCreateDto en TodoItem (Model).
        /// Utilise quand on RECOIT des donnees pour creer une tache.
        /// </summary>
        public static TodoItem ToModel(this TodoItemCreateDto dto)
        {
            return new TodoItem
            {
                // Id sera genere automatiquement par le Repository
                Title = dto.Title,
                Description = dto.Description,
                Priority = dto.Priority,
                DueDate = dto.DueDate,
                // IsCompleted = false par defaut (nouvelle tache)
                // CreatedAt = DateTime.Now par defaut
            };
        }

        /// <summary>
        /// Convertit une liste de TodoItem en liste de TodoItemDto.
        /// </summary>
        public static List<TodoItemDto> ToDtoList(this List<TodoItem> items)
        {
            return items.Select(item => item.ToDto()).ToList();
        }
    }
}
