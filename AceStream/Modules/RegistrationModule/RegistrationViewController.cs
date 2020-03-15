using System;
using AceStream.Dto;
using UIKit;

namespace AceStream.Modules.RegistrationModule
{
    public partial class RegistrationViewController : UIViewController, IRegistrationView
    {
        public IRegistrationPresenter Presenter { get; set; }
        public IRegistrationConfigurator Configurator { get; set; }

        public RegistrationViewController(IntPtr handle) : base(handle)
        {
            Configurator = new RegistrationConfigurator();
            Configurator.Configure(this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Presenter.ConfigureView();
        }

        partial void SignUp(UIButton sender)
        {
            var dto = new RegistrationDto
            {
                Name = Name.Text,
                Email = Email.Text,
                Password = Password.Text
            };

            var wasAdded = Presenter.Interactor.SignUp(dto);

            if (wasAdded)
            {
                var alertController = UIAlertController.Create("Регистрация выполнена",
                "Теперь вы можете авторизоваться", UIAlertControllerStyle.Alert);

                alertController.AddAction(UIAlertAction.Create("ОК", UIAlertActionStyle.Default, action => { }));

                PresentViewController(alertController, true, null);
            }
            else
            {
                var alertController = UIAlertController.Create("Ошибка",
                "Такой E-mail уже зарегистрирован", UIAlertControllerStyle.Alert);

                alertController.AddAction(UIAlertAction.Create("ОК", UIAlertActionStyle.Default, action => { }));

                PresentViewController(alertController, true, null);
            }
        }

        partial void Close(UIButton sender)
        {
            DismissViewController(true, () => { });
        }

        public void SetSettings()
        {
            CloseButton.ImageView.ContentMode = UIViewContentMode.ScaleAspectFit;
        }
    }
}

