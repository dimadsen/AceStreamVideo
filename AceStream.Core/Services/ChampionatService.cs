﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Core.Extansions;
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

            //Отбираем только нужные чемпионаты
            var cleanedChampionats = championats.Where(c => championatsDb.Select(cdb => cdb.Name).Contains(c.Name.Split(1))).ToList();

            cleanedChampionats.ForEach(championat => SaveMatches(championat, championatsDb));

            var dto = cleanedChampionats.Select(c => new ChampionatDto
            {
                Name = c.Name.Split(1),
                Tour = c.Name.Split(2),
                Country = c.Country,
                Image = c.Icon,
                Id = championatsDb.FirstOrDefault(cdb => cdb.Name == c.Name.Split(1) && cdb.Country == c.Country).Id
            }).Distinct().ToList();

            return dto;
        }

        private void SaveMatches(Parser.Tournament.Championat championat, List<Championat> championatsDb)
        {
            var championatDb = championatsDb.FirstOrDefault(c => c.Name == championat.Name.Split(1) && c.Country == championat.Country);

            var matches = championat.Matches.Select(match => new Match
            {
                ValueId = Convert.ToInt32(match.Id),
                Date = match.Date.StartDate.ToString("HH:mm"),
                ChampionatId = championatDb.Id,
                Home = match.Home.Name,
                HomeIcon = match.Home.Icon,
                Visitor = match.Visitor.Name,
                VisitorIcon = match.Visitor.Icon
            }).ToList();

            matches.ForEach(match =>
            {
                var existingMatch = _db.GetMatch(match.ValueId);

                if (existingMatch == null)
                    _db.SaveMatch(match);
            });

            championat.Icon = championatDb.Icon;
        }
    }

    public interface IChampionatService
    {
        string Title { get; }

        Task<List<ChampionatDto>> GetChampionatsAsync();
    }
}
