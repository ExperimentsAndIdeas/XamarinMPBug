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
    [Register ("NearbyDevicesViewController")]
    partial class NearbyDevicesViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView DevicesTable { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DevicesTable != null) {
                DevicesTable.Dispose ();
                DevicesTable = null;
            }
        }
    }
}