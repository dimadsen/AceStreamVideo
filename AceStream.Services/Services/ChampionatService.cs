using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Services.Extansions;
using AceStream.Dto;
using AceStream.Extansions;
using AceStream.Services.Repositories;

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

            var dto = championats
                //.Where(c => c.Matches.Select(m => m.Date.StartDate.Date).Contains(DateTime.Now.Date))
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

            return dto.Count > 0 ? dto : throw new NotFoundMatchesException("На сегодня матчей нет");

        }
    }

    public interface IChampionatService
    {
        string Title { get; }

        Task<List<ChampionatDto>> GetChampionatsAsync();
    }
}
