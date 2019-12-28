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

namespace AceStream.Modules.RegistrationModule
{
    [Register ("RegistrationViewController")]
    partial class RegistrationViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Email { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Name { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Password { get; set; }

        [Action ("Close:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void Close (UIKit.UIButton sender);

        [Action ("SignUp:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SignUp (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Email != null) {
                Email.Dispose ();
                Email = null;
            }

            if (Name != null) {
                Name.Dispose ();
                Name = null;
            }

            if (Password != null) {
                Password.Dispose ();
                Password = null;
            }
        }
    }
}