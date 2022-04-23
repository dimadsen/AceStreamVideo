using System.Threading.Tasks;
using AceStream.Core.Exceptions;
using AceStream.Dto;

namespace AceStream.iOS.Modules.SquardModule
{
    public class SquardPresenter : ISquardPresenter
    {
        private ISquardInteractor _interactor { get; set; }
        private ISquardView _view;

        public int MatchId { get; set; }

        public SquardPresenter(ISquardInteractor interactor)
        {
            _interactor = interactor;
        }

        public void ConfigureView(ISquardView view)
        {
            _view = view;

            _view.SetSettings();
        }

        public async Task SetPlayersAsync()
        {
            _view.SetTableSquard();

            try
            {
                var players = await _interactor.GetSquardsAsync(MatchId);

                _view.SetPlayers(players);
            }
            catch (PlayersNotFoundException)
            {
                _view.SetNotFoundPlayers();
            }
            catch (System.Exception ex)
            {

            }
        }
    }
}
