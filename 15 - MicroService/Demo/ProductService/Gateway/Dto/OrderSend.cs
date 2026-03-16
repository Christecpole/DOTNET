using Gateway.Dtos;
using System.Text.Json.Serialization;

namespace Gateway.Dto
{
    public class OrderSend()
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("commandenumber")]
        public string CommandeNumber { get; set; }
        [JsonPropertyName("product")]
        public List<ProductSend> Product { get; set; }
    }
}
