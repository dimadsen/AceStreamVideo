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
    [Register ("MatchPreviewTableViewCell")]
    partial class MatchPreviewTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        public UIKit.UIButton Favorites { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Home { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView HomeIcon { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Time { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Visitor { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView VisitorIcon { get; set; }

        [Action ("AddToFavorites:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AddToFavorites (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Favorites != null) {
                Favorites.Dispose ();
                Favorites = null;
            }

            if (Home != null) {
                Home.Dispose ();
                Home = null;
            }

            if (HomeIcon != null) {
                HomeIcon.Dispose ();
                HomeIcon = null;
            }

            if (Time != null) {
                Time.Dispose ();
                Time = null;
            }

            if (Visitor != null) {
                Visitor.Dispose ();
                Visitor = null;
            }

            if (VisitorIcon != null) {
                VisitorIcon.Dispose ();
                VisitorIcon = null;
            }
        }
    }
}