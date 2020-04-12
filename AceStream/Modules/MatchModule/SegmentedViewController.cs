using AceStream.Dto;
using AceStream.SubModules.LinkSubModule;
using AceStream.SubModules.SquardSubModule;
using UIKit;
using XLPagerTabStrip;

namespace AceStream.Modules.MatchModule
{
    public partial class SegmentedViewController : ButtonBarPagerTabStripViewController
    {
        private MatchDto _match;

        public SegmentedViewController(MatchDto match)
        {
            _match = match;
        }

        public override void ViewDidLoad()
        {
            UIColor themeColor = UIColor.FromRGB(227, 242, 234);

            Settings.Style.ButtonBarBackgroundColor = themeColor;
            Settings.Style.ButtonBarItemBackgroundColor = themeColor;
            Settings.Style.SelectedBarBackgroundColor = UIColor.Black;
            Settings.Style.ButtonBarItemFont = UIFont.BoldSystemFontOfSize(12);
            Settings.Style.SelectedBarHeight = 2;
            Settings.Style.SelectedBarWidth = 70;
            Settings.Style.ButtonBarMinimumLineSpacing = 0;
            Settings.Style.ButtonBarItemTitleColor = UIColor.Black;
            Settings.Style.ButtonBarItemsShouldFillAvailiableWidth = true;
            Settings.Style.ButtonBarLeftContentInset = 0;
            Settings.Style.ButtonBarRightContentInset = 0;
            Settings.Style.ButtonBarHeight = 30;

            NavigationItem.Title = "Back";
            NavigationItem.BackBarButtonItem = new UIBarButtonItem("Back", UIBarButtonItemStyle.Plain, null);

            base.ViewDidLoad();
        }

        public override UIViewController[] CreateViewControllersForPagerTabStrip(PagerTabStripViewController pagerTabStripViewController)
        {
            var storyboard = UIStoryboard.FromName("WatchMatch", null);

            var squardViewController = storyboard.InstantiateViewController("SquardViewController") as SquardViewController;
            squardViewController.Presenter.Match = _match;

            var linkViewController = storyboard.InstantiateViewController("LinkViewController") as LinkViewController;
            linkViewController.Presenter.Parametrs = new string[] { _match.Home, _match.Visitor };

            return new UIViewController[] { squardViewController, linkViewController };
        }
    }
}

