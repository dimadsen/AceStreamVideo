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
                var match = await ParserClient.Instance.GetMatchInfoAsync("299468/online/se/?json=1");

                var matchDto = new MatchDto
                {
                    Date = DateTime.Parse(match.Date, CultureInfo.GetCultureInfo("ru")),
                    Half = match.Status,
                    Score = match.Score,

                    Home = match.HomeTeam.Name,
                    ImageHome = ImageUtils.DownloadFile(match.HomeTeam.Name, match.HomeTeam.Icon),
                    HomeSquard = new TeamDto
                    {
                        Startings = match.HomeTeam.Players.Where(player => !player.Info.IsOrderChanged()).Select(player => GetPlayers(player)).ToList(),
                        Substitutes = GetSubstitutes(match.HomeTeam)
                    },

                    VisitorSquard = new TeamDto
                    {
                        Startings = match.VisitorTeam.Players.Where(player => !player.Info.IsOrderChanged()).Select(player => GetPlayers(player)).ToList(),
                        Substitutes = GetSubstitutes(match.VisitorTeam)
                    },
                    Visitor = match.VisitorTeam.Name,
                    ImageVisitor = ImageUtils.DownloadFile(match.VisitorTeam.Name, match.VisitorTeam.Icon),

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
            var splitName = player.Name.Split(new string[] { " " }, StringSplitOptions.None);

            var dto = new PlayerDto
            {
                Flag = ImageUtils.DownloadFile(player.Country, player.Flag),
                Number = player.Info.Number,
            };

            try
            {
                dto.LastName = splitName[1];
                dto.FirstName = splitName[0];
            }
            catch (IndexOutOfRangeException)
            {
                dto.LastName = splitName[0];
                dto.FirstName = " ";
            }

            return dto;
        }

        private List<PlayerDto> GetSubstitutes(Team team)
        {
            var substitutes = team.ReservePlayers.Select(player => GetPlayers(player)).ToList();

            var isOrderChangedPlayers = team.Players.Where(player => player.Info.IsOrderChanged()).Select(player => GetPlayers(player));

            substitutes.AddRange(isOrderChangedPlayers);

            return substitutes;
        }

    }
}
