using AceStream.Dto;
using AceStream.iOS.Modules.MatchPreviewModule;

namespace AceStream.iOS.Modules.ChampionatModule
{
    public class ChampionatRouter : IChampionatRouter
    {
        private IChampionatView _view;

        public ChampionatRouter(IChampionatView view)
        {
            _view = view;
        }

        public void Prepare(IMatchPreviewView destinationView, ChampionatDto championat)
        {
            destinationView.Presenter.Championat = championat;
        }
    }
}
