using Articles.Api.Models;

namespace Articles.Api.Repositories
{
    public interface IArticleRepository
    {
        List<Article> GetAll();
        Article? GetById(int id);
        List<Article> GetByAuteurId(int auteurId);

        void Add(Article article);
        void Update(Article article);
        void Delete(int id);
    }
}
