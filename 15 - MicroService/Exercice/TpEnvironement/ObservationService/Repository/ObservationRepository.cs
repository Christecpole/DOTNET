using ObservationService.Data;
using ObservationService.Exceptions;
using ObservationService.Models;


namespace ObservationService.Repository;

public class ObservationRepository : IRepositoryObservation
{
    private readonly AppDbContext _dbContext;

    public ObservationRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Observation Get(int id)
    {
        var found = _dbContext.Observations.Find(id);
        
        return found ?? throw new NotFoundException("Species not found");
    }

    public List<Observation> Get()
    {
        return _dbContext.Observations.ToList();
    }

    public Observation Create(Observation observation)
    {
        _dbContext.Add(observation);
        _dbContext.SaveChanges();
        return observation;
    }

    public List<Observation> GetByLocation(string location)
    {
        return _dbContext.Observations.Where(o => o.Location == location).ToList();
    }

    public List<Observation> GetBySpecies(int speciesId)
    {
        return _dbContext.Observations.Where(o => o.SpeciesId == speciesId).ToList();
    }

    public List<Observation> GetByUser(string userName)
    {
        return _dbContext.Observations.Where(o => o.ObserverUsername == userName).ToList();
    }
}