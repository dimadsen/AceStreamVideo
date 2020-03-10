using System;
using AceStream.Dto;
using CoreGraphics;
using UIKit;

namespace AceStream.Modules.MatchModule
{
    public partial class MatchViewController : UIViewController, IMatchView
    {
        public IMatchPresenter Presenter { get; set; }
        public IMatchConfigurator Configurator { get; set; }

        private MatchDto _match;

        public MatchViewController(IntPtr handle) : base(handle)
        {
            Configurator = new MatchConfigurator();
            Configurator.Configure(this);            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Presenter.ConfigureView();
            
            var controller = Presenter.Router.InitializeSegmented(_match);

            controller.View.Frame = new CGRect(0, 318, 375, 299);
            View.AddSubview(controller.View);
        }


        public void SetSettings()
        {
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;
            
            Score.AdjustsFontForContentSizeCategory = true;
            Score.AdjustsFontSizeToFitWidth = true;

            Score.MinimumScaleFactor = 10 / UIFont.LabelFontSize;

        }

        public void SetMatch(MatchDto match)
        {
            _match = match;

            Home.Text = match.Home;
            HomePicture.Image = UIImage.FromFile(match.ImageHome);

            Visitor.Text = match.Visitor;
            VisitorPicture.Image = UIImage.FromFile(match.ImageVisitor);

            Score.Text = match.Score;
            Half.Text = match.Half;

            Date.Text = match.Date.ToString("d/M/yyyy HH:mm");
        }
            
    }
}

