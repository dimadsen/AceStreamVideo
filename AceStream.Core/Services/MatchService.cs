using System;
using AceStream.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Parser.Client;
using System.Globalization;
using System.Linq;
using Parser.Models.Match;

namespace AceStream.Services
{
    public class MatchService : IMatchService
    {
        private Client _client;

        public MatchService()
        {
            _client = new Client();
        }

        public async Task<List<LinkDto>> GetLinksAsync(string[] parameter)
        {
            var links = new List<LinkDto>
            {
                new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Футбол 1" },
                new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Матч ТВ" },
                new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Футбол 2" },
                new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Футбол 3" },
                new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Матч Арена" },
            };

            var task = Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromMilliseconds(1000), new CancellationToken());

                return links;
            });

            return await task;
        }

        public async Task<MatchDto> GetMatchAsync(int matchId)
        {
            var matchInfo = await _client.GetMatchInfoAsync(1368632);

            var teams = await _client.GetTeamsAsync(1368632);

            var homeSquard = teams.Teams[0];
            var visitorSquard = teams.Teams[1];

            var matchDto = new MatchDto
            {
                Date = DateTime.Parse(matchInfo.Date.StartDate, CultureInfo.GetCultureInfo("ru")),
                Half = matchInfo.Status,
                Score = $"{homeSquard.Goals} : {visitorSquard.Goals}",

                Home = homeSquard.Name,
                ImageHome = homeSquard.Icon,
                HomeSquard = new TeamDto
                {
                    Startings = homeSquard.Startings.Where(p => !p.IsReplacement).Select(p => GetPlayers(p)).ToList(),
                    Substitutes = GetSubstitutes(homeSquard)
                },

                Visitor = visitorSquard.Name,
                ImageVisitor = visitorSquard.Icon,
                VisitorSquard = new TeamDto
                {
                    Startings = visitorSquard.Startings.Where(p => !p.IsReplacement).Select(p => GetPlayers(p)).ToList(),
                    Substitutes = GetSubstitutes(visitorSquard)
                },
            };

            return matchDto;
        }

        private PlayerDto GetPlayers(Player player)
        {
            var dto = new PlayerDto
            {
                Country = $"{player.Flag[0].Country}",
                Number = player.Number,
                Name = player.Name
            };

            return dto;
        }

        private List<PlayerDto> GetSubstitutes(Team team)
        {
            var substitutes = team.Substitutes.SelectMany(players => players.Select(player => GetPlayers(player))).ToList();

            var isReplacementPlayers = team.Startings.Where(p => p.IsReplacement).Select(p => GetPlayers(p));

            substitutes.AddRange(isReplacementPlayers);

            return substitutes;
        }
    }

    public interface IMatchService
    {
        Task<MatchDto> GetMatchAsync(int matchId);

        /// <param name="parameter">Название канала, команды и т.д.</param>
        Task<List<LinkDto>> GetLinksAsync(string[] parameter);
    }
}
