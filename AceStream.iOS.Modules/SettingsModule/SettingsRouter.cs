namespace AceStream.iOS.Modules.SettingsModule
{
    public class SettingsRouter: ISettingsRouter
    {
        private ISettingsPresenter _presenter;

        public SettingsRouter(ISettingsPresenter presenter)
        {
            _presenter = presenter;
        }

        //public UIViewController InitializeUser()
        //{
        //    var storyboard = UIStoryboard.FromName("Main", null);
        //    var controller = storyboard.InstantiateViewController("UserViewController");

        //    return controller;
        //}

        //public void Prepare(UIStoryboardSegue segue)
        //{
        //    //if (segue.Identifier == "ToExit")
        //    //{
        //    //    var loginViewController = segue.DestinationViewController as LoginViewController;

        //    //    loginViewController.Presenter.SignOut();
        //    //}            
        //}

        //public void Prepare(UINavigationController navigationController, string identifier)
        //{
        //    var storyboard = UIStoryboard.FromName("Main", null);
        //    var controller = storyboard.InstantiateViewController(identifier);

        //    navigationController.PushViewController(controller, true);
        //}


    }
}
