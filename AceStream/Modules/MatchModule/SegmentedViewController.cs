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
            UIColor themeColor = UIColor.FromRGB(57, 136, 125);

            Settings.Style.ButtonBarBackgroundColor = themeColor;

            Settings.Style.ButtonBarItemFont = UIFont.SystemFontOfSize(12);

            Settings.Style.ButtonBarItemBackgroundColor = themeColor;

            Settings.Style.SelectedBarBackgroundColor = UIColor.LightTextColor;
            Settings.Style.SelectedBarHeight = 2;
            Settings.Style.SelectedBarWidth = View.Frame.Width / 2;

            Settings.Style.ButtonBarMinimumLineSpacing = 0;
            Settings.Style.ButtonBarItemTitleColor = UIColor.White;
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
            squardViewController.Presenter.Match = _match;

            var linkViewController = storyboard.InstantiateViewController("LinkViewController") as LinkViewController;
            linkViewController.Presenter.Parametrs = new string[] { _match.Home, _match.Visitor };

            return new UIViewController[] { squardViewController, linkViewController };
        }
    }
}

