namespace AceStream.iOS.Modules.RegistrationModule
{
    public class RegistrationRouter : IRegistrationRouter
    {
        private IRegistrationPresenter _presenter;

        public RegistrationRouter(IRegistrationPresenter presenter)
        {
            _presenter = presenter;
        }
    }
}
