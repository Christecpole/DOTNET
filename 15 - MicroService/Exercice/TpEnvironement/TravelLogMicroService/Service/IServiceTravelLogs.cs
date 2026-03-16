using TravelLogMicroService.Dto;

namespace TravelLogMicroService.Service;

public interface IServiceTravelLogs
{
    Task<List<TravelLogsResponseDto>> Get();
    Task<TravelLogsResponseDto> Get(int id);
    Task<TravelLogsResponseDto> Create(TravelLogsDto dto);

    
}