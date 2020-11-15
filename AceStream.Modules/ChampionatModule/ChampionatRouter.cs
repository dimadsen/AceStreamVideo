using AceStream.Dto;
using AceStream.iOS.Modules.MatchPreviewModule;

namespace AceStream.iOS.Modules.ChampionatModule
{
    public class ChampionatRouter : IChampionatRouter
    {
        private IChampionatPresenter _presenter;

        public ChampionatRouter(IChampionatPresenter presenter)
        {
            _presenter = presenter;
        }

        public void PrepareForSegue(object destinationView, ChampionatDto championat)
        {
            var view = destinationView as IMatchPreviewView;

            view.Presenter.Championat = championat;
        }
    }
}
