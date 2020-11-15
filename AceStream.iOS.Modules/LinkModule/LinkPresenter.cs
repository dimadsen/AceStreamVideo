using System.Threading.Tasks;

namespace AceStream.Modules.LinkModule
{
    public class LinkPresenter : ILinkPresenter
    {
        public ILinkInteractor Interactor { get; set; }
        public ILinkRouter Router { get; set; }
        
        public string[] Parametrs { get ; set ; }

        private ILinkView _view;


        public LinkPresenter(ILinkView view)
        {
            _view = view;
        }

        public void ConfigureView()
        {
            _view.SetSettings();
        }

        public async Task SetLinksAsync()
        {
            var links = await Interactor.GetLinksAsync(Parametrs);

            _view.SetLinks(links);
        } 

        public void SetError()
        {
            _view.SetError();
        }

        public void PrepareForSegue(object destinationView, string link)
        {
            Router.PrepareForSegue(destinationView, link);
        }
    }
}
