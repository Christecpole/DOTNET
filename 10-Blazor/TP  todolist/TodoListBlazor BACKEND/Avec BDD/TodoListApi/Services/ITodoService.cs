using TodoListApi.DTOs;

namespace TodoListApi.Services
{
    public interface ITodoService
    {
        Task<List<TodoItemDto>> GetAllAsync(int userId);
        Task<List<TodoItemDto>> GetByStatusAsync(int userId, bool isCompleted);
        Task<TodoItemDto> GetByIdAsync(int userId, int id);
        Task<TodoItemDto> CreateAsync(int userId, TodoItemCreateDto dto);
        Task UpdateAsync(int userId, int id, TodoItemUpdateDto dto);
        Task MarkAsCompleteAsync(int userId, int id);
        Task DeleteAsync(int userId, int id);
    }
}
