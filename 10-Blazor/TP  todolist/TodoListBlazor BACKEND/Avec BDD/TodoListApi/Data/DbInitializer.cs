using Microsoft.EntityFrameworkCore;
using TodoListApi.Models;
using BCrypt.Net;

namespace TodoListApi_avecBDD.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            // Si déjà initialisé, on sort
            if (await context.Todos.AnyAsync())
            {
                Console.WriteLine("Base de données déjà initialisée.");
                return;
            }

            Console.WriteLine("Initialisation de la base de données (DEV)...");

            // =========================
            // 1️⃣ Création utilisateur de test
            // =========================
            const string demoUsername = "demo";
            const string demoPassword = "demo123"; 

            var user = await context.Users
                .FirstOrDefaultAsync(u => u.Username == demoUsername);

            if (user == null)
            {
                user = new User
                {
                    Username = demoUsername,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(demoPassword)
                };

                context.Users.Add(user);
                await context.SaveChangesAsync();

                Console.WriteLine($"Utilisateur '{demoUsername}' créé (password: {demoPassword})");
            }

            // =========================
            // 2️⃣ Création des tâches
            // =========================
            var now = DateTime.Now;

            var todos = new List<TodoItem>
            {
                new TodoItem
                {
                    Title = "Apprendre ASP.NET Core",
                    Description = "Suivre la formation complète sur les API REST",
                    Priority = 5,
                    DueDate = now.AddDays(7),
                    UserId = user.Id
                },
                new TodoItem
                {
                    Title = "Faire les courses",
                    Description = "Acheter du lait, du pain et des œufs",
                    Priority = 3,
                    DueDate = now.AddDays(1),
                    UserId = user.Id
                },
                new TodoItem
                {
                    Title = "Répondre aux emails",
                    Priority = 2,
                    IsCompleted = true,
                    UserId = user.Id
                },
                new TodoItem
                {
                    Title = "Réviser pour l'examen",
                    Description = "Chapitres 1 à 5 du cours",
                    Priority = 4,
                    DueDate = now.AddDays(3),
                    UserId = user.Id
                },
                new TodoItem
                {
                    Title = "Appeler le médecin",
                    Description = "Prendre rendez-vous pour le check-up annuel",
                    Priority = 3,
                    DueDate = now.AddDays(14),
                    UserId = user.Id
                }
            };

            await context.Todos.AddRangeAsync(todos);
            await context.SaveChangesAsync();

            Console.WriteLine($"{todos.Count} tâches créées pour l'utilisateur '{demoUsername}'.");
        }
    }
}