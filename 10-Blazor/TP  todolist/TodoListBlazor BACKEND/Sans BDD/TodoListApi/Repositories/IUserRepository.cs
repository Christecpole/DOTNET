using TodoListApi.Models;

namespace TodoListApi.Repositories
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
        void Add(User user);
    }
}
