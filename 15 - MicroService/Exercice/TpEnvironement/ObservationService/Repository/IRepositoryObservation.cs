using ObservationService.Models;
using ObservationService.Models;

namespace ObservationService.Repository;

public interface IRepositoryObservation
{
    Observation Get(int id);
    List<Observation> Get();
    Observation Create(Observation observation);
    List<Observation> GetByLocation(string location);
    List<Observation> GetBySpecies(int speciesId);
    List<Observation> GetByUser(String userName);

}