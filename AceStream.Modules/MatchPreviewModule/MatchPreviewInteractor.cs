using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Core.Exceptions;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;
using AceStream.Services.Interfaces;

namespace AceStream.iOS.Modules.MatchPreviewModule
{
    public class MatchPreviewInteractor : IMatchPreviewInteractor
    {
        private IMatchPreviewService _service;

        public MatchPreviewInteractor(IMatchPreviewService service)
        {
            _service = service;
        }

        public async Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId)
        {
            var matches = await _service.GetMatchesAsync(championatId);

            return matches.Any() ? matches : throw new MatchesNotFoundException();
        }

        public MatchPreviewSettingsDto GetSettings(ChampionatDto championat)
        {
            return _service.GetSettings(championat);
        }
    }
}
