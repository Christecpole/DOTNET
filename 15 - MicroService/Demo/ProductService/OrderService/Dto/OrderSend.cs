
using OrderService.Dtos;
using System.Text.Json.Serialization;

namespace OrderService.Dto
{
    public class OrderSend()
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("commandenumber")]
        public string CommandeNumber { get; set; }
        [JsonPropertyName("product")]
        public List<ProductSend> Product { get; set; } = new List<ProductSend>();
    }
}
