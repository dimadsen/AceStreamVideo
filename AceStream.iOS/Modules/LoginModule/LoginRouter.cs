using System;
namespace AceStream.Modules.LoginModule
{
    public class LoginRouter: ILoginRouter
    {
        private LoginViewController _viewController;

        public LoginRouter(LoginViewController viewController)
        {
            _viewController = viewController;
        }
    }
}
