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
    [Register ("AceLinkTableViewCell")]
    partial class AceLinkTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Channel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Channel != null) {
                Channel.Dispose ();
                Channel = null;
            }
        }
    }
}