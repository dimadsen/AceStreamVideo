using System.Net.Http;
using System.Threading.Tasks;
using Engine.Models;
using Newtonsoft.Json;

namespace Engine
{
    public class EngineClient 
    {
        private readonly HttpClient _httpClient;

        public EngineClient()
        {
            _httpClient = new HttpClient();
        }

        private async Task<T> SendGetRequest<T>(string url)
        {
            using (var response = await _httpClient.GetAsync($"{url}"))
            {
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public async Task<Result[]> GetInfoHashAsync(string query)
        {
            var url = $"https://search.acestream.net?method=search&api_version=1.0&api_key=test_api_key&query={query}";

            var result = await SendGetRequest<Search>(url);

            return result.Results;
        }

        public async Task<Url> GetPlaybackUrl(string infohash)
        {
            var url = $"http://192.168.1.33:6878/ace/manifest.m3u8?format=json&id={infohash}";

            var result = await SendGetRequest<Url>(url);

            return result;
        }
    }
}
