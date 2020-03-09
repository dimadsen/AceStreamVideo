using System;
using AceStream.Dto.SettingsDto;
using Foundation;
using UIKit;

namespace AceStream.Views.TableViewCell
{
    public partial class SettingTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("SettingTableViewCell");
        public static readonly UINib Nib;

        static SettingTableViewCell()
        {
            Nib = UINib.FromName("SettingTableViewCell", NSBundle.MainBundle);
        }

        protected SettingTableViewCell(IntPtr handle) : base(handle)
        {
        }
        public SettingTableViewCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {
        }
        public void UpdateCell(MenuSettingsDto dto)
        {
            Name.Text = dto.Name;
            Image.Image = UIImage.FromFile(dto.Image);
        }
    }
}
