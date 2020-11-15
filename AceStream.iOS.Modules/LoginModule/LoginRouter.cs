namespace AceStream.iOS.Modules.LoginModule
{
    public class LoginRouter: ILoginRouter
    {
        private ILoginPresenter _presenter;

        public LoginRouter(ILoginPresenter presenter)
        {
            _presenter = presenter;
        }
    }
}
