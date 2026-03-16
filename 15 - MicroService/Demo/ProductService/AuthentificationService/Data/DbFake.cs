using Articles.Api.Models;
using Articles.Api.Services;

namespace Articles.Api.Data
{
    public static class DbFake
    {
        public static List<Utilisateur> Utilisateurs { get; set; } = new()
        {
            new()
            {
                Id=1,
                Email = "admin@test.com",
                MotDePasse = PasswordService.HashPassword("admin123"),
                Role = "Admin" // peut tout faire
            },

            new()
            {
                Id=2,
                Email="user@test.com",
                MotDePasse =PasswordService.HashPassword("user123"),
                Role="User" // peut lire + créer mais pas supprimer
            }
        };

      
    }
}
