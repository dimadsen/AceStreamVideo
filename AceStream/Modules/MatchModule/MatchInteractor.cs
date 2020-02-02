using System;
using AceStream.Dto;
using AceStream.Services;

namespace AceStream.Modules.MatchModule
{
    public class MatchInteractor:IMatchInteractor
    {
        private IMatchPresenter _presenter;
        private IMatchService _service;

        public MatchInteractor(IMatchPresenter presenter)
        {
            _presenter = presenter;
            _service = new MatchService();
        }

        public MatchDto GetMatch(int matchId)
        {
            return _service.GetMatch(matchId);
        }
    }
}
