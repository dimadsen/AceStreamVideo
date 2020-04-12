using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Parser
{
    public abstract class BaseClient
    {
        private readonly HttpClient _httpClient;

        protected abstract string _baseUrl { get; } 

        public BaseClient()
        {
            _httpClient = new HttpClient();
        }

        protected async Task<T> SendGetRequest<T>(string url)
        {
            using (var response = await _httpClient.GetAsync($"{_baseUrl}/{url}"))
            {
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}
