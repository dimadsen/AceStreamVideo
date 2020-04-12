using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AceStream.Additionals;
using AceStream.Dto;
using AceStream.Dto.SettingsDto;
using AceStream.Modules.MatchPreviewModule;
using AceStream.Utils;
using AceStream.Views.TableViewCell;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Essentials;

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
            var matchId = TableView.IndexPathForCell(sender as MatchPreviewTableViewCell).Row;

            Presenter.Router.Prepare(segue, matchId, NavigationItem.Title);
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
        }

        public void SetSettings(MatchPreviewSettingsDto dto)
        {
            NavigationItem.Title = dto.Title;

            var champImage = (UIImageView)NavigationController.NavigationBar.ViewWithTag(NavigationItemImage.Tag);

            champImage.Image = UIImage.FromFile(dto.Image);

            TableView.TableFooterView = new UIView(CGRect.Empty);

            TableView.TableFooterView.Layer.InsertSublayer(GradientColor.ShowAgain(TableView.Frame.Width, TableView.Frame.Height), 0);

            var gradient = GradientColor.ShowAgain(NavigationController.NavigationBar.Frame.Width, NavigationController.NavigationBar.Frame.Height);

            var image = ImageUtils.GetGradientImage(gradient, NavigationController.NavigationBar.Frame.Size);

            View.BackgroundColor = new UIColor(image);
        }

        [Export("scrollViewDidScroll:")]
        public void Scrolled(UIScrollView scrollView)
        {
            var height = NavigationController.NavigationBar.Frame.Height;

            NavigationItemImage.MoveAndResizeImage(height);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("MatchPreviewTableViewCell") as MatchPreviewTableViewCell;

            if (cell == null)
                cell = new MatchPreviewTableViewCell(new NSString("MatchPreviewTableViewCell"));

            cell.Favorites.Tag = indexPath.Row;

            cell.Layer.InsertSublayer(GradientColor.ShowAgain(TableView.Frame.Width, TableView.Frame.Height), 0);
            cell.UpdateCell(_matches[indexPath.Row]);

            return cell;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return _matches?.Count ?? 0;
        }        

        public void SetErrorView()
        {
            throw new NotImplementedException();
        }
    }
}