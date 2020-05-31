using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AceStream.Additionals;
using AceStream.Dto;
using AceStream.SubModules.SquardSubModule;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Essentials;

namespace AceStream.Modules.MatchModule
{
    public partial class MatchViewController : UIViewController, IMatchView, IUIScrollViewDelegate, IUITableViewDelegate
    {
        public IMatchPresenter Presenter { get; set; }
        public IMatchConfigurator Configurator { get; set; }

        private SegmentedViewController segmentedViewController;
        private MatchDto _match;
        private TimerCallback tm;

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
                    segmentedViewController = Presenter.Router.InitializeSegmented(_match);

                    segmentedViewController.View.Frame = new CGRect(segmentedViewController.View.Frame.X, segmentedViewController.View.Frame.Y,
                                                                    segmentedViewController.View.Frame.Width, DetailedMatchInfoView.Frame.Height);

                    DetailedMatchInfoView.AddSubview(segmentedViewController.View);

                    Indicator.StopAnimating();
                    Indicator.HidesWhenStopped = true;
                    DetailedMatchInfoView.Hidden = false;

                    var height = NavigationController.NavigationBar.Frame.Height + UIApplication.SharedApplication.StatusBarFrame.Height +
                                 NavigationController.TabBarController.TabBar.Frame.Height;

                    DetailedMatchInfoView.Constraints[0].Constant = View.Frame.Height - height;

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

            MatchScrollView.Delegate = this;

            tm = new TimerCallback(UpdateMatchInfo);

            var timer = new Timer(tm, null, 0, 60000);
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

        [Export("scrollViewDidScroll:")]
        public void Scrolled(UIScrollView scrollView)
        {
            var squardViewController = segmentedViewController?.ViewControllers[0] as SquardViewController;

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
    }
}

