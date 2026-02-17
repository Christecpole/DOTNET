using Articles.Api.Dtos;

namespace Articles.Api.Services
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllAsync();
        Task<ArticleDto?> GetByIdAsync(int id);
        Task<List<ArticleDto>> GetByAuteurIdAsync(int auteurId);

        Task<ArticleDto> AddAsync(ArticleCreateDto dto);
        Task<bool> UpdateAsync(int id, ArticleUpdateDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
