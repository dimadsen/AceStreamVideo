using System.Collections.Generic;
using AceStream.Dto;

namespace AceStream.SubModules.LinkSubModule
{
    public class LinkPresenter : ILinkPresenter
    {
        public ILinkInteractor Interactor { get; set; }
        public ILinkRouter Router { get; set; }

        public List<LinkDto> Links { get; set; }

        private ILinkView _view;


        public LinkPresenter(ILinkView view)
        {
            _view = view;
        }

        public void ConfigureView()
        {
            _view.SetLinks(Links);
            _view.SetSettings();
        }
    }
}
