using System;

using Foundation;
using UIKit;

namespace AceStream.Views.TableViewCell
{
    public partial class AceLinkTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("AceLinkTableViewCell");
        public static readonly UINib Nib;

        static AceLinkTableViewCell()
        {
            Nib = UINib.FromName("AceLinkTableViewCell", NSBundle.MainBundle);
        }

        protected AceLinkTableViewCell(IntPtr handle) : base(handle)
        {
            
        }

        public AceLinkTableViewCell(NSString cellId) : base(UITableViewCellStyle.Default, cellId)
        {

        }
    }
}
