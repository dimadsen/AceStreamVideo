using System;
using AceStream.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Parser.Client;
using System.Globalization;
using System.Linq;
using Parser.Models.Match;
using AceStream.Extansions;
using Engine;

namespace AceStream.Services
{
    public class MatchService : IMatchService
    {
        private Client _client;
        private EngineClient _engineClient;

        public MatchService()
        {
            _client = new Client();
            _engineClient = new EngineClient();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters">Название команд, канала и т.д/</param>
        /// <returns></returns>
        public async Task<List<LinkDto>> GetLinksAsync(string[] parameters)
        {
            var links = new List<LinkDto>
            {
                new LinkDto{ Link = "https://rtmp.api.rt.com/hls/rtdru.m3u8", Name =  "Футбол 1" },
                
            };

            //foreach (var parametr in parameters)
            //{
            //    var results = await _engineClient.GetInfoHashAsync(parametr);

            //    foreach (var result in results)
            //    {
            //        var url = await _engineClient.GetPlaybackUrl(result.InfoHash);

            //        var link = new LinkDto { Link = url.PlayBackUrl, Name = result.Name };
            //    }
            //}

            return links;
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
                Half = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(matchInfo.Status.ToLower()),
                Score = $"{homeSquard.Goals} : {visitorSquard.Goals}",
                Stadium = matchInfo.Stadium.Name,

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
                Country = $"{player.Flag[0].Country}",
                Number = player.Number,
                Name = player.Name
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

    public interface IMatchService
    {
        Task<MatchDto> GetMatchAsync(int matchId);

        /// <param name="parameter">Название канала, команды и т.д.</param>
        Task<List<LinkDto>> GetLinksAsync(string[] parameter);
    }
}
