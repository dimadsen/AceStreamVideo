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

namespace AceStream
{
    [Register ("MatchPreviewViewController")]
    partial class MatchPreviewViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView Indicator { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Indicator != null) {
                Indicator.Dispose ();
                Indicator = null;
            }
        }
    }
}