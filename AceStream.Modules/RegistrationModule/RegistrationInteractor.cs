using AceStream.Dto;
using AceStream.Services.Interfaces;

namespace AceStream.iOS.Modules.RegistrationModule
{
    public class RegistrationInteractor: IRegistrationInteractor
    {
        private IRegistrationPresenter _presenter;

        private IUserService _service;

        public RegistrationInteractor(IRegistrationPresenter presenter, IUserService service)
        {
            _presenter = presenter;
            _service = service;
        }

        public bool SignUp(RegistrationDto dto)
        {
            return _service.SignUp(dto);
        }
    }
}
