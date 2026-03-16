using SpecieMicroService.Data;
using SpecieMicroService.Exceptions;
using SpecieMicroService.Models;

namespace SpecieMicroService.Repository;

public class SpeciesRepository : IRepositorySpecies
{
    private readonly AppDbContext _dbContext;

    public SpeciesRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Species Get(int id)
    {
        var found = _dbContext.Species.Find(id);
        
        return found ?? throw new NotFoundException("Species not found");
    }

    public List<Species> Get()
    {
        return _dbContext.Species.ToList();
    }

    public Species Create(Species species)
    {
        _dbContext.Add(species);
        _dbContext.SaveChanges();
        return species;
    }

    public Species update(Species species)
    {
        _dbContext.Species.Update(species);
        _dbContext.SaveChanges();
        return species;
    }

    public bool delete(int id)
    {
        var found = Get(id);
        _dbContext.Species.Remove(found);
        return true;
    }
}