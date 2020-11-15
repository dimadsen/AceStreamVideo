using AceStream.iOS.Modules.MatchModule;
using AceStream.iOS.Modules.VideoModule;

namespace AceStream.Modules.MatchModule
{
    public class MatchRouter : IMatchRouter
    {
        private IMatchPresenter _presenter;

        public MatchRouter(IMatchPresenter presenter)
        {
            _presenter = presenter;
        }

        public void PrepareForSegue(object destinationView, string link)
        {
            var view = destinationView as IVideoView;

            view.Presenter.Link = link;
        }
    }
}
