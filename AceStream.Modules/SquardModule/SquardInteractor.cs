using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Core.Domain.Match;
using AceStream.Core.Exceptions;
using AceStream.Dto;
using AceStream.Services.Clients;
using AceStream.Services.Dto;

namespace AceStream.iOS.Modules.SquardModule
{
    public class SquardInteractor : ISquardInteractor
    {
        private IClient _client;

        public SquardInteractor(IClient client)
        {
            _client = client;
        }

        public async Task<SquardDto> GetSquardsAsync(int matchId)
        {
            var teams = await _client.GetTeamsAsync(matchId);

            var homeSquard = teams.Teams[0];
            var visitorSquard = teams.Teams[1];

            var squardDto = new SquardDto
            {
                HomeSquard = new TeamDto
                {
                    Startings = homeSquard.Startings.Where(p => IsStartings(p)).Select(p => GetPlayers(p)).ToList(),
                    Substitutes = GetSubstitutes(homeSquard)
                },
                VisitorSquard = new TeamDto
                {
                    Startings = visitorSquard.Startings.Where(p => IsStartings(p)).Select(p => GetPlayers(p)).ToList(),
                    Substitutes = GetSubstitutes(visitorSquard)
                },
            };

            return squardDto.HomeSquard.Startings.Count == 11 && squardDto.VisitorSquard.Startings.Count == 11 ?
                squardDto : throw new PlayersNotFoundException();
        }

        private PlayerDto GetPlayers(Player player)
        {
            var dto = new PlayerDto
            {
                Number = player.Number,
                Name = player.Name,
                Country = player.Flag.FirstOrDefault()?.Country,
                Flag = $"{player.Flag.FirstOrDefault()?.Country}.png"
            };

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
