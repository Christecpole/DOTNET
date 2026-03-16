using System.Text.Json.Serialization;

namespace TravelLogMicroService.Dto;

public class TravelLogsResponseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("Observation")]
    public ObservationResponseDto Observation { get; set; }
    [JsonPropertyName("distancekm")]
    public double DistanceKm { get; set; }
    [JsonPropertyName("travelmode")]
    public string TravelMode { get; set; }
    [JsonPropertyName("estimatedco2")]
    public double EstimatedCO2 { get; set; }
}