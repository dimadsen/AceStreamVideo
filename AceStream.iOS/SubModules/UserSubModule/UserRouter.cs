namespace AceStream.SubModules.UserSubModule
{
    public class UserRouter: IUserRouter
    {
        private UserViewController _viewController;

        public UserRouter(UserViewController viewController)
        {
            _viewController = viewController;
        }

        public void Prepare()
        {
        }
    }
}
