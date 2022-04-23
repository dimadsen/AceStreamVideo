using AceStream.iOS.Modules.MatchModule;
using AceStream.iOS.Modules.VideoModule;

namespace AceStream.Modules.MatchModule
{
    public class MatchRouter : IMatchRouter
    {
        public void PrepareForSegue(object destinationView, string link)
        {
            var view = destinationView as IVideoView;

            view.Presenter.Link = link;
        }
    }
}
