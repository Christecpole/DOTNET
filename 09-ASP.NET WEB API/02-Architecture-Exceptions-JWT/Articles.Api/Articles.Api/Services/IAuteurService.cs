using Articles.Api.Dtos;

namespace Articles.Api.Services
{
    public interface IAuteurService
    {
        List<AuteurDto> GetAll();
        AuteurDto? GetById(int id);
        AuteurDto Add(AuteurCreateDto dto);
        bool Update(int id, AuteurCreateDto dto);
        bool Delete(int id);

    }
}
