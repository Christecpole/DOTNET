using Microsoft.EntityFrameworkCore;
using TodoListApi.Models;
using TodoListApi_avecBDD.Data;

namespace TodoListApi.Repositories
{
    /// <summary>
    /// Repository pour les tâches - Version EF Core.
    /// Utilise le DbContext pour accéder à MySQL.
    /// </summary>
    public class TodoRepository : ITodoRepository
    {
        // Le contexte de base de données (injecté)
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructeur avec injection du DbContext.
        /// </summary>
        public TodoRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Récupère toutes les tâches.
        /// EF Core traduit en : SELECT * FROM todos
        /// </summary>
        public async Task<List<TodoItem>> GetAllAsync(int userId)
        {
            return await _context.Todos
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Récupère les tâches filtrées par statut.
        /// EF Core traduit en : SELECT * FROM todos WHERE is_completed = @p0
        /// </summary>
        public async Task<List<TodoItem>> GetByStatusAsync(int userId, bool isCompleted)
        {
            return await _context.Todos
                .Where(t => t.UserId == userId && t.IsCompleted == isCompleted)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Récupère une tâche par son ID.
        /// EF Core traduit en : SELECT * FROM todos WHERE id = @p0 LIMIT 1
        /// </summary>
        public async Task<TodoItem?> GetByIdAsync(int userId,int id)
        {
            return await _context.Todos.FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        }

        /// <summary>
        /// Ajoute une nouvelle tâche.
        /// EF Core traduit en : INSERT INTO todos (...) VALUES (...)
        /// </summary>
        public async Task<TodoItem> AddAsync(TodoItem item)
        {
            await _context.Todos.AddAsync(item);
            await _context.SaveChangesAsync();  // IMPORTANT : Exécute le INSERT
            return item;  // L'ID est maintenant rempli par MySQL
        }

        /// <summary>
        /// Met à jour une tâche existante.
        /// EF Core traduit en : UPDATE todos SET ... WHERE id = @p0
        /// </summary>
        public async Task<TodoItem?> UpdateAsync(TodoItem item)
        {
            // _context.Todos.Update(item);  pas obligatoire : Marque l'entité comme modifiée   
            await _context.SaveChangesAsync();  // IMPORTANT : Exécute le UPDATE

            return item;
        }

        /// <summary>
        /// Supprime une tâche par son ID.
        /// EF Core traduit en : DELETE FROM todos WHERE id = @p0
        /// </summary>
        public async Task DeleteAsync(TodoItem item)
        {
            _context.Todos.Remove(item);
            await _context.SaveChangesAsync();  // IMPORTANT : Exécute le DELETE
            
        }
    }
}
