using System.Text;
using System.Text.Json;

namespace OrderService.RestClient
{
    public class Client<TSent>
    {

        private readonly string _baseUrl;
        private readonly HttpClient _httpClient;

        public Client(string baseUrl)
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
        }

        public async Task<TSent> GetRequest (string url)
        {
            var response = await _httpClient.GetAsync (_baseUrl+url);
            if (!response.IsSuccessStatusCode) throw new Exception("Error while fetching ressource");

            var json  = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TSent>(json);
            return result ?? throw new Exception("Result null");
        }
    }
}
