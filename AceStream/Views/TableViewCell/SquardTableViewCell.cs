using System;
using AceStream.Additionals;
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

        public void UpdateCell(PlayerDto homePlayer, PlayerDto visitorPlayer)
        {
            HomeNumber.Text = homePlayer?.Number;
            HomeName.Text = homePlayer != null ? homePlayer.Name : null;
            HomeFlag.Image = homePlayer != null ? UIImage.FromFile($"Flags/{homePlayer.Flag}") : null;

            VisitorNumber.Text = visitorPlayer?.Number;
            VisitorName.Text = visitorPlayer != null ? visitorPlayer.Name : null;
            VisitorFlag.Image = visitorPlayer != null ? UIImage.FromFile($"Flags/{visitorPlayer.Flag}") : null;
        }
    }
}
