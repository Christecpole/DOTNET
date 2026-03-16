using System.Text.Json.Serialization;
using SpecieMicroService.Models;

namespace SpecieMicroService.Dto;

public class SpeciesResponseDto
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("commonname")]
    public string CommonName { get; set; }
    [JsonPropertyName("scientificname")]
    public string ScientificName { get; set; }
    [JsonPropertyName("category")]
    public string Category { get; set; }
}