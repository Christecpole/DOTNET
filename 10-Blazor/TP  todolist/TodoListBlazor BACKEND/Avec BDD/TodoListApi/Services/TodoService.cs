using TodoListApi.DTOs;
using TodoListApi.Exceptions;
using TodoListApi.Extensions;
using TodoListApi.Repositories;

namespace TodoListApi.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repository;

        public TodoService(ITodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TodoItemDto>> GetAllAsync(int userId)
        {
            var items = await _repository.GetAllAsync(userId);
            return items.ToDtoList();
        }

        public async Task<List<TodoItemDto>> GetByStatusAsync(int userId, bool isCompleted)
        {
            var items = await _repository.GetByStatusAsync(userId, isCompleted);
            return items.ToDtoList();
        }

        public async Task<TodoItemDto> GetByIdAsync(int userId, int id)
        {
            var item = await _repository.GetByIdAsync(userId, id);

            if (item == null)
            {
                throw new NotFoundException($"La tache avec l'ID {id} n'existe pas.");
            }

            return item.ToDto();
        }

        public async Task<TodoItemDto> CreateAsync(int userId, TodoItemCreateDto dto)
        {
            var item = dto.ToModel();
            item.UserId = userId;
            await _repository.AddAsync(item);
            return item.ToDto();
        }

        public async Task UpdateAsync(int userId, int id, TodoItemUpdateDto dto)
        {
            var existingItem = await _repository.GetByIdAsync(userId, id);

            if (existingItem == null)
            {
                throw new NotFoundException($"Impossible de modifier : la tache {id} n'existe pas.");
            }

            existingItem.Title = dto.Title;
            existingItem.Description = dto.Description;
            existingItem.IsCompleted = dto.IsCompleted;
            existingItem.Priority = dto.Priority;
            existingItem.DueDate = dto.DueDate;

            await _repository.UpdateAsync(existingItem);
        }

        public async Task MarkAsCompleteAsync(int userId, int id)
        {
            var item = await _repository.GetByIdAsync(userId, id);

            if (item == null)
            {
                throw new NotFoundException($"Impossible de terminer : la tache {id} n'existe pas.");
            }

            item.IsCompleted = true;
            await _repository.UpdateAsync(item);
        }

        public async Task DeleteAsync(int userId, int id)
        {
            var item = await _repository.GetByIdAsync(userId, id);

            if (item == null)
            {
                throw new NotFoundException($"Impossible de supprimer : la tache {id} n'existe pas.");
            }

            await _repository.DeleteAsync(item);
        }
    }
}
