using System;
using AceStream.Dto;

namespace AceStream.SubModules.SquardSubModule
{
    public class SquardPresenter: ISquardPresenter
    {
        public ISquardInteractor Interactor { get; set; }
        public ISquardRouter Router { get; set; }

        public MatchDto Match { get; set; }

        private ISquardView _view;


        public SquardPresenter(ISquardView view)
        {
            _view = view;
        }

        public void ConfigureView()
        {
            _view.SetTableSquard();

            _view.SetPlayers(Match);
            _view.SetSettings();     
        }
    }
}
