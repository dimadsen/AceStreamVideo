using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Core.Exceptions;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;
using AceStream.Services.Interfaces;

namespace AceStream.iOS.Modules.MatchPreviewModule
{
    public class MatchPreviewInteractor : IMatchPreviewInteractor
    {
        private IMatchPreviewPresenter _presenter;
        private IMatchPreviewService _service;

        public MatchPreviewInteractor(IMatchPreviewPresenter presenter, IMatchPreviewService service)
        {
            _presenter = presenter;
            _service = service;
        }

        public async Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId)
        {
            try
            {
                var matches = await _service.GetMatchesAsync(championatId);

                return matches?.Count > 0 ?
                    matches : throw new MatchesNotFoundException();
            }
            catch(MatchesNotFoundException ex)
            {
                _presenter.SetNotFoundMatches(ex.Message);

                return new List<MatchPreviewDto>();
            }
            catch (Exception)
            {
                _presenter.SetError();

                return new List<MatchPreviewDto>();
            }
        }

        public MatchPreviewSettingsDto GetSettings(ChampionatDto championat)
        {
            return _service.GetSettings(championat);
        }
    }
}
