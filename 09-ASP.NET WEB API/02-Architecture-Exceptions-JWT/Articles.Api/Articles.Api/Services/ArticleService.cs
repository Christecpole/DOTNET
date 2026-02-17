using Articles.Api.Dtos;
using Articles.Api.Exceptions;
using Articles.Api.Extensions;
using Articles.Api.Repositories;

namespace Articles.Api.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _repository;
        public ArticleService(IArticleRepository repository) 
        {
            _repository = repository;
        }
        public ArticleDto Add(ArticleCreateDto dto)
        {
            var article = dto.ToArticle();

            _repository.Add(article);

            return article.ToArticleDto();
        }

        public bool Delete(int id)
        {
            var article = _repository.GetById(id);

            if (article == null)
            {
                throw new NotFoundException($"Impossible de supprimer : L'article {id} est introuvable.");
            }

            _repository.Delete(id);

            return true;
        }

        public List<ArticleDto> GetAll()
        {
            return _repository.GetAll().Select(a=>a.ToArticleDto()).ToList();
        }

        // Recupère les articles d'un auteur puis les transforme en liste de Dtos
        public List<ArticleDto> GetByAuteurId(int auteurId)
        {
            return _repository.GetByAuteurId(auteurId).Select(a => a.ToArticleDto()).ToList();
        }

        // récupère un article par son Id et le trnsforme en DTO
        public ArticleDto? GetById(int id)
        {
            var article = _repository.GetById(id);

            if (article == null)
            {
                throw new NotFoundException($"L'article avec l'id {id} n'existe pas");
            }

            return article.ToArticleDto();
        }

        public bool Update(int id, ArticleUpdateDto dto)
        {
            var article = _repository.GetById(id);

            if(article == null)
            {
                throw new NotFoundException($"Impossible de mofifier ! L'article {id} n'existe pas");
            }

            article.Titre = dto.Titre;
            article.Contenu = dto.Contenu;

            _repository.Update(article);

            return true;
        }
    }
}
