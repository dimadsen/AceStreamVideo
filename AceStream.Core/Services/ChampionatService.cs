using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStreamDb;
using AceStreamDb.Models;
using Parser.Client;

namespace AceStream.Services
{
    public class ChampionatService : IChampionatService
    {
        public string Title => "Чемпионаты";

        private Client _client;
        private DataBase _db;

        public ChampionatService()
        {
            _client = new Client();

            _db = new DataBase();
        }
        public async Task<List<ChampionatDto>> GetChampionatsAsync()
        {
            var championatsDb = _db.GetChampionats();

            var championats = await _client.GetChampionatsAsync();

            var cleanedChampionats = championats.Where(championat => championatsDb.Select(c => c.Name)
                                                                .Contains(championat.Name.Split(new string[] { ". " }, StringSplitOptions.None)[1])).ToList();

            foreach (var championat in cleanedChampionats)
            {
                var championatDb = championatsDb.FirstOrDefault(c => c.Name == championat.Name.Split(new string[] { ". " }, StringSplitOptions.None)[1]);

                var matches = championat.Matches.Select(match => new Match
                {
                    ValueId = Convert.ToInt32(match.Id),
                    Date = match.Date.StartDate.ToString("HH:mm"),
                    ChampionatId = championatDb.Id
                }).ToList();

                foreach (var match in matches)
                {
                    var m = _db.GetMatch(match.ValueId);

                    if (m == null)
                        _db.SaveMatch(match);
                }
                championat.Icon = championatDb.Icon;
            }            

            var dto = cleanedChampionats.Select(championat => new ChampionatDto
            {
                Name = championat.Name.Split(new string[] { ". " }, StringSplitOptions.None)[1],
                Tour = championat.Name.Split(new string[] { ". " }, StringSplitOptions.None)[2],
                Image = championat.Icon,
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
