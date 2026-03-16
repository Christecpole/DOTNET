using System.Text.Json.Serialization;

namespace Gateway.Dto;

public class ObservationDto
{
 
    [JsonPropertyName("speciesid")]
    public int SpeciesId { get; set; }
    [JsonPropertyName("observerusername")]
    public string ObserverUsername { get; set; }
    [JsonPropertyName("location")]
    public string Location { get; set; }
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
    [JsonPropertyName("observationdateStr")]
    public string ObservationDateStr { get; set; }
    [JsonPropertyName("comment")]
    public string Comment { get; set; }
}