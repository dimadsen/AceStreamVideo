using System;
using AceStream.Dto;
using Foundation;
using UIKit;

namespace AceStream.Views.TableViewCell
{
    public partial class SquardTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("SquardTableViewCell");
        public static readonly UINib Nib;

        static SquardTableViewCell()
        {
            Nib = UINib.FromName("SquardTableViewCell", NSBundle.MainBundle);
        }

        protected SquardTableViewCell(IntPtr handle) : base(handle)
        {
            
        }
        public SquardTableViewCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {

        }

        public void UpdateCell(SquardDto homePlayer, SquardDto visitorPlayer)
        {
            HomeNumber.Text = homePlayer.Number;
            HomeName.Text = $"{homePlayer.LastName} {homePlayer.FirstName[0]}.";
            HomeFlag.Image = UIImage.FromFile(homePlayer.Flag);

            VisitorNumber.Text = visitorPlayer.Number;
            VisitorName.Text = $"{visitorPlayer.LastName} {visitorPlayer.FirstName[0]}.";
            VisitorFlag.Image = UIImage.FromFile(visitorPlayer.Flag);
        }
    }
}
