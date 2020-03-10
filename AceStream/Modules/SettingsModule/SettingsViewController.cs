using System;
using AceStream.Dto.SettingsDto;
using AceStream.Extansions;
using AceStream.Modules.SettingsModule;
using AceStream.Views.TableViewCell;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AceStream
{
    public partial class SettingsViewController : UITableViewController, ISettingsView
    {
        public ISettingsPresenter Presenter { get; set; }
        public ISettingsConfigurator Configurator { get; set; }

        private MenuSettingsDto[] _menus;

        #region Инициализация
        public SettingsViewController (IntPtr handle) : base (handle)
        {
            Configurator = new SettingsConfigurator();
            Configurator.Configure(this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Presenter.ConfigureView();
        }

        public void Set(string title)
        {
            NavigationItem.Title = title;
            NavigationItem.LargeTitleDisplayMode = UINavigationItemLargeTitleDisplayMode.Always;

            TableView.TableFooterView = new UIView(CGRect.Empty);

            Presenter.Router.InitializeUser();            
        }

        public void SetMenus(MenuSettingsDto[] menus)
        {
            _menus = menus;
        }

        #endregion

        #region Переходы
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            Presenter.Router.Prepare(segue);
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            var identifier = GetIdentifier(indexPath);

            if (identifier != null)
                Presenter.Router.Prepare(NavigationController, identifier);
        }

        #endregion

        #region Получение ячеек
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Section.IsExit())
            {
                var cell = tableView.DequeueReusableCell("ExitTableViewCell") as SettingTableViewCell;

                if (cell == null)
                    cell = new SettingTableViewCell(new NSString("ExitTableViewCell"));

                return cell;
            }
            else
            {
                tableView.RegisterNibForCellReuse(SettingTableViewCell.Nib, "SettingTableViewCell");

                var cell = tableView.DequeueReusableCell(SettingTableViewCell.Key) as SettingTableViewCell;

                if (cell == null)
                    cell = new SettingTableViewCell(new NSString("SettingTableViewCell"));

                cell.UpdateCell(_menus[indexPath.Row]);
                
                return cell;
            }
        }

        /// <summary>
        /// Количество секций
        /// </summary>        
        public override nint NumberOfSections(UITableView tableView)
        {
            return 2;
        }

        /// <summary>
        /// Отображает количество строк в секции
        /// </summary>
        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return section.IsExit()? 1: _menus.Length;
        }

        public override string TitleForHeader(UITableView tableView, nint section)
        {
            return section.IsExit() ? string.Empty : "Основные";
        }

        private string GetIdentifier(NSIndexPath indexPath)
        {
            string identifier = null;

            if (indexPath.IsAccountRow())
            {
                identifier = "AccountViewController";
            }
            else if (indexPath.IsAboutRow())
            {
                identifier = "AboutViewController";
            }

            return identifier;
        }

        
        #endregion
    }
}