using TodoListApi.DTOs;

namespace TodoListApi.Services
{
    public interface ITodoService
    {
        List<TodoItemDto> GetAll();
        List<TodoItemDto> GetByStatus(bool isCompleted);
        TodoItemDto GetById(int id);
        TodoItemDto Create(TodoItemCreateDto dto);
        void Update(int id, TodoItemUpdateDto dto);
        void MarkAsComplete(int id);
        void Delete(int id);
    }
}
