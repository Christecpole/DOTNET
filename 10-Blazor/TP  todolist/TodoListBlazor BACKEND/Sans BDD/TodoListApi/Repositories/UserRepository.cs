using TodoListApi.Models;

namespace TodoListApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly List<User> _users = new();
        private static int _nextId = 1;

        public User? GetByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
        }

        public void Add(User user)
        {
            user.Id = _nextId++;
            _users.Add(user);
        }
    }
}
