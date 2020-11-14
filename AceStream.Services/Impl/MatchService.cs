﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Core.Domain.Enums;
using AceStream.Core.Domain.Match;
using AceStream.Dto;
using AceStream.Services.Extansions;
using AceStream.Services.Clients;
using AceStream.Services.Interfaces;

namespace AceStream.Services
{
    public class MatchService : IMatchService
    {
        private IClient _client;

        public MatchService(IClient client)
        {
            _client = client;
        }

        public async Task<MatchDto> GetMatchAsync(int matchId)
        {
            var matchInfo = await _client.GetMatchInfoAsync(matchId);

            var teams = await _client.GetTeamsAsync(matchId);

            var homeSquard = teams.Teams[0];
            var visitorSquard = teams.Teams[1];

            var matchDto = new MatchDto
            {
                Date = DateTime.Parse(matchInfo.Date.StartDate, CultureInfo.GetCultureInfo("ru")),
                Half = matchInfo.Status,
                Score = $"{homeSquard.Goals} : {visitorSquard.Goals}",
                Minute = teams.Time.Split(0, ":"),
                Status = (MatchStatus)teams.Status,
                Stadium = matchInfo.Stadium.Name,
                Channels = matchInfo.Channels.Select(c => c.Name).ToArray(),

                Home = homeSquard.Name,
                ImageHome = homeSquard.Icon,
                HomeSquard = new TeamDto
                {
                    Startings = homeSquard.Startings.Where(p => IsStartings(p)).Select(p => GetPlayers(p)).ToList(),
                    Substitutes = GetSubstitutes(homeSquard)
                },

                Visitor = visitorSquard.Name,
                ImageVisitor = visitorSquard.Icon,
                VisitorSquard = new TeamDto
                {
                    Startings = visitorSquard.Startings.Where(p => IsStartings(p)).Select(p => GetPlayers(p)).ToList(),
                    Substitutes = GetSubstitutes(visitorSquard)
                },
            };

            return matchDto;
        }

        private PlayerDto GetPlayers(Player player)
        {
            var dto = new PlayerDto
            {
                Number = player.Number,
                Name = player.Name
            };

            try { dto.Country = $"{player.Flag[0].Country}"; }
            catch (Exception) { }

            return dto;
        }

        private List<PlayerDto> GetSubstitutes(Team team)
        {
            var substitutes = team.Substitutes.SelectMany(players => players.Select(player => GetPlayers(player))).ToList();

            var isReplacementPlayers = team.Startings.Where(p => !IsStartings(p)).Select(p => GetPlayers(p));

            substitutes.AddRange(isReplacementPlayers);

            return substitutes;
        }

        private bool IsStartings(Player player)
        {
            var isStarting = (!player.IsReplacement && string.IsNullOrEmpty(player.Replaced)) ||
                      (player.IsReplacement && !string.IsNullOrEmpty(player.Replacement));

            return isStarting;
        }
    }
}
