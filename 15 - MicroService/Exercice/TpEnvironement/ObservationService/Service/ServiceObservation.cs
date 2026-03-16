using ObservationService.Dto;
using ObservationService.Models;
using ObservationService.Repository;
using ObservationService.RestClient;

namespace ObservationService.Service;

public class ServiceObservation : IServiceObservation
{
    private readonly IRepositoryObservation _repositoryObservation;
    private readonly Client<SpeciesResponseDto> _client;
    private readonly Client<string> _clientAuth;

    public ServiceObservation(IRepositoryObservation repositoryObservation)
    {
        _repositoryObservation = repositoryObservation;
        _client = new Client<SpeciesResponseDto>("http://localhost:5128/api/Species/");
        _clientAuth = new Client<string>("http://localhost:5037/api/Auth/me");
    }

    public async Task<List<ObservationResponseDto>> Get()
    {
        var observations = _repositoryObservation.Get();
        List<ObservationResponseDto> observationResponseDtos = new List<ObservationResponseDto>();
        foreach (var observation in observations)
        {
            observationResponseDtos.Add(await entityToDto(observation));
        }

        return observationResponseDtos;
    }

    public Task<ObservationResponseDto> Get(int id)
    {
        return entityToDto(_repositoryObservation.Get(id));
    }

    public Task<ObservationResponseDto> Create(ObservationDto dto)
    {
        return entityToDto(_repositoryObservation.Create(DtoToEntity(dto)));
    }

    public async Task<List<ObservationResponseDto>> GetByLocation(string location)
    {
        var observations = _repositoryObservation.GetByLocation(location);
        List<ObservationResponseDto> observationResponseDtos = new List<ObservationResponseDto>();
        foreach (var observation in observations)
        {
            observationResponseDtos.Add(await entityToDto(observation));
        }

        return observationResponseDtos;
    }

    public async Task<List<ObservationResponseDto>> GetBySpecies(int idSpecies)
    {
        var observations = _repositoryObservation.GetBySpecies(idSpecies);
        List<ObservationResponseDto> observationResponseDtos = new List<ObservationResponseDto>();
        foreach (var observation in observations)
        {
            observationResponseDtos.Add(await entityToDto(observation));
        }

        return observationResponseDtos;
    }

    public async Task<List<ObservationResponseDto>> GetByUser(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
        {
            throw new Exception("No Token Found");
        }

        string username = await _clientAuth.GetRequestWithToken("", token); 
        
        var observations = _repositoryObservation.GetByUser(username);
        List<ObservationResponseDto> observationResponseDtos = new List<ObservationResponseDto>();
        foreach (var observation in observations)
        {
            observationResponseDtos.Add(await entityToDto(observation));
        }

        return observationResponseDtos;
    }


    private Observation DtoToEntity(ObservationDto observationDto)
    {
        return new Observation()
        {
            Comment = observationDto.Comment,
            Latitude = observationDto.Latitude,
            Longitude = observationDto.Longitude,
            Location = observationDto.Location,
            ObserverUsername = observationDto.ObserverUsername,
            ObservationDate = DateOnly.Parse(observationDto.ObservationDateStr),
            SpeciesId = observationDto.SpeciesId
        };
    }

    private async Task<ObservationResponseDto> entityToDto(Observation observation)
    {
        return new ObservationResponseDto()
        {
            Id = observation.Id,
            Longitude = observation.Longitude,
            Latitude = observation.Latitude,
            Location = observation.Location,
            ObservationDate = observation.ObservationDate,
            ObserverUsername = observation.ObserverUsername,
            Species = await _client.GetRequest(observation.SpeciesId.ToString()),
        };
    }
}