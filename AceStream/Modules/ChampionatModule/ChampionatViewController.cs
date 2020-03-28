using System;
using AceStream.Additionals;
using AceStream.Dto;
using AceStream.Modules.ChampionatModule;
using AceStream.Utils;
using AceStream.Views.TableViewCell;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AceStream
{
    public partial class ChampionatViewController : UITableViewController, IChampionatView
    {
        public IChampionatPresenter Presenter { get; set; }
        public IChampionatConfigurator Configurator { get; set; }

        private ChampionatDto[] _championats;

        public ChampionatViewController(IntPtr handle) : base(handle)
        {
            Configurator = new ChampionatConfigurator();
            Configurator.Configure(this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Presenter.ConfigureView();
            
        }

        public void SetSettings(string title)
        {            
            NavigationItem.Title = title;

            SetBackIndicator();

            //Что бы не было лишних строк у таблицы
            TableView.TableFooterView = new UIView(CGRect.Empty);

            TableView.TableFooterView.Layer.InsertSublayer(GradientColor.ShowAgain(TableView.Frame.Width, TableView.Frame.Height), 0);
            TableView.RowHeight = 100;

            NavigationController.NavigationBar.AddSubview(NavigationItemImage.ImageView);
            NavigationItemImage.ActivateConstraints(NavigationController.NavigationBar);

            
            var gradient = GradientColor.PaloAlto(NavigationController.NavigationBar.Frame.Width, NavigationController.NavigationBar.Frame.Height);
            var image = ImageUtils.GetGradientImage(gradient, NavigationController.NavigationBar.Frame.Size);
            
            NavigationController.NavigationBar.BarTintColor = new UIColor(image);

            NavigationController.TabBarController.TabBar.Layer.InsertSublayer(gradient,0);
            NavigationController.TabBarController.TabBar.UnselectedItemTintColor = UIColor.DarkGray;
        }

        public void SetChampionats(ChampionatDto[] championats)
        {
            _championats = championats;
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

            cell.Layer.InsertSublayer(GradientColor.ShowAgain(TableView.Frame.Width,tableView.Frame.Height), 0);
            
            return cell;

        }
        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _championats.Length;
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
    }
}