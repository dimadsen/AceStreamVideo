using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Additionals;
using AceStream.Dto;
using AceStream.Utils;
using AceStream.Views.TableViewCell;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Essentials;
using XLPagerTabStrip;

namespace AceStream.SubModules.LinkSubModule
{
    public partial class LinkViewController : UITableViewController, IIndicatorInfoProvider, ILinkView
    {
        public ILinkConfigurator Configurator { get; set; }
        public ILinkPresenter Presenter { get; set; }

        private List<LinkDto> _links;

        public LinkViewController(IntPtr handle) : base(handle)
        {
            Configurator = new LinkConfigurator();
            Configurator.Configure(this);
        }

        public override void ViewDidLoad()
        {
            Task.Run(async () =>
            {
                await Presenter.SetLinksAsync();

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

        public async Task SetLinksAsync(Task<List<LinkDto>> links)
        {
            _links = await links;
        }
        
        public void SetSettings()
        {
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;

            TableView.DataSource = this;

            TableView.TableFooterView = new UIView(CGRect.Empty);

            TableView.ScrollEnabled = false;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(AceLinkTableViewCell.Key) as AceLinkTableViewCell;

            if (cell == null)
                cell = new AceLinkTableViewCell(new NSString("AceLinkTableViewCell"));

            cell.UpdateCell(_links[indexPath.Row]);

            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _links?.Count ?? 0;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            var linkRow = TableView.IndexPathForCell(sender as AceLinkTableViewCell).Row;

            var link = _links[linkRow].Link;

            Presenter.Router.Prepare(segue, link);
        }

        public IndicatorInfo IndicatorInfoForPagerTabStrip(PagerTabStripViewController pagerTabStripController)
        {
            return new IndicatorInfo("Трансляции");
        }

        public void SetError()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var imageview = new UIImageView(new CGRect(TableView.Frame.X, TableView.Frame.Y, 200, 200))
                {
                    Image = UIImage.FromFile("error_image.png")
                };

                imageview.Center = TableView.ConvertPointFromView(TableView.Center, imageview);

                TableView.AddSubview(imageview);
            });
        }
    }
}

