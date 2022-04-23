using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.iOS.Modules.MatchModule;
using AceStream.Services.Interfaces;

namespace AceStream.Modules.MatchModule
{
    public class MatchInteractor : IMatchInteractor
    {
        private IMatchService _service;

        public MatchInteractor(IMatchService service)
        {

            _service = service;
        }

        public async Task<MatchDto> GetMatchAsync(int matchId)
        {
            var match = await _service.GetMatchAsync(matchId);

            return match;
        }
    }
}
