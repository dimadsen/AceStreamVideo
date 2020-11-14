using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;

namespace AceStream.Services.Interfaces
{
    public interface IMatchPreviewService
    {
        Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId);

        MatchPreviewSettingsDto GetSettings(ChampionatDto championat);
    }
}
