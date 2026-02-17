using Articles.Api.Dtos;

namespace Articles.Api.Services
{
    public interface IArticleService
    {
        List<ArticleDto> GetAll();
        ArticleDto? GetById(int id);
        List<ArticleDto> GetByAuteurId(int auteurId);

        ArticleDto Add(ArticleCreateDto dto);
        bool Update(int id, ArticleUpdateDto dto);
        bool Delete(int id);

    }
}
