using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Services.Clients;
using AceStream.Services.Interfaces;

namespace AceStream.Services
{
    public class MatchService : IMatchService
    {
        private ISourceClient _client;

        public MatchService(ISourceClient client)
        {
            _client = client;
        }

        public async Task<MatchDto> GetMatchAsync(int matchId)
        {
            var match = await _client.GetMatchAsync(matchId);

            return match;
        }        
    }
}
