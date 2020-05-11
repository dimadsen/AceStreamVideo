using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using AceStream.Additionals;
using AceStream.Dto;
using AceStream.Extansions;
using AceStream.Views.TableViewCell;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Essentials;
using XLPagerTabStrip;

namespace AceStream.SubModules.SquardSubModule
{
    public partial class SquardViewController : UITableViewController, ISquardView, IIndicatorInfoProvider
    {
        public ISquardPresenter Presenter { get; set; }
        public ISquardConfigurator Configurator { get; set; }

        private MatchDto _match;
        private string[] _titles;

        public SquardViewController(IntPtr handle) : base(handle)
        {
            Configurator = new SquardConfigurator();
            Configurator.Configure(this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Presenter.ConfigureView();
            Presenter.SetPlayers();
        }

        public void SetSettings()
        {
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Never;

            TableView.DataSource = this;

            TableView.TableFooterView = new UIView(CGRect.Empty);

            TableView.RowHeight = 30;

            TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            //TableView.TableFooterView.Layer.InsertSublayer(GradientColor.ShowAgain(View.Frame.Width, View.Frame.Height), 0);
        }

        public void SetPlayers(MatchDto match)
        {
            _match = match;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.RegisterNibForCellReuse(SquardTableViewCell.Nib, "SquardTableViewCell");
            var cell = tableView.DequeueReusableCell(SquardTableViewCell.Key) as SquardTableViewCell;

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

        /// <summary>
        /// Отображает количество строк в секции
        /// В стартовом составе всегда 11, запасных разное количество
        /// </summary>
        public override nint RowsInSection(UITableView tableView, nint section)
        {
            if (_match == null)
                return 0;

            if (section.IsSubstitutes())
            {
                var subHomeCount = _match.HomeSquard.Substitutes.Count;
                var subVisitorCount = _match.VisitorSquard.Substitutes.Count;

                return Math.Max(subHomeCount, subVisitorCount);
            }

            return 11;
        }

        /// <summary>
        /// Количество секций
        /// </summary>
        /// <param name="tableView"></param>
        /// <returns></returns>
        public override nint NumberOfSections(UITableView tableView)
        {
            return _titles?.Length ?? 0;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return _titles?[section];
        }

        /// <summary>
        /// У команд может быть разное количество запасных игроков. Норма, если в массиве не нашёл
        /// </summary>
        private PlayerDto GetPlayer(List<PlayerDto> players, int row)
        {
            try
            {
                var player = players[row];

                return player;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        public override void WillDisplayHeaderView(UITableView tableView, UIView headerView, nint section)
        {
            var view = headerView as UITableViewHeaderFooterView;

            view.TextLabel.Font = UIFont.SystemFontOfSize(12);
            view.TextLabel.TintColor = UIColor.DarkGray;
            view.TextLabel.TextAlignment = UITextAlignment.Center;
        }

        public void SetTableSquard()
        {
            _titles = new string[] { "Стартовые составы", "Запасные" };
        }

        public IndicatorInfo IndicatorInfoForPagerTabStrip(PagerTabStripViewController pagerTabStripController)
        {
            return new IndicatorInfo("Составы");
        }

        public void SetNotFoundPlayers()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var label = new UILabel(new CGRect(TableView.Frame.X, TableView.Frame.Y, 300, 50))
                {
                    Text = "Составы не опубликованы",
                    TextAlignment = UITextAlignment.Center
                };

                label.Center = TableView.ConvertPointFromView(TableView.Center, label);

                TableView.AddSubview(label);
            });
        }
    }
}

