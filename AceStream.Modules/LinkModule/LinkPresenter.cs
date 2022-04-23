using System;
using System.Threading.Tasks;

namespace AceStream.Modules.LinkModule
{
    public class LinkPresenter : ILinkPresenter
    {
        private ILinkInteractor _interactor { get; set; }
        private ILinkRouter _router { get; set; }
        private ILinkView _view;
        
        public string[] Parametrs { get ; set ; }

        public LinkPresenter(ILinkRouter router, ILinkInteractor interactor)
        {
            _router = router;
            _interactor = interactor;
        }

        public void ConfigureView(ILinkView view)
        {
            _view = view;

            _view.SetSettings();
        }

        public async Task SetLinksAsync()
        {
            try
            {
                var links = await _interactor.GetLinksAsync(Parametrs);

                _view.SetLinks(links);
            }
            catch (Exception ex)
            {
                _view.SetError();
            }

        } 

        public void PrepareForSegue(object destinationView, string link)
        {
            _router.PrepareForSegue(destinationView, link);
        }
    }
}
