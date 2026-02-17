using TodoListApi.Models;

namespace TodoListApi.Repositories
{
    /// <summary>
    /// Interface definissant les operations d'acces aux donnees pour les taches.
    /// </summary>
    public interface ITodoRepository
    {
        Task<List<TodoItem>> GetAllAsync(int userId);
        Task<List<TodoItem>> GetByStatusAsync(int userId, bool isCompleted);
        Task<TodoItem?> GetByIdAsync(int userId, int id);
        Task<TodoItem> AddAsync(TodoItem item);
        Task<TodoItem?> UpdateAsync(TodoItem item);
        Task DeleteAsync(TodoItem item);
    }
}
