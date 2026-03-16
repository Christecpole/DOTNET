using SpecieMicroService.Dto;

namespace SpecieMicroService.Service;

public interface ISpecieService
{
    List<SpeciesResponseDto> Get();
    SpeciesResponseDto Get(int id);
    SpeciesResponseDto Create(SpeciesDto dto);
    SpeciesResponseDto Update(SpeciesUpdateDto dto);
    bool Delete(int id);
}