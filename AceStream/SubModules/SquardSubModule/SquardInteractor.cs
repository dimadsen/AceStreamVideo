using System;
using AceStream.Dto;
using AceStream.Extansions;

namespace AceStream.SubModules.SquardSubModule
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
                    throw new NotFoundPlayersException("Составы команд не опубликованы");

                _presenter.SetTitleHeader();

                return match;
            }
            catch (NotFoundPlayersException)
            {
                _presenter.SetNotFoundPlayers();

                return null;
            }
        }
    }
}
