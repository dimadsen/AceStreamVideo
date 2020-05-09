using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;
using AceStream.Services;
using AceStream.Utils;

namespace AceStream.Modules.MatchPreviewModule
{
    public class MatchPreviewInteractor : IMatchPreviewInteractor
    {
        private IMatchPreviewPresenter _presenter;
        private IMatchPreviewService _service;

        public MatchPreviewInteractor(IMatchPreviewPresenter presenter)
        {
            _presenter = presenter;
            _service = new MatchPreviewService();
        }

        public async Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId)
        {
            try
            {
                var matches = await _service.GetMatchesAsync(championatId);

                matches.ForEach(match =>
                {
                    match.HomePicture = ImageUtils.DownloadFile(match.Home, match.HomePicture);
                    match.VisitorPicture = ImageUtils.DownloadFile(match.Visitor, match.VisitorPicture);
                });

                return matches;
            }
            catch (Exception)
            {
                _presenter.SetError();

                return new List<MatchPreviewDto>();
            }
        }

        public MatchPreviewSettingsDto GetSettings(int championatId)
        {
            return _service.GetSettings(championatId);
        }
    }
}
