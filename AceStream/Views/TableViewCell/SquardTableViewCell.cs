using System;

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
    }
}
