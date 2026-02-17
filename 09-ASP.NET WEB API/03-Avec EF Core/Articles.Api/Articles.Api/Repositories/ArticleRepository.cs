using Articles.Api.Data;
using Articles.Api.Models;
using Articles.Api_AvecBDD.Data;
using Microsoft.EntityFrameworkCore;

namespace Articles.Api.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _context;

        public ArticleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Article article)
        {
            _context.Add(article); // Comme une liste d'attente, l'article est marqué comme "à ajouter"

            await _context.SaveChangesAsync(); // sauvegarde en bdd

            await _context.Entry(article).Reference(a => a.Auteur).LoadAsync();//Charger l'auteur pour le retour, Après l'ajout article.Ateur est vide on n'a passé que l'idAuteur, LoadAsync va chercher l'auteur en bdd de manière asynchrone, comme ça le dto de retour aura le nom de l'auteur
        }

        public async Task DeleteAsync(int id)
        {
            var article = await _context.Articles.FindAsync(id);

            if(article != null)
            {
                _context.Articles.Remove(article); // Marqué comme "à supprimer" en liste d'attente

                //Envoie la commande DELETE à mysql
                await _context.SaveChangesAsync();
            }
            // Si article est null on ne fait rien (pas d'erreur)

        }

        // Recupérer liste d'articles de la bdd
        // "async" => cette methode contient des opérations asynchrones
        // "await" => Attends le resultat sans bloquer le reste des taches , des threads
        public async Task<List<Article>> GetAllAsync()
        {
            return await _context.Articles
                .Include(a => a.Auteur) // Charge l'auteur de chaque article
                .ToListAsync(); // Execute la requete de manière asynchrone
        }

        public async Task<List<Article>> GetByAuteurIdAsync(int auteurId)
        {
            return await _context.Articles.Include(a => a.Auteur).Where(a => a.AuteurId == auteurId).ToListAsync();
        }

        public async Task<Article?> GetByIdAsync(int id)
        {
            return await _context.Articles.Include(a => a.Auteur).FirstOrDefaultAsync(a=>a.Id == id);
        }

        public async Task UpdateAsync(Article article)
        {
            _context.Articles.Update(article);// Comme une liste d'attente, l'article est marqué comme "à modifier"
            await _context.SaveChangesAsync();// envoie la commande Update à mysql
        }
    }
}
