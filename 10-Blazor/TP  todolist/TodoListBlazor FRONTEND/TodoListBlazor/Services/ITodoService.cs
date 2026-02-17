using TodoListBlazor.Dtos;

namespace TodoListBlazor.Services
{
    //Interface pour les opérations CRUD sur les todos
    public interface ITodoService
    {
        Task<List<TodoItem>> GetAllAsync();

        Task<TodoItem> GetByIdAsync(int id);
        Task<TodoItem?> CreateAsync(CreateTodoDto createDto);
        Task<bool> UpdateAsync(TodoItem todo);
        Task<bool> DeleteAsync(int id);

        //Inverse le statut terminé/à faire
        Task<bool> ToggleAsync(int id);
    }
}
