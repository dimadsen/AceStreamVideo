using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AceStream.Core.Extansions;
using AceStream.Dto;
using AceStream.Extansions;
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

            //Отбираем только нужные чемпионаты
            var cleanedChampionats = championats.Where(c => championatsDb.Select(cdb => cdb.Name).Contains(c.Name.Split(1, ". ")) &&
                                                            championatsDb.Select(cdb => cdb.Country).Contains(c.Country)).ToList();

            foreach (var championat in cleanedChampionats)
            {
                SaveMatches(championat, championatsDb);
            }

            var dto = cleanedChampionats.Where(c => c.Matches.Select(m => m.Date.StartDate.Date).Contains(DateTime.Now.Date))
                .Select(c => new ChampionatDto
                {
                    Name = c.Name.Split(1, ". ").Clear(),
                    Tour = c.Name.Split(2, ". "),
                    Country = c.Country,
                    Image = c.Icon,
                    Id = championatsDb.FirstOrDefault(cdb => cdb.Name == c.Name.Split(1, ". ") && cdb.Country == c.Country).Id
                }).Distinct().ToList();

            return dto.Count > 0 ? dto : throw new NotFoundMatchesException("На сегодня матчей нет");

        }

        private void SaveMatches(Parser.Tournament.Championat championat, List<Championat> championatsDb)
        {
            var championatDb = championatsDb.FirstOrDefault(c => c.Name == championat.Name.Split(1, ". ") && c.Country == championat.Country);

            var matches = championat.Matches.Select(match => new Match
            {
                ValueId = Convert.ToInt32(match.Id),
                Date = match.Date.StartDate.ToString(),
                ChampionatId = championatDb.Id,
                Home = match.Home.Name,
                HomeIcon = match.Home.Icon,
                Visitor = match.Visitor.Name,
                VisitorIcon = match.Visitor.Icon,
                Score = match.Score,
                Status = match.Status.Name,
            }).ToList();

            foreach (var match in matches)
            {
                var existingMatch = _db.GetMatch(match.ValueId);

                if (existingMatch == null)
                    _db.SaveMatch(match);
            }

            championat.Icon = championatDb.Icon;
        }
    }

    public interface IChampionatService
    {
        string Title { get; }

        Task<List<ChampionatDto>> GetChampionatsAsync();
    }
}
