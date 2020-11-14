using System;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.iOS.Modules.MatchModule;
using AceStream.Services.Interfaces;

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
