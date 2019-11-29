using System;

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
            //throw new NotImplementedException();
        }
    }
}

