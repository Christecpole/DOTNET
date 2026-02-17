using TodoListApi.Models;

namespace TodoListApi.Repositories
{
    /// <summary>
    /// Implementation du repository avec une liste en memoire (Fake Database).
    /// En production, on remplacerait par Entity Framework + MySQL/SQL Server.
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        // Notre "base de donnees" fictive - une simple liste statique
        // "static" = partagee par toutes les instances, persiste tant que l'app tourne
        private static readonly List<TodoItem> _todos = new();

        // Compteur pour generer des IDs uniques
        private static int _nextId = 1;

        // Constructeur statique : s'execute UNE SEULE FOIS au demarrage
        // On y met des donnees de test
        static TodoRepository()
        {
            _todos.Add(new TodoItem
            {
                Id = _nextId++,
                Title = "Apprendre ASP.NET Core",
                Description = "Suivre le cours sur les API REST",
                Priority = 5,
                IsCompleted = false,
                DueDate = DateTime.Now.AddDays(7)
            });

            _todos.Add(new TodoItem
            {
                Id = _nextId++,
                Title = "Faire les courses",
                Description = "Lait, pain, oeufs, fromage",
                Priority = 3,
                IsCompleted = false,
                DueDate = DateTime.Now.AddDays(1)
            });

            _todos.Add(new TodoItem
            {
                Id = _nextId++,
                Title = "Repondre aux emails",
                Description = null,
                Priority = 2,
                IsCompleted = true  // Celle-ci est deja terminee
            });
        }

        public List<TodoItem> GetAll()
        {
            return _todos.ToList();
        }

        public List<TodoItem> GetByStatus(bool isCompleted)
        {
            return _todos.Where(t => t.IsCompleted == isCompleted).ToList();
        }

        public TodoItem? GetById(int id)
        {
            return _todos.FirstOrDefault(t => t.Id == id);
        }

        public void Add(TodoItem item)
        {
            item.Id = _nextId++;
            _todos.Add(item);
        }

        public void Update(TodoItem item)
        {
            var index = _todos.FindIndex(t => t.Id == item.Id);
            if (index != -1)
            {
                _todos[index] = item;
            }
        }

        public void Delete(int id)
        {
            _todos.RemoveAll(t => t.Id == id);
        }
    }
}
