namespace AceStream.iOS.Modules.UserModule
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
            _view.SetSettings();
        }

        public void SetUser(int id)
        {
            var user = Interactor.GetUser(id);

            _view.SetUser(user);
        }
    }
}
