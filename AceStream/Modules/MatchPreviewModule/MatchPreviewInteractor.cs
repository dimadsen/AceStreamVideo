using AceStream.Dto;
using AceStream.Services;

namespace AceStream.Modules.MatchPreviewModule
{
    public class MatchPreviewInteractor : IMatchPreviewInteractor
    {
        private IMatchPreviewPresenter _presenter;
        private IMatchPreviewService _service;

        public MatchPreviewInteractor(IMatchPreviewPresenter presenter)
        {
            _presenter = presenter;
            _service = new MatchPreviewService();
        }

        public MatchPreviewDto[] GetMatches(int championatId)
        {
            return _service.GetMatches(championatId);
        }
    }
}
