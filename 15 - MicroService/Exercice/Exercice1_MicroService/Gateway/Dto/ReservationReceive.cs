using ReservationService.Dto;
using System.Text.Json.Serialization;

namespace Gateway.Dtos
{
    public class ReservationReceive
    {
        [JsonPropertyName("voyageid")]
        public int VoyageId { get; set; }
        [JsonPropertyName("nomclient")]
        public string NomClient { get; set; }
        [JsonPropertyName("nombreplaces")]
        public int NombrePlaces { get; set; }
    }
}
