using System;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.iOS.Modules.MatchModule;
using AceStream.Services;
using AceStream.Services.Interfaces;
using AceStream.Utils;

namespace AceStream.Modules.MatchModule
{
    public class MatchInteractor : IMatchInteractor
    {
        private IMatchPresenter _presenter;
        private IMatchService _service;

        public MatchInteractor(IMatchPresenter presenter, IMatchService service)
        {
            _presenter = presenter;

            _service = service;
        }

        public async Task<MatchDto> GetMatchAsync(int matchId)
        {
            try
            {
                var match = await _service.GetMatchAsync(matchId);

                match.ImageHome = ImageUtils.DownloadFile(match.Home, match.ImageHome);
                match.ImageVisitor = ImageUtils.DownloadFile(match.Visitor, match.ImageVisitor);

                match.HomeSquard.Startings.ForEach(player => player.Flag = $"{player.Country}.png");
                match.HomeSquard.Substitutes.ForEach(player => player.Flag = $"{player.Country}.png");

                match.VisitorSquard.Startings.ForEach(player => player.Flag = $"{player.Country}.png");
                match.VisitorSquard.Substitutes.ForEach(player => player.Flag = $"{player.Country}.png");

                return match;
            }
            catch (Exception ex)
            {
                _presenter.SetError();

                return new MatchDto();
            }
        }
    }
}
