using AceStream.Dto;
using AceStream.Modules.MatchPreviewModule;
using UIKit;

namespace AceStream.Modules.ChampionatModule
{
    public class ChampionatRouter : IChampionatRouter
    {
        private IChampionatPresenter _presenter;

        public ChampionatRouter(IChampionatPresenter presenter)
        {
            _presenter = presenter;
        }

        public void PrepareForSegue(object destinationView, ChampionatDto sender)
        {
            var view = destinationView as IMatchPreviewView;

            view.Presenter.Championat = sender;
        }
    }
}
