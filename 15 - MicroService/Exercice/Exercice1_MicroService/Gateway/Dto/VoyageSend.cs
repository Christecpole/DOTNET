using System.Text.Json.Serialization;

namespace Gateway.Dto
{
    public class VoyageSend
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("destination")]
        public string Destination { get; set; }
        [JsonPropertyName("datedepart")]
        public DateOnly DateDepart { get; set; }
        [JsonPropertyName("prix")]
        public double Prix { get; set; }
    }
}
