using Articles.Api.Models;
using Articles.Api.Services;

namespace Articles.Api_AvecBDD.Data
{
    public static class DbInitializer
    {

        // Initialise la bdd avec des données de test
        // Ne fait rien si des données existent déjà
        public static void Initialize(ApplicationDbContext context)
        {
            //S'assurer que la base existe 
            context.Database.EnsureCreated();

            //creer les users
            if (!context.Utilisateurs.Any())
            {
                var utilisateur = new Utilisateur[]
                {
                    new()
                    {
                        Email = "admin@test.com",
                        MotDePasse = PasswordService.HashPassword("admin123"),
                        Role = "Admin" // peut tout faire
                    },

                    new()
                    {
                        Email="user@test.com",
                        MotDePasse = PasswordService.HashPassword("user123"),
                        Role="User" // peut lire + créer mais pas supprimer
                    }
                };

                context.Utilisateurs.AddRange(utilisateur);

                context.SaveChanges();
            }

            if (!context.Auteurs.Any())
            {
                var auteurs = new Auteur[]
                {
                    new() {  Nom = "Hugo", Prenom = "Victor" },
                    new() {  Nom = "Zola", Prenom = "Emile" }
                };

                context.Auteurs.AddRange(auteurs);
                context.SaveChanges();
            }

            if (!context.Articles.Any())
            {
                var hugo = context.Auteurs.First(a => a.Nom == "Hugo");
                var zola = context.Auteurs.First(a => a.Nom == "Zola");

                var articles = new Article[]
                {
                     new()
                     {   Titre = "Les Misérables",
                         Contenu = "L'histoire de Jean Valjean...",
                         AuteurId = hugo.Id,
                     },
                    new() { Titre = "Notre-Dame de Paris", Contenu = "Quasimodo et Esmeralda...", AuteurId = hugo.Id },

                    new() {  Titre = "Germinal", Contenu = "La grève des mineurs...", AuteurId = zola.Id }
                };

                context.Articles.AddRange(articles);
                context.SaveChanges();
            }
        }
    }
}
