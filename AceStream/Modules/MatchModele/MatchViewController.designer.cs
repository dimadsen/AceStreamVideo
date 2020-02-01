// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace AceStream.Modules.MatchModele
{
    [Register ("MatchViewController")]
    partial class MatchViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView ControlTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Score { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl SegmentedControl { get; set; }

        [Action ("Changed:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Changed (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (ControlTableView != null) {
                ControlTableView.Dispose ();
                ControlTableView = null;
            }

            if (Score != null) {
                Score.Dispose ();
                Score = null;
            }

            if (SegmentedControl != null) {
                SegmentedControl.Dispose ();
                SegmentedControl = null;
            }
        }
    }
}