namespace AceStream.iOS.Modules.UserModule
{
    public class UserRouter: IUserRouter
    {
        private IUserPresenter _presenter;

        public UserRouter(IUserPresenter presenter)
        {
            _presenter = presenter;
        }        
    }
}
