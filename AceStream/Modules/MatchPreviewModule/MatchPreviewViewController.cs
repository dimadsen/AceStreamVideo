using System;
using AceStream.Dto;
using AceStream.Modules.MatchPreviewModule;
using AceStream.Views.TableViewCell;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AceStream
{
    public partial class MatchPreviewViewController : UITableViewController, IMatchPreviewView
    {
        public IMatchPreviewPresenter Presenter { get; set; }
        public IMatchPreviewConfigurator Configurator { get; set; }

        MatchPreviewDto[] _matches;

        public MatchPreviewViewController(IntPtr handle) : base(handle)
        {
            Configurator = new MatchPreviewConfigurator();
            Configurator.Configure(this);
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Presenter.ConfigureView();
        }

        public void SetSettings()
        {
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;
            TableView.TableFooterView = new UIView(CGRect.Empty);
        }

        public void SetMatches(MatchPreviewDto[] matches)
        {
            _matches = matches;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //tableView.RegisterNibForCellReuse(MatchPreviewTableViewCell.Nib, "MatchPreviewTableViewCell");

            var cell = tableView.DequeueReusableCell("MatchPreviewTableViewCell") as MatchPreviewTableViewCell;

            if (cell == null)
                cell = new MatchPreviewTableViewCell(new NSString("MatchPreviewTableViewCell"));

            cell.UpdateCell(_matches[indexPath.Row]);

            return cell;

        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _matches.Length;
        }
    }
}