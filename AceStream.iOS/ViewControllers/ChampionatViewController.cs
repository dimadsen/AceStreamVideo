using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.iOS.Modules.ChampionatModule;
using AceStream.Utils;
using AceStream.Views.TableViewCell;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Essentials;

namespace AceStream
{
    public partial class ChampionatViewController : UITableViewController, IChampionatView
    {
        public IChampionatPresenter Presenter { get; set; }
        public IChampionatConfigurator Configurator { get; set; }

        private List<ChampionatDto> _championats;

        public ChampionatViewController(IntPtr handle) : base(handle)
        {
            Configurator = new ChampionatConfigurator();
            Configurator.Configure(this);
        }

        public override void ViewDidLoad()
        {
            Task.Run(async () =>
            {
                await Presenter.SetChampionatsAsync();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    TableView.ReloadData();
                    Indicator.StopAnimating();
                    Indicator.HidesWhenStopped = true;

                    TableView.TableHeaderView = null;
                });
            });

            Presenter.ConfigureView();
        }

        public void SetSettings(string title)
        {
            #region Настройки TableView

            TableView.TableFooterView = new UIView(CGRect.Empty);

            RefreshControl = new UIRefreshControl { TintColor = ColorUtils.GetInterfaceStyle() };
            RefreshControl.ValueChanged += Refresh;
            #endregion

            #region Настройки NavigationBar

            NavigationItem.Title = title;

            var appearance = new UINavigationBarAppearance
            {
                LargeTitleTextAttributes = new UIStringAttributes
                {
                    ForegroundColor = ColorUtils.GetInterfaceTextStyle()
                },
                TitleTextAttributes = new UIStringAttributes
                {
                    ForegroundColor = ColorUtils.GetInterfaceTextStyle()
                }
            };

            NavigationController.NavigationBar.StandardAppearance = appearance;
            NavigationController.NavigationBar.ScrollEdgeAppearance = appearance;
            

            SetBackIndicator();

            NavigationController.NavigationBar.AddSubview(NavigationItemImage.ImageView);
            NavigationItemImage.ActivateConstraints(NavigationController.NavigationBar);

            #endregion            

            NavigationItemImage.HiddenImage();
        }

        private void Refresh(object sender, EventArgs e)
        {
            var task = Task.Run(async () =>
            {
                await Presenter.SetChampionatsAsync();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    TableView.ReloadData();

                    RefreshControl.EndRefreshing();

                    var label = TableView.ViewWithTag(1);
                    label?.RemoveFromSuperview();

                    var image = TableView.ViewWithTag(2);
                    image?.RemoveFromSuperview();
                });
            });
        }

        public async Task SetChampionatsAsync(Task<List<ChampionatDto>> championats)
        {
            _championats = await championats;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            var row = TableView.IndexPathForCell(sender as UITableViewCell).Row;

            var championat = _championats[row];

            var matchPreviewViewController = segue.DestinationViewController as MatchPreviewViewController;

            Presenter.Router.Prepare(matchPreviewViewController, championat);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("ChampionatTableViewCell") as ChampionatTableViewCell;

            if (cell == null)
                cell = new ChampionatTableViewCell(new NSString("ChampionatTableViewCell"));

            cell.UpdateCell(_championats[indexPath.Row]);

            return cell;

        }
        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _championats?.Count ?? 0;
        }

        /// <summary>
        /// Установка индикатора "Назад"
        /// </summary>
        private void SetBackIndicator()
        {
            var imgBack = UIImage.FromFile("back.png");
            NavigationController.NavigationBar.BackIndicatorImage = imgBack;
            NavigationController.NavigationBar.TintColor = ColorUtils.GetInterfaceStyle();
            NavigationController.NavigationBar.BackIndicatorTransitionMaskImage = imgBack;
            NavigationItem.LeftItemsSupplementBackButton = true;
            NavigationController.NavigationBar.TopItem.BackBarButtonItem = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, null, null);
        }

        public void SetErrorView()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var imageview = new UIImageView(new CGRect(TableView.Frame.X, TableView.Frame.Y, 200, 200))
                {
                    Image = UIImage.FromFile("error_image.png"),
                    Tag = 2
                };

                imageview.Center = TableView.ConvertPointFromView(TableView.Center, imageview);

                TableView.AddSubview(imageview);
            });
        }

        public void SetNotFoundView()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var label = new UILabel(new CGRect(TableView.Frame.X, TableView.Frame.Y, 200, 50))
                {
                    Text = "На сегодня матчей нет",
                    Tag = 1
                };

                label.Center = TableView.ConvertPointFromView(TableView.Center, label);

                TableView.AddSubview(label);
            });
        }
    }
}