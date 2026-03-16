using ObservationService.RestClient;
using TravelLogMicroService.Dto;
using TravelLogMicroService.Models;
using TravelLogMicroService.Repository;
using TravelLogMicroService.Service;

namespace TravelLogMicroService.Service;

public class ServiceTravelLogs : IServiceTravelLogs
{
    private readonly IRepositoryTravelLogs _repositoryTravelLogs;
    private readonly Client<ObservationResponseDto> _client;

    public ServiceTravelLogs(IRepositoryTravelLogs repositoryTravelLogs)
    {
        _repositoryTravelLogs = repositoryTravelLogs;
        _client = new Client<ObservationResponseDto>("http://localhost:5169/api/Observation/");

    }

    public async Task<List<TravelLogsResponseDto>> Get()
    {
        var observations = _repositoryTravelLogs.Get();
        List<TravelLogsResponseDto> observationResponseDtos = new List<TravelLogsResponseDto>();
        foreach (var observation in observations)
        {
            observationResponseDtos.Add(await entityToDto(observation));
        }

        return observationResponseDtos;
    }

    public async Task<TravelLogsResponseDto> Get(int id)
    {
        return await entityToDto(_repositoryTravelLogs.Get(id));
    }

    public async Task<TravelLogsResponseDto> Create(TravelLogsDto dto)
    {
        return await entityToDto(_repositoryTravelLogs.Create(DtoToEntity(dto)));
    }

    


    private TravelLogs DtoToEntity(TravelLogsDto dto)
    {
        
        TravelMode.TryParse(dto.TravelModeStr, out TravelMode mode);
        TravelLogs travelLogs = new TravelLogs()
        {
            ObservationId = dto.ObservationId,
            DistanceKm = dto.DistanceKm,
            TravelMode = mode,
        };
        
        travelLogs.ClalcEstimatedCO2();
        return travelLogs;

    }

    private async Task<TravelLogsResponseDto> entityToDto(TravelLogs travelLogs)
    {
        return new TravelLogsResponseDto()
        {
            Id = travelLogs.Id,
            Observation = await _client.GetRequest(travelLogs.ObservationId.ToString()),
            DistanceKm = travelLogs.DistanceKm,
            TravelMode = travelLogs.TravelMode.ToString(),
            EstimatedCO2 = travelLogs.EstimatedCO2,
        };
    }
}