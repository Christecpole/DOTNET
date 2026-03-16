using System.Text.Json.Serialization;

namespace Gateway.Dto;

public class TravelLogsDto
{
    [JsonPropertyName("Observationid")]
    public int ObservationId { get; set; }
    [JsonPropertyName("distancekm")]
    public double DistanceKm { get; set; }
    [JsonPropertyName("travelmodestr")]
    public string TravelModeStr { get; set; }
}