namespace AceStream.SubModules.SquardSubModule
{
    public class SquardRouter : ISquardRouter
    {
        private SquardViewController _viewController;

        public SquardRouter(SquardViewController viewController)
        {
            _viewController = viewController;
        }

    }
}
