using System;
using AceStream.Dto;

namespace AceStream.iOS.Modules.RegistrationModule
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

        public bool SignUp(RegistrationDto dto)
        {
            return Interactor.SignUp(dto);
        }
    }
}
