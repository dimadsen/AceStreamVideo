using System;
using System.Text.RegularExpressions;
using AceStream.Dto;
using AceStream.Views.TableViewCell;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AceStream.Modules.MatchModule
{
    public partial class MatchViewController : UIViewController, IUITableViewDataSource, IMatchView
    {
        public IMatchPresenter Presenter { get; set; }
        public IMatchConfigurator Configurator { get; set; }


        public MatchViewController(IntPtr handle) : base(handle)
        {
            Configurator = new MatchConfigurator();
            Configurator.Configure(this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Presenter.ConfigureView();


            SegmentedControl.ValueChanged += (sender, e) =>
            {
                switch (SegmentedControl.SelectedSegment)
                {
                    case 0:
                        {
                            ControlTableView.AllowsSelection = false;
                            ControlTableView.ReloadData();
                            break;
                        }
                    case 1:
                        {
                            ControlTableView.AllowsSelection = true;
                            ControlTableView.ReloadData();
                            break;

                        }
                }
            };
        }


        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            switch (SegmentedControl.SelectedSegment)
            {
                case 0:
                    {
                        tableView.RegisterNibForCellReuse(SquardTableViewCell.Nib, "SquardTableViewCell");
                        var squardCell = tableView.DequeueReusableCell(SquardTableViewCell.Key) as SquardTableViewCell;

                        ControlTableView.AllowsSelection = false;
                        return squardCell;
                    }
                    
                case 1:
                    {
                        var linksCell = tableView.DequeueReusableCell(AceLinkTableViewCell.Key) as AceLinkTableViewCell;

                        ControlTableView.AllowsSelection = true;
                        return linksCell;
                    }

                default:
                    throw new Exception("Не могу выбрать cell");
            }

        }

        public nint RowsInSection(UITableView tableView, nint section)
        {
            return 3;
        }

        public void SetSettings()
        {
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;

            ControlTableView.DataSource = this;

            Score.AdjustsFontForContentSizeCategory = true;
            Score.AdjustsFontSizeToFitWidth = true;

            Score.MinimumScaleFactor = 10 / UIFont.LabelFontSize;

            ControlTableView.TableFooterView = new UIView(CGRect.Empty);

        }
        
        public void SetMatch(MatchDto dto)
        {
            throw new NotImplementedException();
        }
    }
}

