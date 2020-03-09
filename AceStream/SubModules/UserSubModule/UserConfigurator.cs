namespace AceStream.SubModules.UserSubModule
{
    public class UserConfigurator: IUserConfigurator
    {
        public void Configure(UserViewController viewController)
        {
            var presenter = new UserPresenter(viewController);
            var interactor = new UserInteractor(presenter);
            var router = new UserRouter(viewController);

            viewController.Presenter = presenter;
            presenter.Interactor = interactor;
            presenter.Router = router;
        }
    }
}
