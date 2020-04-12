using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Services;

namespace AceStream.Modules.MatchModule
{
    public class MatchInteractor : IMatchInteractor
    {
        private IMatchPresenter _presenter;
        private IMatchService _service;

        public MatchInteractor(IMatchPresenter presenter)
        {
            _presenter = presenter;

            _service = new MatchService();
        }

        public async Task<MatchDto> GetMatchAsync(int matchId)
        {
            try
            {
                var match = await _service.GetMatchAsync(matchId);

                return match;
            }
            catch (Exception)
            {
                _presenter.SetError();

                return new MatchDto();
            }
        }
    }
}
