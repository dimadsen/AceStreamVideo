using System;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;
using AceStream.Modules.MatchPreviewModule;
using AceStream.Views.TableViewCell;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AceStream
{
    public partial class MatchPreviewViewController : UITableViewController, IMatchPreviewView, IUIScrollViewDelegate
    {
        public IMatchPreviewPresenter Presenter { get; set; }
        public IMatchPreviewConfigurator Configurator { get; set; }

        private MatchPreviewDto[] _matches;

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

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            var matchId = TableView.IndexPathForCell(sender as UITableViewCell).Row;

            Presenter.Router.Prepare(segue, matchId);
        }

        public override void ViewWillDisappear(bool animated)
        {
            NavigationItemImage.HiddenImage();
        }

        public override void ViewDidAppear(bool animated)
        {
            NavigationItemImage.ShowImage();
        }

        public void SetSettings(MatchPreviewSettingsDto dto)
        {
            NavigationItem.Title = dto.Title;

            var champImage = (UIImageView)NavigationController.NavigationBar.ViewWithTag(NavigationItemImage.Tag);

            champImage.Image = UIImage.FromFile(dto.Image);

            TableView.TableFooterView = new UIView(CGRect.Empty);
        }

        [Export("scrollViewDidScroll:")]
        public void Scrolled(UIScrollView scrollView)
        {
            var height = NavigationController.NavigationBar.Frame.Height;

            NavigationItemImage.MoveAndResizeImage(height);
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

            cell.Favorites.Tag = indexPath.Row;

            cell.UpdateCell(_matches[indexPath.Row]);

            return cell;

        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _matches.Length;
        }
    }
}