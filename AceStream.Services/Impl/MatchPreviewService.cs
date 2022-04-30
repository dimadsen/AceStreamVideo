using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Services.Extansions;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;
using AceStream.Services.Clients;
using AceStream.Core.Domain.Enums;
using AceStream.Services.Interfaces;

namespace AceStream.Services
{
    public class MatchPreviewService : IMatchPreviewService
    {
        private ISourceClient _client;

        public MatchPreviewService(ISourceClient client)
        {
            _client = client;    
        }

        public async Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId)
        {
            var matches = await _client.GetMatchesAsync(championatId);

            return matches;
        }

        public MatchPreviewSettingsDto GetSettings(ChampionatDto championat)
        {
            var settings = new MatchPreviewSettingsDto()
            {
                Image = championat.Image,
                Title = championat.Name
            };

            return settings;
        }
    }
}
