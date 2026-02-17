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

        public List<TodoItemDto> GetAll()
        {
            var items = _repository.GetAll();
            return items.ToDtoList();
        }

        public List<TodoItemDto> GetByStatus(bool isCompleted)
        {
            var items = _repository.GetByStatus(isCompleted);
            return items.ToDtoList();
        }

        public TodoItemDto GetById(int id)
        {
            var item = _repository.GetById(id);

            if (item == null)
            {
                throw new NotFoundException($"La tache avec l'ID {id} n'existe pas.");
            }

            return item.ToDto();
        }

        public TodoItemDto Create(TodoItemCreateDto dto)
        {
            var item = dto.ToModel();
            _repository.Add(item);
            return item.ToDto();
        }

        public void Update(int id, TodoItemUpdateDto dto)
        {
            var existingItem = _repository.GetById(id);

            if (existingItem == null)
            {
                throw new NotFoundException($"Impossible de modifier : la tache {id} n'existe pas.");
            }

            existingItem.Title = dto.Title;
            existingItem.Description = dto.Description;
            existingItem.IsCompleted = dto.IsCompleted;
            existingItem.Priority = dto.Priority;
            existingItem.DueDate = dto.DueDate;

            _repository.Update(existingItem);
        }

        public void MarkAsComplete(int id)
        {
            var item = _repository.GetById(id);

            if (item == null)
            {
                throw new NotFoundException($"Impossible de terminer : la tache {id} n'existe pas.");
            }

            item.IsCompleted = true;
            _repository.Update(item);
        }

        public void Delete(int id)
        {
            var item = _repository.GetById(id);

            if (item == null)
            {
                throw new NotFoundException($"Impossible de supprimer : la tache {id} n'existe pas.");
            }

            _repository.Delete(id);
        }
    }
}
