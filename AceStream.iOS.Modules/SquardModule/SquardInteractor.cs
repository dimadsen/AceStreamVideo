using AceStream.Core.Exceptions;
using AceStream.Dto;

namespace AceStream.iOS.Modules.SquardModule
{
    public class SquardInteractor : ISquardInteractor
    {
        private ISquardPresenter _presenter;

        public SquardInteractor(ISquardPresenter presenter)
        {
            _presenter = presenter;
        }

        public MatchDto GetMatch(MatchDto match)
        {
            try
            {
                if (match.HomeSquard.Startings.Count < 11 || match.VisitorSquard.Startings.Count < 11)
                    throw new PlayersNotFoundException();

                _presenter.SetTitleHeader();

                return match;
            }
            catch (PlayersNotFoundException)
            {
                _presenter.SetNotFoundPlayers();

                return null;
            }
        }
    }
}
