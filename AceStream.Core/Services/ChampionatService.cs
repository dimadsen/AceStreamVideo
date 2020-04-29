using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AceStream.Dto;
using Parser.Client;

namespace AceStream.Services
{
    public class ChampionatService : IChampionatService
    {
        public string Title => "Чемпионаты";

        private Client _client;

        public ChampionatService()
        {
            _client = new Client();
        }
        public async Task<List<ChampionatDto>> GetChampionatsAsync()
        {
            var championats = await _client.GetChampionatsAsync();

            var dto = championats.Select(championat => new ChampionatDto
            {
                Name = championat.Name.Split(new string[] { ". " }, StringSplitOptions.None)[1],
                Tour = championat.Name.Split(new string[] { ". " }, StringSplitOptions.None)[2],
                Image = championat.Icon,
                Matches = championat.Matches.Select(match => new MatchPreviewDto
                {
                    Id = match.Id,
                    Time = match.Date.StartDate.ToString("HH:mm"),
                    Home = match.Home.Name,
                    HomePicture = match.Home.Icon,
                    Visitor = match.Visitor.Name,
                    VisitorPicture = match.Visitor.Icon
                }).ToList()

            }).ToList();            

            return dto;
        }
    }

    public interface IChampionatService
    {
        string Title { get; }

        Task<List<ChampionatDto>> GetChampionatsAsync();
    }
}
