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

        private NavigationItemImage _champImage;
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

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            _champImage.ShowImage(show: false);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            _champImage.ShowImage(show: true);
        }

        public void SetSettings(MatchPreviewSettingsDto dto)
        {
            NavigationItem.Title = dto.Title;

            _champImage = new NavigationItemImage(dto.Image);

            NavigationController.NavigationBar.AddSubview(_champImage.ImageView);
            _champImage.ActivateConstraints(NavigationController.NavigationBar);

            TableView.TableFooterView = new UIView(CGRect.Empty);
        }

        [Export("scrollViewDidScroll:")]
        public void Scrolled(UIScrollView scrollView)
        {
            var height = NavigationController.NavigationBar.Frame.Height;

            _champImage.MoveAndResizeImage(height);
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