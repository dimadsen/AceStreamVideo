﻿// WARNING
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
    [Register ("SettingTableViewCell")]
    partial class SettingTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView Image { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Name { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Image != null) {
                Image.Dispose ();
                Image = null;
            }

            if (Name != null) {
                Name.Dispose ();
                Name = null;
            }
        }
    }
}