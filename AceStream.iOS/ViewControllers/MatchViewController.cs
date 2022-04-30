using System;
using System.Threading;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.iOS.Modules.MatchModule;
using AceStream.Utils;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Essentials;
using Microsoft.Extensions.DependencyInjection;
using AceStream.Services.Dto.Enums;

namespace AceStream.Modules.MatchModule
{
    public partial class MatchViewController : UIViewController, IMatchView, IUIScrollViewDelegate, IUITableViewDelegate
    {
        public IMatchPresenter Presenter { get; set; }

        private DetailedMatchViewController detailedVC;
        private MatchDto _match;
        private TimerCallback tm;

        public MatchViewController(IntPtr handle) : base(handle)
        {
            Presenter = ServiceProviderFactory.ServiceProvider.GetService<IMatchPresenter>();
        }

        public override void ViewDidLoad()
        {
            Presenter.ConfigureView(this);

            Task.Run(async () =>
            {
                await Presenter.SetMatchAsync();

                MainThread.BeginInvokeOnMainThread(() => SetDetailedVC());
            });
        }

        public void SetSettings(string title)
        {
            HomePicture.Layer.BorderWidth = 2;
            HomePicture.Layer.MasksToBounds = false;
            HomePicture.Layer.BorderColor = ColorUtils.GetInterfaceStyle().CGColor;
            HomePicture.ClipsToBounds = true;

            VisitorPicture.Layer.BorderWidth = 2;
            VisitorPicture.Layer.MasksToBounds = false;
            VisitorPicture.Layer.BorderColor = ColorUtils.GetInterfaceStyle().CGColor;
            VisitorPicture.ClipsToBounds = true;

            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;

            Score.AdjustsFontForContentSizeCategory = true;
            Score.AdjustsFontSizeToFitWidth = true;

            Score.MinimumScaleFactor = 10 / UIFont.LabelFontSize;
            NavigationController.NavigationBar.TopItem.BackBarButtonItem = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, null, null);

            NavigationItem.Title = title;

            MatchScrollView.Delegate = this;

            tm = new TimerCallback(UpdateMatchInfo);

            var timer = new Timer(tm, null, 0, 60000);
        }

        public void SetMatch(MatchDto match)
        {
            _match = match;

            _match.ImageHome = ImageUtils.DownloadFile(_match.Home, _match.ImageHome);
            _match.ImageVisitor = ImageUtils.DownloadFile(_match.Visitor, _match.ImageVisitor);


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

                if (_match.Status == MatchStatus.InProgress)
                {
                    Minute.Text = $"{_match.Minute}'";
                    Minute.Hidden = false;
                }
            });
        }

        [Export("scrollViewDidScroll:")]
        public void Scrolled(UIScrollView scrollView)
        {
            var squardViewController = detailedVC?.ViewControllers[0] as SquardViewController;

            if (squardViewController != null)
            {
                squardViewController.TableView.Delegate = this;

                if (scrollView == MatchScrollView)
                {
                    var height = NavigationController.NavigationBar.Frame.Height + UIApplication.SharedApplication.StatusBarFrame.Height +
                                    NavigationController.TabBarController.TabBar.Frame.Height;

                    squardViewController.TableView.ScrollEnabled = MatchScrollView.ContentOffset.Y >= 200 - height;
                }

                if (scrollView == squardViewController.TableView)
                {
                    squardViewController.TableView.ScrollEnabled = squardViewController.TableView.ContentOffset.Y > 0;
                }
            }

        }

        public void SetError()
        {
            throw new NotImplementedException();
        }

        public void UpdateMatchInfo(object obj)
        {
            Task.Run(async () =>
            {
                await Presenter.SetMatchAsync();
            });
        }

        private void SetDetailedVC()
        {
            detailedVC = new DetailedMatchViewController(_match);

            detailedVC.View.Frame = new CGRect(detailedVC.View.Frame.X, detailedVC.View.Frame.Y,
                                                            detailedVC.View.Frame.Width, DetailedMatchInfoView.Frame.Height);

            DetailedMatchInfoView.AddSubview(detailedVC.View);

            Indicator.StopAnimating();
            Indicator.HidesWhenStopped = true;
            DetailedMatchInfoView.Hidden = false;

            var height = NavigationController.NavigationBar.Frame.Height + UIApplication.SharedApplication.StatusBarFrame.Height +
                         NavigationController.TabBarController.TabBar.Frame.Height;

            DetailedMatchInfoView.Constraints[0].Constant = View.Frame.Height - height;
        }
    }
}

