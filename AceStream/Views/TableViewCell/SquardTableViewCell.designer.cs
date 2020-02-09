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
    [Register ("SquardTableViewCell")]
    partial class SquardTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HomeName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel HomeNumber { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel VisitorName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel VisitorNumber { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (HomeName != null) {
                HomeName.Dispose ();
                HomeName = null;
            }

            if (HomeNumber != null) {
                HomeNumber.Dispose ();
                HomeNumber = null;
            }

            if (VisitorName != null) {
                VisitorName.Dispose ();
                VisitorName = null;
            }

            if (VisitorNumber != null) {
                VisitorNumber.Dispose ();
                VisitorNumber = null;
            }
        }
    }
}