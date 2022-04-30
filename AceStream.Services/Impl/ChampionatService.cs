using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Services.Interfaces;
using AceStream.Services.Clients;

namespace AceStream.Services
{
    public class ChampionatService : IChampionatService
    {
        private ISourceClient _client;

        public ChampionatService(ISourceClient client)
        {
            _client = client;
        }

        public async Task<List<ChampionatDto>> GetChampionatsAsync()
        {
            var championats = await _client.GetChampionatsAsync();

            return championats;
        }
    }
}
