using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Services.Interfaces;
using AceStream.Services.Clients;

namespace AceStream.Services
{
    public class ChampionatService : IChampionatService
    {
        public string Title => "Чемпионаты";

        private IClient _client;

        public ChampionatService(IClient client)
        {
            _client = client;
        }

        public async Task<List<ChampionatDto>> GetChampionatsAsync()
        {
            var championats = await _client.GetChampionatsAsync();

            var dto = championats?
                .Select(c => new ChampionatDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Tour = c.Tour,
                    Country = c.Country,
                    Image = c.Icon,                    
                })
                .Distinct()
                .ToList();

            return dto;
        }
    }
}
