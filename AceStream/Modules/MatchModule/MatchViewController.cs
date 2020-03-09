using System;
using System.Collections.Generic;
using System.Linq;
using AceStream.Dto;
using AceStream.Extansions;
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

        private MatchDto _match;
        private string[] _titles;


        public MatchViewController(IntPtr handle) : base(handle)
        {
            Configurator = new MatchConfigurator();
            Configurator.Configure(this);
        }

        public override void ViewDidLoad()
        {
            Presenter.ConfigureView();

            SegmentedControl.ValueChanged += SettingTableChanged;
        }        

        #region Инициализация компонентов view

        public void SetSettings()
        {
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;

            ControlTableView.DataSource = this;
            ControlTableView.Bounces = false;

            Score.AdjustsFontForContentSizeCategory = true;
            Score.AdjustsFontSizeToFitWidth = true;

            Score.MinimumScaleFactor = 10 / UIFont.LabelFontSize;

            ControlTableView.TableFooterView = new UIView(CGRect.Empty);

            ControlTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
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

        public void SetTableSquard()
        {
            _titles = new string[] { "Стартовые составы", "Замены" };
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            var linkRow = ControlTableView.IndexPathForCell(sender as AceLinkTableViewCell).Row;

            var link = _match.Links[linkRow].Link;

            Presenter.Router.Prepare(segue, link);
        }

        #endregion

        #region Инициализация ячеек

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = null;

            if (SegmentedControl.SelectedSegment.IsSquards())
            {
                cell = GetSquardCell(tableView, indexPath);
            }
            else if (SegmentedControl.SelectedSegment.IsBroadCasts())
            {
                cell = GetBroadcastCell(tableView, indexPath);
            }

            return cell;
        }

        private UITableViewCell GetSquardCell(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.RegisterNibForCellReuse(SquardTableViewCell.Nib, "SquardTableViewCell");
            var cell = tableView.DequeueReusableCell(SquardTableViewCell.Key) as SquardTableViewCell;

            ControlTableView.AllowsSelection = false; //Отключает кликабельность cell

            if (indexPath.Section.IsStartings())
            {
                cell.UpdateCell(_match.HomeSquard.Startings[indexPath.Row], _match.VisitorSquard.Startings[indexPath.Row]);
            }
            else if (indexPath.Section.IsSubstitutes())
            {
                var homePlayer = GetPlayer(_match.HomeSquard.Substitutes, indexPath.Row);

                var visitorPlayer = GetPlayer(_match.VisitorSquard.Substitutes, indexPath.Row);
                cell.UpdateCell(homePlayer, visitorPlayer);
            }

            return cell;
        }

        private UITableViewCell GetBroadcastCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(AceLinkTableViewCell.Key) as AceLinkTableViewCell;

            ControlTableView.AllowsSelection = true;

            cell.UpdateCell(_match.Links[indexPath.Row]);

            return cell;
        }

        /// <summary>
        /// У команд может быть разное количество запасных игроков. Норма, если в массиве не нашёл
        /// </summary>
        private PlayerDto GetPlayer(List<PlayerDto> players, int row)
        {
            PlayerDto player = null;

            try
            {
                player = players[row];
            }
            catch (ArgumentOutOfRangeException) { }

            return player;
        }

        /// <summary>
        /// Количество секций
        /// </summary>
        [Export("numberOfSectionsInTableView:")]
        public nint NumberOfSections(UITableView tableView)
        {
            //По умолчанию одна секция
            nint sectionCount = 1;

            if (SegmentedControl.SelectedSegment.IsSquards())
            {
                sectionCount = _titles.Length;
            }

            return sectionCount;
        }

        /// <summary>
        /// Отображает количество строк в секции
        /// </summary>
        public nint RowsInSection(UITableView tableView, nint section)
        {
            nint rowsInSection = 0;

            if (SegmentedControl.SelectedSegment.IsSquards())
            {
                rowsInSection = CountPlayerOfSection((int)section);
            }
            else if (SegmentedControl.SelectedSegment.IsBroadCasts())
            {
                rowsInSection = _match.Links.Count;
            }

            return rowsInSection;
        }

        /// <summary>
        /// Определяет количество игроков в отображаемой секции.
        /// В основе всегда 11, но запас может иметь разное количество игроков. Количество запасных у каждой команды тоже может отличаться.
        /// Поэтому нужно выделить количество ячеек по максимальной длине состава
        /// </summary>
        public nint CountPlayerOfSection(int section)
        {
            if (section.IsSubstitutes())
            {
                var subHomeCount = _match.HomeSquard.Substitutes.Count;
                var subVisitorCount = _match.VisitorSquard.Substitutes.Count;

                return Math.Max(subHomeCount, subVisitorCount);
            }

            return 11;
        }

        /// <summary>
        /// Выбирает название секции
        /// </summary>
        [Export("tableView:titleForHeaderInSection:")]
        public string TitleForHeader(UITableView tableView, nint section)
        {
            string title = null;

            ///Пока только таблицу с составами разбиваем на секции
            if (SegmentedControl.SelectedSegment.IsSquards())
            {
                title = _titles[section];
            }

            return title;
        }

        #endregion

        #region Событие переключения сегментов
        private void SettingTableChanged(object sender, EventArgs e)
        {
            if (SegmentedControl.SelectedSegment.IsSquards())
            {
                ControlTableView.AllowsSelection = false;
                ControlTableView.Bounces = false;

                ControlTableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
                ControlTableView.ReloadData();
            }
            else if (SegmentedControl.SelectedSegment.IsBroadCasts())
            {
                ControlTableView.AllowsSelection = true;
                ControlTableView.Bounces = true;

                ControlTableView.SeparatorStyle = UITableViewCellSeparatorStyle.SingleLine;
                ControlTableView.ReloadData();
            }
        }
        #endregion
    }
}

