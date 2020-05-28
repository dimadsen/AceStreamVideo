using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AceStream.Additionals;
using AceStream.Dto;
using CoreGraphics;
using Foundation;
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
                    controller.View.Frame = new CGRect(controller.View.Frame.X, controller.View.Frame.Y, controller.View.Frame.Width, DetailedMatchInfoView.Frame.Height);

                    //DetailedMatchInfoView.Constraints[4].Constant = 700;

                    //View.LayoutIfNeeded();
                    DetailedMatchInfoView.AddSubview(controller.View);
                    //controller.View.Frame = SetFrame();

                    //View.AddSubview(controller.View);

                    Indicator.StopAnimating();
                    Indicator.HidesWhenStopped = true;
                    DetailedMatchInfoView.Hidden = false;
                });
            });

            Presenter.ConfigureView();
        }

        public void SetSettings(string title)
        {
            HomePicture.Layer.BorderWidth = 1;
            HomePicture.Layer.MasksToBounds = false;
            HomePicture.Layer.BorderColor = UIColor.DarkGray.CGColor;
            //HomePicture.Layer.CornerRadius = HomePicture.Frame.Height / 2;
            HomePicture.ClipsToBounds = true;

            VisitorPicture.Layer.BorderWidth = 1;
            VisitorPicture.Layer.MasksToBounds = false;
            VisitorPicture.Layer.BorderColor = UIColor.DarkGray.CGColor;
            //VisitorPicture.Layer.CornerRadius = VisitorPicture.Frame.Height / 2;
            VisitorPicture.ClipsToBounds = true;

            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;

            Score.AdjustsFontForContentSizeCategory = true;
            Score.AdjustsFontSizeToFitWidth = true;

            Score.MinimumScaleFactor = 10 / UIFont.LabelFontSize;
            NavigationController.NavigationBar.TopItem.BackBarButtonItem = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, null, null);

            NavigationItem.Title = title;            
        }

        public async Task SetMatchAsync(Task<MatchDto> match)
        {
            _match = await match;

            MainThread.BeginInvokeOnMainThread(() =>
            {
                MatchInfoView.Hidden = false;

                Home.Text = _match.Home;

                HomePicture.Image = UIImage.FromFile(_match.ImageHome);

                Visitor.Text = _match.Visitor;

                VisitorPicture.Image = UIImage.FromFile(_match.ImageVisitor);

                Score.Text = _match.Score;

                Half.Text = _match.Half;

                Date.Text = _match.Date.ToString("dd MMMM HH:mm");

                Stadium.Text = _match.Stadium;
            });            
        }

        private CGRect SetFrame()
        {
            var y = MatchInfoView.Frame.Height + 135;
            var height = View.Frame.Height - y - NavigationController.TabBarController.TabBar.Frame.Height;

            return new CGRect(0, y, View.Frame.Width, height);
        }

        public void SetError()
        {
            throw new NotImplementedException();
        }        
    }
}

