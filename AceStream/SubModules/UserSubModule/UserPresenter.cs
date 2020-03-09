namespace AceStream.SubModules.UserSubModule
{
    public class UserPresenter: IUserPresenter
    {
        public IUserInteractor Interactor { get; set; }
        public IUserRouter Router { get; set; }
        private IUserView _view;

        public UserPresenter(IUserView view)
        {
            _view = view;
        }

        public void ConfigureView()
        {
            _view.SetSettings(Interactor.GetUser());
        }
    }
}
