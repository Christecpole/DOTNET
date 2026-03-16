
using Gateway.Dto;
using System.Text.Json.Serialization;

namespace Gateway.Dtos
{
    public class ReservationSend
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("voyage")]
        public VoyageSend Voyage { get; set; }
        [JsonPropertyName("nomclient")]
        public string NomClient { get; set; }
        [JsonPropertyName("nombreplaces")]
        public int NombrePlaces { get; set; }
    }
}
