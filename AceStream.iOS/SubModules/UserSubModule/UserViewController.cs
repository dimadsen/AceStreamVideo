using System;
using AceStream.Dto;
using AceStream.SubModules.UserSubModule;
using UIKit;

namespace AceStream
{
    public partial class UserViewController : UIViewController, IUserView
    {
        public IUserPresenter Presenter { get; set; }
        public IUserConfigurator Configurator { get; set; }

        public UserViewController (IntPtr handle) : base (handle)
        {
            Configurator = new UserConfigurator();
            Configurator.Configure(this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Presenter.ConfigureView();
        }

        public void SetSettings(UserDto dto)
        {
            Nik.Text = dto.Nickname;

            Avatar.Image = UIImage.FromFile(dto.Avatar ?? "avatar.png");
        }
    }
}