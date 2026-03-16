using System.Text.Json.Serialization;

namespace Gateway.Dto;

public class ObservationResponseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("species")]
    public SpeciesResponseDto Species { get; set; }
    [JsonPropertyName("observerusername")]
    public string ObserverUsername { get; set; }
    [JsonPropertyName("location")]
    public string Location { get; set; }
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
    [JsonPropertyName("observationdate")]
    public DateOnly ObservationDate { get; set; }
    [JsonPropertyName("comment")]
    public string Comment { get; set; }
}