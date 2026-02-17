using Articles.Api.Models;

namespace Articles.Api.Repositories
{
    public interface IAuteurRepository
    {
        List<Auteur> GetAll();
        Auteur? GetById(int id);
        void Add(Auteur auteur);
        void Update(Auteur auteur);
        void Delete(int id);
    }
}
