using System;
using System.Collections.Generic;
using AceStream.Additionals;
using AceStream.Dto;
using AceStream.Views.TableViewCell;
using CoreGraphics;
using Foundation;
using UIKit;
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
            base.ViewDidLoad();

            Presenter.ConfigureView();
        }


        public IndicatorInfo IndicatorInfoForPagerTabStrip(PagerTabStripViewController pagerTabStripController)
        {
            return new IndicatorInfo("Трансляции");
        }

        public void SetSettings()
        {
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;

            TableView.DataSource = this;

            TableView.TableFooterView = new UIView(CGRect.Empty);
            TableView.TableFooterView.Layer.InsertSublayer(GradientColor.ShowAgain(TableView.Frame.Width, TableView.Frame.Height), 0);
        }

        public void SetLinks(List<LinkDto> links)
        {
            _links = links;
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
            return _links.Count;
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            var linkRow = TableView.IndexPathForCell(sender as AceLinkTableViewCell).Row;

            var link = _links[linkRow].Link;

            Presenter.Router.Prepare(segue, link);
        }
    }
}

