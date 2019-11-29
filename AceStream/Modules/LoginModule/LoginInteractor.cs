using System;
namespace AceStream.Modules.LoginModule
{
    public class LoginInteractor : ILoginInteractor
    {
        private ILoginPresenter _presenter;

        public LoginInteractor(ILoginPresenter presenter)
        {
            _presenter = presenter;
        }
    }
}
