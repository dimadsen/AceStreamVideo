using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;
using AceStream.Utils;
using AceStream.Views.TableViewCell;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Essentials;
using AceStream.iOS.Modules.MatchPreviewModule;

namespace AceStream
{
    public partial class MatchPreviewViewController : UITableViewController, IMatchPreviewView, IUIScrollViewDelegate
    {
        public IMatchPreviewPresenter Presenter { get; set; }
        public IMatchPreviewConfigurator Configurator { get; set; }

        private List<MatchPreviewDto> _matches;

        public MatchPreviewViewController(IntPtr handle) : base(handle)
        {
            Configurator = new MatchPreviewConfigurator();
            Configurator.Configure(this);
        }

        public override void ViewDidLoad()
        {
            Task.Run(async () =>
            {
                await Presenter.SetMatchesAsync();

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

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            var row = TableView.IndexPathForCell(sender as MatchPreviewTableViewCell).Row;

            var match = _matches[row];

            Presenter.PrepareForSegue(segue.DestinationViewController, match.Id, NavigationItem.Title);
        }

        public override void ViewWillDisappear(bool animated)
        {
            NavigationItemImage.HiddenImage();
        }

        public override void ViewDidAppear(bool animated)
        {
            NavigationItemImage.ShowImage();
        }

        public async Task SetMatchesAsync(Task<List<MatchPreviewDto>> matches)
        {
            _matches = await matches;

            _matches.ForEach(match =>
            {
                match.HomePicture = ImageUtils.DownloadFile(match.Home, match.HomePicture);

                match.VisitorPicture = ImageUtils.DownloadFile(match.Visitor, match.VisitorPicture);
            });
        }

        public void SetSettings(MatchPreviewSettingsDto dto)
        {
            NavigationItem.Title = dto.Title;

            var champImage = (UIImageView)NavigationController.NavigationBar.ViewWithTag(NavigationItemImage.Tag);

            champImage.Image = UIImage.FromFile($"Championats/{dto.Image}");

            TableView.TableFooterView = new UIView(CGRect.Empty);

        }

        [Export("scrollViewDidScroll:")]
        public void Scrolled(UIScrollView scrollView)
        {
            var height = NavigationController?.NavigationBar.Frame.Height ?? 0;

            NavigationItemImage.MoveAndResizeImage(height);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("MatchPreviewTableViewCell") as MatchPreviewTableViewCell;

            if (cell == null)
                cell = new MatchPreviewTableViewCell(new NSString("MatchPreviewTableViewCell"));

            cell.Favorites.Tag = indexPath.Row;

            cell.UpdateCell(_matches[indexPath.Row]);

            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _matches?.Count ?? 0;
        }        

        public void SetErrorView()
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

        public void SetNotFoundMatches(string message)
        {
            throw new NotImplementedException();
        }
    }
}