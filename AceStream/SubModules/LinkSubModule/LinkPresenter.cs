using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;

namespace AceStream.SubModules.LinkSubModule
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
            await _view.SetLinksAsync(Interactor.GetLinksAsync(Parametrs));
        } 

        public void SetError()
        {
            _view.SetError();
        }
    }
}
