using SpecieMicroService.Dto;
using SpecieMicroService.Models;
using SpecieMicroService.Repository;

namespace SpecieMicroService.Service;

public class SpeciesService:ISpecieService
{
    private readonly IRepositorySpecies _repositorySpecies;

    public SpeciesService(IRepositorySpecies repositorySpecies)
    {
        _repositorySpecies = repositorySpecies;
    }

    public List<SpeciesResponseDto> Get()
    {
        var species = _repositorySpecies.Get();
        List<SpeciesResponseDto> speciesResponseDtos = new List<SpeciesResponseDto>();
        foreach (var specie in species)
        {
            speciesResponseDtos.Add(EntityToDto(specie));
        }

        return speciesResponseDtos;
    }

    public SpeciesResponseDto Get(int id)
    {
        return EntityToDto(_repositorySpecies.Get(id));
    }

    public SpeciesResponseDto Create(SpeciesDto dto)
    {
        return EntityToDto(_repositorySpecies.Create(DtoToEntity(dto)));
    }

    public SpeciesResponseDto Update(SpeciesUpdateDto dto)
    {
        Category.TryParse(dto.Category, out Category category);

        Species species = new Species()
        {
            Id = dto.Id,
            Category = category,
            CommonName = dto.CommonName,
            ScientificName = dto.ScientificName,
        };
        return EntityToDto(_repositorySpecies.update(species));
    }

    public bool Delete(int id)
    {
        _repositorySpecies.delete(id);
        return true;
    }

    private Species DtoToEntity(SpeciesDto dto)
    {
        Category.TryParse(dto.Category, out Category category);

        return new Species()
        {
            Category = category,
            CommonName = dto.CommonName,
            ScientificName = dto.ScientificName
        };
    }

    private SpeciesResponseDto EntityToDto(Species species)
    {
        return new SpeciesResponseDto()
        {
            Id = species.Id,
            Category = species.Category.ToString(),
            CommonName = species.CommonName,
            ScientificName = species.ScientificName,
        };
    }
}