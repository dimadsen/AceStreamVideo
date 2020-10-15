using System;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Extansions;
using AceStream.Services;
using AceStream.Utils;

namespace AceStream.Modules.MatchModule
{
    public class MatchInteractor : IMatchInteractor
    {
        private IMatchPresenter _presenter;
        private IMatchService _service;

        public MatchInteractor(IMatchPresenter presenter)
        {
            _presenter = presenter;

            //_service = new MatchService();
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
