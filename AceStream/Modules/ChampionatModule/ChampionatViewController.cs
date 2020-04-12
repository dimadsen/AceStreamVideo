using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Additionals;
using AceStream.Dto;
using AceStream.Modules.ChampionatModule;
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

            TableView.TableFooterView.Layer.InsertSublayer(GradientColor.ShowAgain(TableView.Frame.Width, TableView.Frame.Height), 0);

            var tableGradient = GradientColor.ShowAgain(NavigationController.NavigationBar.Frame.Width, NavigationController.NavigationBar.Frame.Height);

            var tableImage = ImageUtils.GetGradientImage(tableGradient, NavigationController.NavigationBar.Frame.Size);

            View.BackgroundColor = new UIColor(tableImage);
            #endregion

            #region Настройки NavigationBar

            NavigationItem.Title = title;

            SetBackIndicator();

            NavigationController.NavigationBar.AddSubview(NavigationItemImage.ImageView);
            NavigationItemImage.ActivateConstraints(NavigationController.NavigationBar);

            var barGradient = GradientColor.PaloAlto(NavigationController.NavigationBar.Frame.Width, NavigationController.NavigationBar.Frame.Height);
            var barImage = ImageUtils.GetGradientImage(barGradient, NavigationController.NavigationBar.Frame.Size);

            NavigationController.NavigationBar.BarTintColor = new UIColor(barImage);
            #endregion

            #region Цвет TabBar

            NavigationController.TabBarController.TabBar.Layer.InsertSublayer(barGradient, 0);
            NavigationController.TabBarController.TabBar.UnselectedItemTintColor = UIColor.DarkGray;
            #endregion
        }

        public async Task SetChampionatsAsync(Task<List<ChampionatDto>> championats)
        {
            _championats = await championats;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            var championatId = TableView.IndexPathForCell(sender as UITableViewCell).Row;

            Presenter.Router.Prepare(segue, championatId);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("ChampionatTableViewCell") as ChampionatTableViewCell;

            if (cell == null)
                cell = new ChampionatTableViewCell(new NSString("ChampionatTableViewCell"));

            cell.UpdateCell(_championats[indexPath.Row]);

            cell.Layer.InsertSublayer(GradientColor.ShowAgain(TableView.Frame.Width, tableView.Frame.Height), 0);

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
            NavigationController.NavigationBar.TintColor = UIColor.Black;
            NavigationController.NavigationBar.BackIndicatorTransitionMaskImage = imgBack;
            NavigationItem.LeftItemsSupplementBackButton = true;
            NavigationController.NavigationBar.TopItem.BackBarButtonItem = new UIBarButtonItem("", UIBarButtonItemStyle.Plain, null, null);
        }

        public void SetErrorView()
        {
            throw new NotImplementedException();
        }
    }
}