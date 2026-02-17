using Articles.Api.Dtos;

namespace Articles.Api.Services
{
    public interface IAuteurService
    {
        Task<List<AuteurDto>> GetAllAsync();
        Task<AuteurDto?> GetByIdAsync(int id);
        Task<AuteurDto> AddAsync(AuteurCreateDto dto);
        Task<AuteurDto?> UpdateAsync(int id, AuteurCreateDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
