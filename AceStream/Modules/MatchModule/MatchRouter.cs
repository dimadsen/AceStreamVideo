using System;
namespace AceStream.Modules.MatchModule
{
    public class MatchRouter: IMatchRouter
    {
        private MatchViewController _controller;

        public MatchRouter(MatchViewController controller)
        {
            _controller = controller;
        }
    }
}
