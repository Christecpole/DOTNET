using TravelLogMicroService.Exceptions;
using TravelLogMicroService.Data;
using TravelLogMicroService.Models;


namespace TravelLogMicroService.Repository;

public class TravelLogsRepository : IRepositoryTravelLogs
{
    private readonly AppDbContext _dbContext;

    public TravelLogsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public TravelLogs Get(int id)
    {
        var found = _dbContext.TravelLogs.Find(id);
        
        return found ?? throw new NotFoundException("Species not found");
    }

    public List<TravelLogs> Get()
    {
        return _dbContext.TravelLogs.ToList();
    }

    public TravelLogs Create(TravelLogs observation)
    {
        _dbContext.Add(observation);
        _dbContext.SaveChanges();
        return observation;
    }

}