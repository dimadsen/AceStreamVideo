namespace AceStream.Modules.ChampionatModule
{
    public class ChampionatPresenter : IChampionatPresenter
    {
        public IChampionatInteractor Interactor { get; set; }
        public IChampionatRouter Router { get; set; }
        private IChampionatView _view;

        public ChampionatPresenter(IChampionatView view)
        {
            _view = view;
        }

        public void ConfigureView()
        {
            _view.SetChampionats(Interactor.GetChampionats());
            _view.SetSettings(Interactor.Title);
        }
    }
}
