using System;
using AceStream.Views.TableViewCell;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AceStream.Modules.MatchModele
{
    public partial class MatchViewController : UIViewController, IUITableViewDataSource
    {
        public MatchViewController(IntPtr handle) : base(handle)
        {
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.RegisterNibForCellReuse(SquardTableViewCell.Nib, "SquardTableViewCell");
            var squardCell = tableView.DequeueReusableCell(SquardTableViewCell.Key) as SquardTableViewCell;

            var linksCell = tableView.DequeueReusableCell(AceLinkTableViewCell.Key) as AceLinkTableViewCell;

            switch (SegmentedControl.SelectedSegment)
            {
                case 0:
                    ControlTableView.AllowsSelection = false;
                    return squardCell;
                case 1:
                    ControlTableView.AllowsSelection = true;
                    return linksCell;
                default:
                    throw new Exception("Не могу выбрать cell");
            }


        }

        public nint RowsInSection(UITableView tableView, nint section)
        {
            return 3;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;

            ControlTableView.DataSource = this;
            

            Score.AdjustsFontForContentSizeCategory = true;
            Score.AdjustsFontSizeToFitWidth = true;

            Score.MinimumScaleFactor = 10 / UIFont.LabelFontSize;

            ControlTableView.TableFooterView = new UIView(CGRect.Empty);

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

        

        




    }
}

