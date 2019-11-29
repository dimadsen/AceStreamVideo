// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace AceStream.Views.TableViewCell
{
    [Register ("ChampionatTableViewCell")]
    partial class ChampionatTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Icon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Name { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Tour { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Icon != null) {
                Icon.Dispose ();
                Icon = null;
            }

            if (Name != null) {
                Name.Dispose ();
                Name = null;
            }

            if (Tour != null) {
                Tour.Dispose ();
                Tour = null;
            }
        }
    }
}