using System.Text.Json.Serialization;

namespace ServiceVoyage.Dto
{
    public class VoyageReceive
    {
        [JsonPropertyName("destination")]
        public string Destination { get; set; }
        [JsonPropertyName("datedepartstr")]
        public string DateDepartStr { get; set; }
        [JsonPropertyName("prix")]
        public double Prix { get; set; }
    }
}
