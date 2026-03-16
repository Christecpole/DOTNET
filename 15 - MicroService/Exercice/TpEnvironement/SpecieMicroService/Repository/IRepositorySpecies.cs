using SpecieMicroService.Models;

namespace SpecieMicroService.Repository;

public interface IRepositorySpecies
{
    Species Get(int id);
    List<Species> Get();
    Species Create(Species species);
    Species update(Species species);
    bool delete(int id);
}