using System.Text.Json;

namespace ReservationService.Client
{
    public class RestClient<TGet>
    {
        private readonly string _BaseUrl;
        private readonly HttpClient _client;

        public RestClient(string baseUrl)
        {
            this._BaseUrl = baseUrl;
            _client = new HttpClient();
        }

        public async Task<TGet> GetRequest(string url)
        {
            var response = await _client.GetAsync(_BaseUrl + url);
            if (!response.IsSuccessStatusCode) throw new Exception("Error while fetching ressource");

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TGet>(json);
            return result ?? throw new Exception("Result Null");
        }
    }
}
