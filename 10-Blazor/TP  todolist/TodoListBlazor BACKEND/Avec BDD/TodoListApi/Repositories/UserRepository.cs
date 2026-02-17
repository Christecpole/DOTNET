using Microsoft.EntityFrameworkCore;
using TodoListApi.Models;
using TodoListApi_avecBDD.Data;

namespace TodoListApi.Repositories
{
    /// <summary>
    /// Repository pour les utilisateurs - Version EF Core.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Recherche un utilisateur par son nom.
        /// EF Core traduit en : SELECT * FROM users WHERE username = @p0 LIMIT 1
        /// </summary>
        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        /// <summary>
        /// Ajoute un nouvel utilisateur.
        /// EF Core traduit en : INSERT INTO users (...) VALUES (...)
        /// </summary>
        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
