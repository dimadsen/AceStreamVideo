using System;
using AceStream.Dto;

namespace AceStream.iOS.Modules.LoginModule
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

        public UserDto GetUser(LoginDto login)
        {
            var user = Interactor.GetUser(login);

            return user;
        }
    }
}
