using System;
using AceStream.Dto;
using AceStream.iOS.Modules.LoginModule;
using Foundation;
using UIKit;

namespace AceStream.Modules.LoginModule
{
    public partial class LoginViewController : UIViewController, ILoginView
    {
        public ILoginPresenter Presenter { get; set; }
        public ILoginConfigurator Configurator { get; set; }

        public LoginViewController(IntPtr handle) : base(handle)
        {
            Configurator = new LoginConfigurator();
            Configurator.ConfigureView(this);
        }
        
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Presenter.ConfigureView();

            
        }

        public void SetSettings()
        {
            var tap = new UITapGestureRecognizer(() =>
            {
                View.EndEditing(true);
            });

            View.AddGestureRecognizer(tap);
        }


        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            if (segueIdentifier == "ToChampionats" && !User.IsAuthorized)
            {
                var alertController = UIAlertController.Create("Ошибка",
                "Неправильный логин или пароль", UIAlertControllerStyle.Alert);

                alertController.AddAction(UIAlertAction.Create("ОК", UIAlertActionStyle.Default, action => { }));

                PresentViewController(alertController, true, null);

                return false;
            }
            return true;
        }

        partial void SignIn(UIButton sender)
        {
            var dto = new LoginDto()
            {
                Email = Email.Text,
                Password = Password.Text
            };

            var user = Presenter.GetUser(dto);

            if (user != null)
            {
                User.Id = user.Id;
                User.IsAuthorized = true;
            }
        }
    }
}

