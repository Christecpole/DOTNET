using Articles.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Articles.Api_AvecBDD.Data
{
    // DbContext :le pont entre c# et mysql
    public class ApplicationDbContext : DbContext
    {
        // Recette à suivre poru que ca fonctionne
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Dbset = nos tables
        //Chaque dbset représente une table dans mysql

        //Table des utilisateurs
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        //Table des auteurs
        public DbSet<Auteur> Auteurs { get; set; }
        //Table des articles
        public DbSet<Article> Articles { get; set; }

        //Configuration avancée 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Article>()
                .HasOne(a => a.Auteur) //Un article a un auteur
                .WithMany(a => a.Articles) //Un auteur a plusieurs Articles
                .HasForeignKey(a => a.AuteurId) //le lien se fait via Auteur Id
                .OnDelete(DeleteBehavior.Cascade); //Si on supprime l'auteur ses articles sont supprimés aussi

            //Contrainte : Email unique pour les utilisateurs
            // pas deux utilisateurs avec le même email
            modelBuilder.Entity<Utilisateur>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
