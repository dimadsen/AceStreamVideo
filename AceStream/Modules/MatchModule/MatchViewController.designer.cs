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

namespace AceStream.Modules.MatchModule
{
    [Register ("MatchViewController")]
    partial class MatchViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Date { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView DetailedMatchInfoView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Half { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Home { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView HomePicture { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView Indicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView MatchInfoView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Score { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Stadium { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Visitor { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView VisitorPicture { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Date != null) {
                Date.Dispose ();
                Date = null;
            }

            if (DetailedMatchInfoView != null) {
                DetailedMatchInfoView.Dispose ();
                DetailedMatchInfoView = null;
            }

            if (Half != null) {
                Half.Dispose ();
                Half = null;
            }

            if (Home != null) {
                Home.Dispose ();
                Home = null;
            }

            if (HomePicture != null) {
                HomePicture.Dispose ();
                HomePicture = null;
            }

            if (Indicator != null) {
                Indicator.Dispose ();
                Indicator = null;
            }

            if (MatchInfoView != null) {
                MatchInfoView.Dispose ();
                MatchInfoView = null;
            }

            if (Score != null) {
                Score.Dispose ();
                Score = null;
            }

            if (Stadium != null) {
                Stadium.Dispose ();
                Stadium = null;
            }

            if (Visitor != null) {
                Visitor.Dispose ();
                Visitor = null;
            }

            if (VisitorPicture != null) {
                VisitorPicture.Dispose ();
                VisitorPicture = null;
            }
        }
    }
}