using System;
namespace AceStream.Modules.LoginModule
{
    public class LoginPresenter : ILoginPresenter
    {
        public ILoginRouter Router { get; set; }
        public ILoginInteractor Interactor { get; set; }
        private ILoginView _view;

        public LoginPresenter(ILoginView view)
        {
            _view = view;
        }
        public void ConfigureView()
        {
            _view.SetSettings();
        }

        public void SignOut()
        {
            User.Id = 0;
            User.IsAuthorized = false;
        }
    }
}
