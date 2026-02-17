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
        public static List<Auteur> Auteurs { get; set; } = new()
        {
            new() { Id = 1, Nom = "Hugo", Prenom = "Victor" },
            new() { Id = 2, Nom = "Zola", Prenom = "Emile" }
        };
        
        public static List<Article> Articles { get; set; } = new()
        {

            new() { Id = 1, Titre = "Les Misérables", Contenu = "L'histoire de Jean Valjean...", AuteurId = 1 },
            new() { Id = 2, Titre = "Notre-Dame de Paris", Contenu = "Quasimodo et Esmeralda...", AuteurId = 1 },

            new() { Id = 3, Titre = "Germinal", Contenu = "La grève des mineurs...", AuteurId = 2 }
        };
    }
}
