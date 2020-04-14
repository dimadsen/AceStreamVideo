using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Services;
using AceStream.Utils;
using Parser.Models.Match;

namespace AceStream.Modules.MatchModule
{
    public class MatchInteractor : IMatchInteractor
    {
        private IMatchPresenter _presenter;
        private IMatchService _service;

        public MatchInteractor(IMatchPresenter presenter)
        {
            _presenter = presenter;

            _service = new MatchService();
        }

        public async Task<MatchDto> GetMatchAsync(int matchId)
        {
            try
            {
                var matchInfo = await ParserClient.Instance.GetMatchInfoAsync("1368632");

                var teams = await ParserClient.Instance.GetTeamsAsync("1368632");

                var homeSquard = teams.Teams[0];
                var visitorSquard = teams.Teams[1];

                var matchDto = new MatchDto
                {
                    Date = DateTime.Parse(matchInfo.Date.StartDate, CultureInfo.GetCultureInfo("ru")),
                    Half = matchInfo.Status,
                    Score = $"{homeSquard.Goals} : {visitorSquard.Goals}",

                    Home = homeSquard.Name,
                    ImageHome = ImageUtils.DownloadFile(homeSquard.Name, homeSquard.Icon),
                    HomeSquard = new TeamDto
                    {
                        Startings = homeSquard.Startings.Where(p => !p.IsReplacement).Select(p => GetPlayers(p)).ToList(),
                        Substitutes = GetSubstitutes(homeSquard)
                    },
                    
                    Visitor = visitorSquard.Name,
                    ImageVisitor = ImageUtils.DownloadFile(visitorSquard.Name, visitorSquard.Icon),
                    VisitorSquard = new TeamDto
                    {
                        Startings = visitorSquard.Startings.Where(p => !p.IsReplacement).Select(p => GetPlayers(p)).ToList(),
                        Substitutes = GetSubstitutes(visitorSquard)
                    },
                };

                return matchDto;
            }
            catch (Exception ex)
            {
                _presenter.SetError();

                return new MatchDto();
            }
        }

        private PlayerDto GetPlayers(Player player)
        {
            var dto = new PlayerDto
            {
                Flag = $"{player.Flag[0].Country}.png",
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
}
