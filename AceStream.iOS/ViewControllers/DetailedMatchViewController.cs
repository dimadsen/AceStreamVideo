using AceStream.Dto;
using AceStream.Modules.LinkModule;
using AceStream.Utils;
using UIKit;
using XLPagerTabStrip;

namespace AceStream.Modules.MatchModule
{
    public partial class DetailedMatchViewController : ButtonBarPagerTabStripViewController
    {
        private MatchDto _match;

        public DetailedMatchViewController(MatchDto match)
        {
            _match = match;
        }

        public override void ViewDidLoad()
        {
            var themeColor = ColorUtils.GetInterfaceStyle();

            Settings.Style.ButtonBarBackgroundColor = themeColor;

            Settings.Style.ButtonBarItemFont = UIFont.SystemFontOfSize(12);

            Settings.Style.ButtonBarItemBackgroundColor = themeColor;

            Settings.Style.SelectedBarBackgroundColor = UIColor.SystemGray6Color;
            Settings.Style.SelectedBarHeight = 2;
            Settings.Style.SelectedBarWidth = View.Frame.Width / 2;

            Settings.Style.ButtonBarMinimumLineSpacing = 0;
            Settings.Style.ButtonBarItemTitleColor = UIColor.SystemGray6Color;
            Settings.Style.ButtonBarItemsShouldFillAvailiableWidth = true;
            Settings.Style.ButtonBarLeftContentInset = 0;
            Settings.Style.ButtonBarRightContentInset = 0;
            Settings.Style.ButtonBarHeight = 30;
            Settings.Style.LabelWidth = View.Frame.Width / 2;

            NavigationItem.Title = "Back";
            NavigationItem.BackBarButtonItem = new UIBarButtonItem("Back", UIBarButtonItemStyle.Plain, null);

            base.ViewDidLoad();
        }

        public override UIViewController[] CreateViewControllersForPagerTabStrip(PagerTabStripViewController pagerTabStripViewController)
        {
            var storyboard = UIStoryboard.FromName("WatchMatch", null);

            var squardViewController = storyboard.InstantiateViewController("SquardViewController") as SquardViewController;
            squardViewController.Presenter.MatchId = _match.Id;

            var linkViewController = storyboard.InstantiateViewController("LinkViewController") as LinkViewController;
            linkViewController.Presenter.Parametrs = _match.Channels;

            return new UIViewController[] { squardViewController, linkViewController };
        }
    }
}

