using Articles.Api.Dtos;
using Articles.Api.Exceptions;
using Articles.Api.Extensions;
using Articles.Api.Repositories;

namespace Articles.Api.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _repository;
        private readonly IAuteurRepository _auteurRepository;
        public ArticleService(IArticleRepository repository, IAuteurRepository auteurRepository) 
        {
            _repository = repository;
            _auteurRepository = auteurRepository;
        }
        public async Task<ArticleDto> AddAsync(ArticleCreateDto dto)
        {
            //Verifie si l'auteur existe avant de créer l'article
            if(!await _auteurRepository.ExistsAsync(dto.AuteurId))
            {
                throw new NotFoundException($"Auteur avec l'id {dto.AuteurId} non trouvé !");
            }

            var article = dto.ToArticle();
            await _repository.AddAsync(article);

            return article.ToArticleDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var article = await _repository.GetByIdAsync(id);

            if (article == null)
            {
                throw new NotFoundException($"Impossible de supprimer : L'article {id} est introuvable.");
            }

            await _repository.DeleteAsync(id);

            return true;
        }

        public async Task<List<ArticleDto>> GetAllAsync()
        {
            var articles = await _repository.GetAllAsync();
            return articles.Select(a=>a.ToArticleDto()).ToList();
        }

        // Recupère les articles d'un auteur puis les transforme en liste de Dtos
        public async Task<List<ArticleDto>> GetByAuteurIdAsync(int auteurId)
        {
            var articles = await _repository.GetByAuteurIdAsync(auteurId);
            return articles.Select(a => a.ToArticleDto()).ToList();
        }

        // récupère un article par son Id et le trnsforme en DTO
        public async Task<ArticleDto?> GetByIdAsync(int id)
        {
            var article = await _repository.GetByIdAsync(id);
            return article?.ToArticleDto();
        }

        public async Task<bool> UpdateAsync(int id, ArticleUpdateDto dto)
        {
            var article = await _repository.GetByIdAsync(id);

            if(article == null)
            {
                throw new NotFoundException($"Impossible de modifier ! L'article {id} n'existe pas");
            }

            article.Titre = dto.Titre;
            article.Contenu = dto.Contenu;

            await _repository.UpdateAsync(article);

            return true;
        }
    }
}
