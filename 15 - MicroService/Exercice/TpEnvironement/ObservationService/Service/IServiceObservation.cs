using ObservationService.Dto;

namespace ObservationService.Service;

public interface IServiceObservation
{
    Task<List<ObservationResponseDto>> Get();
    Task<ObservationResponseDto> Get(int id);
    Task<ObservationResponseDto> Create(ObservationDto dto);
    Task<List<ObservationResponseDto>> GetByLocation(string location);
    Task<List<ObservationResponseDto>> GetBySpecies(int speciesId);
    Task<List<ObservationResponseDto>> GetByUser(string token);
    
}