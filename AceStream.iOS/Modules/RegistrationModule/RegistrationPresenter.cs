using System;
namespace AceStream.Modules.RegistrationModule
{
    public class RegistrationPresenter : IRegistrationPresenter
    {
        public IRegistrationRouter Router { get ; set; }
        public IRegistrationInteractor Interactor { get ; set; }
        private IRegistrationView _view;

        public RegistrationPresenter(IRegistrationView view)
        {
            _view = view;
        }
        public void ConfigureView()
        {
            _view.SetSettings();
        }
    }
}
