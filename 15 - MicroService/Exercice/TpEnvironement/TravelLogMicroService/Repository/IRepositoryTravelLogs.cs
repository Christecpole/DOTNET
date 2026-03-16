using TravelLogMicroService.Models;

namespace TravelLogMicroService.Repository;

public interface IRepositoryTravelLogs
{
    TravelLogs Get(int id);
    List<TravelLogs> Get();
    TravelLogs Create(TravelLogs observation);
}