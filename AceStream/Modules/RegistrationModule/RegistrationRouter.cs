using System;
namespace AceStream.Modules.RegistrationModule
{
    public class RegistrationRouter:IRegistrationRouter
    {
        private RegistrationViewController _viewController;

        public RegistrationRouter(RegistrationViewController viewController)
        {
            _viewController = viewController;
        }
    }
}
