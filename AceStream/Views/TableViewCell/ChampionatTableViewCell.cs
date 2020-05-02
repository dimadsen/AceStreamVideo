using System;
using AceStream.Dto;
using Foundation;
using UIKit;

namespace AceStream.Views.TableViewCell
{
    public partial class ChampionatTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("ChampionatTableViewCell");
        public static readonly UINib Nib;

        static ChampionatTableViewCell()
        {
            Nib = UINib.FromName("ChampionatTableViewCell", NSBundle.MainBundle);
        }

        protected ChampionatTableViewCell(IntPtr handle) : base(handle)
        {

        }

        public ChampionatTableViewCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {

        }

        public void UpdateCell(ChampionatDto dto)
        {
            Icon.Image = UIImage.FromFile($"Championats/{dto.Image}");
            Name.Text = dto.Name;
            Tour.Text = dto.Tour;
        }

    }
}
