namespace AceStream.iOS.Modules.SquardModule
{
    public class SquardRouter : ISquardRouter
    {
        private ISquardPresenter _presenter;

        public SquardRouter(ISquardPresenter presenter)
        {
            _presenter = presenter;
        }

    }
}
