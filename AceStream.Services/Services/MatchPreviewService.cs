using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AceStream.Services.Extansions;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;
using AceStream.Services.Repositories;
using AceStream.Core.Domain.Enums;

namespace AceStream.Services
{
    public class MatchPreviewService : IMatchPreviewService
    {
        private IClient _client;

        public MatchPreviewService(IClient client)
        {
            _client = client;    
        }

        public async Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId)
        {
            var championats = await _client.GetChampionatsAsync();

            var championat = championats.FirstOrDefault(c => c.Id == championatId);

            var dto = championat.Matches.Select(m => new MatchPreviewDto
            {
                Id = m.Id,
                Home = m.Home.Name,
                HomePicture = m.Home.Icon,
                HomeScore = m.Score.Split(0, ":"),
                Time = m.Date.StartDate.ToString("HH:mm"),
                Status = (MatchStatus)m.Status.Id,
                Visitor = m.Visitor.Name,
                VisitorPicture = m.Visitor.Icon,
                VisitorScore = m.Score.Split(1, ":"),
            }).ToList();

            return dto;
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

    public interface IMatchPreviewService
    {
        Task<List<MatchPreviewDto>> GetMatchesAsync(int championatId);

        MatchPreviewSettingsDto GetSettings(ChampionatDto championat);
    }
}
