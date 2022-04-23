﻿using AceStream.iOS.Modules.MatchModule;

namespace AceStream.iOS.Modules.MatchPreviewModule
{
    public class MatchPreviewRouter : IMatchPreviewRouter
    {
        public void PrepareForSegue(object destinationView, int matchId, string title)
        {
            var view = destinationView as IMatchView;

            view.Presenter.MatchId = matchId;
            view.Presenter.Title = title;
        }
    }
}
