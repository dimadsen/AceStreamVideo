using System;
using System.Threading;
using System.Threading.Tasks;
using AceStream.Additionals;
using AceStream.Dto;
using CoreGraphics;
using UIKit;
using Xamarin.Essentials;

namespace AceStream.Modules.MatchModule
{
    public partial class MatchViewController : UIViewController, IMatchView
    {
        public IMatchPresenter Presenter { get; set; }
        public IMatchConfigurator Configurator { get; set; }

        private MatchDto _match;

        public MatchViewController(IntPtr handle) : base(handle)
        {
            Configurator = new MatchConfigurator();
            Configurator.Configure(this);            
        }

        public override void ViewDidLoad()
        {
            Task.Run(async () =>
            {
                await Presenter.SetMatchAsync();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    var controller = Presenter.Router.InitializeSegmented(_match);
                    controller.View.Frame = SetFrame();

                    View.AddSubview(controller.View);

                    Indicator.StopAnimating();
                    Indicator.HidesWhenStopped = true;
                });
            });

            Presenter.ConfigureView();
        }

        public void SetSettings(string title)
        {
            HomePicture.Layer.BorderWidth = 1;
            HomePicture.Layer.MasksToBounds = false;
            HomePicture.Layer.BorderColor = UIColor.LightGray.CGColor;
            HomePicture.Layer.CornerRadius = HomePicture.Frame.Height / 2;
            HomePicture.ClipsToBounds = true;

            VisitorPicture.Layer.BorderWidth = 1;
            VisitorPicture.Layer.MasksToBounds = false;
            VisitorPicture.Layer.BorderColor = UIColor.LightGray.CGColor;
            VisitorPicture.Layer.CornerRadius = VisitorPicture.Frame.Height / 2;
            VisitorPicture.ClipsToBounds = true;

            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;

            Score.AdjustsFontForContentSizeCategory = true;
            Score.AdjustsFontSizeToFitWidth = true;

            Score.MinimumScaleFactor = 10 / UIFont.LabelFontSize;
            NavigationController.NavigationBar.TopItem.BackBarButtonItem = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, null, null);

            NavigationItem.Title = title;
            View.Layer.InsertSublayer(GradientColor.ShowAgain(View.Frame.Width, View.Frame.Height), 0);
        }

        public async Task SetMatchAsync(Task<MatchDto> match)
        {
            _match = await match;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Home.Hidden = false;
                Home.Text = _match.Home;

                HomePicture.Hidden = false;
                HomePicture.Image = UIImage.FromFile(_match.ImageHome);

                Visitor.Hidden = false;
                Visitor.Text = _match.Visitor;

                VisitorPicture.Hidden = false;
                VisitorPicture.Image = UIImage.FromFile(_match.ImageVisitor);

                Score.Hidden = false;
                Score.Text = _match.Score;

                Half.Hidden = false;
                Half.Text = _match.Half;

                Date.Hidden = false;
                Date.Text = _match.Date.ToString("d.MM.yyyy HH:mm");
            });            
        }

        private CGRect SetFrame()
        {
            var y = Home.Frame.Y + 35;
            var height = View.Frame.Height - y - NavigationController.TabBarController.TabBar.Frame.Height;

            return new CGRect(0, y, View.Frame.Width, height);
        }

        public void SetError()
        {
            throw new NotImplementedException();
        }        
    }
}

