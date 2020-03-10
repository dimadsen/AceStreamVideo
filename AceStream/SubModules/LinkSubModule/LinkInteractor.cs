namespace AceStream.SubModules.LinkSubModule
{
    public class LinkInteractor : ILinkInteractor
    {
        private ILinkPresenter _presenter;

        public LinkInteractor(ILinkPresenter presenter)
        {
            _presenter = presenter;
        }
    }
}
