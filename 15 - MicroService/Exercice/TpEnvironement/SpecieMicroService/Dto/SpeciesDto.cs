using System.Text.Json.Serialization;

namespace SpecieMicroService.Dto;

public class SpeciesDto
{
    [JsonPropertyName("commonname")]
    public string CommonName { get; set; }
    [JsonPropertyName("scientificname")]
    public string ScientificName { get; set; }
    [JsonPropertyName("category")]
    public string Category { get; set; }
}