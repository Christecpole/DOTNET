using Articles.Api.Models;

namespace Articles.Api.Repositories
{
    // Task => retourne une promesse
    // Je te donnerai un auteur par exemple plus tard quand j'aurai fini
    // Convention : ajout de asyn à la fin du nom de la methode
    public interface IAuteurRepository
    {
        Task<List<Auteur>> GetAllAsync();
        Task<Auteur?> GetByIdAsync(int id);
        Task AddAsync(Auteur auteur);
        Task UpdateAsync(Auteur auteur);
        Task DeleteAsync(int id);

        //Vérifier si un auteur existe 
        Task<bool> ExistsAsync(int id);
    }
}
