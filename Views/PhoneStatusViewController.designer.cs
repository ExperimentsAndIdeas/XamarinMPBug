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

namespace AELPMP
{
    [Register ("PhoneStatusViewController")]
    partial class PhoneStatusViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch AdvertiseSwitch { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch BrowseSwitch { get; set; }

        [Action ("AdvertiseSwitchChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void AdvertiseSwitchChanged (UIKit.UISwitch sender);

        [Action ("BrowseSwitchChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BrowseSwitchChanged (UIKit.UISwitch sender);

        void ReleaseDesignerOutlets ()
        {
            if (AdvertiseSwitch != null) {
                AdvertiseSwitch.Dispose ();
                AdvertiseSwitch = null;
            }

            if (BrowseSwitch != null) {
                BrowseSwitch.Dispose ();
                BrowseSwitch = null;
            }
        }
    }
}