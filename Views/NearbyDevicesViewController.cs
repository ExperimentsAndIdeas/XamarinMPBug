using CoreGraphics;
using Foundation;
using MultipeerConnectivity;
using System;
using UIKit;
using System.Collections.Generic;

namespace AELPMP 
{
    public partial class NearbyDevicesViewController : UITableViewController
    {
        public string myPhoneName { get; set; }
        public  MCPeerID myPeerID { get; set; }
        public const string SERVICE_STRING = "AELP";
        public MCSession Session { get; set; }

        List<PeerMonitorStatus> CachedPeerStatus = new List<PeerMonitorStatus>();

        public NearbyDevicesViewController (IntPtr handle) : base (handle)
        {
            myPhoneName = "A" + UIKit.UIDevice.CurrentDevice.Name;
            MyPhoneStatus.MyPeerID =  myPhoneName;
            myPeerID = new MCPeerID(myPhoneName);

            Session = new MCSession(myPeerID);
            Session.Delegate = new ChatSessionDelegate(Session);
            //--------------------------------Advertiser----------------------------------------------------
            var emptyDict = new NSDictionary();
            AppDelegate.advertiser = new MCNearbyServiceAdvertiser(myPeerID, emptyDict, SERVICE_STRING);
            AppDelegate.advertiser.Delegate = new MyNearbyAdvertiserDelegate(this);

            System.Diagnostics.Debug.WriteLine("Starting advertising...");
            AppDelegate.advertiser.StartAdvertisingPeer();
            MyPhoneStatus.IsAdvertising = true;

            ////--------------------------------Browser------------------------------------------------------
            //AppDelegate.browser = new MCNearbyServiceBrowser(myPeerID, SERVICE_STRING);
            //AppDelegate.browser.Delegate = new MyBrowserDelegate(myPeerID, Session);

            //System.Diagnostics.Debug.WriteLine("Starting browsing...");
            //AppDelegate.browser.StartBrowsingForPeers();
            //MyPhoneStatus.IsBrowsing = true;

            CachedPeerStatus.AddRange(AppDelegate.PeerHistoryMonitor.Values);
        }

		public override nint RowsInSection(UITableView tableView, nint section)
		{
            return CachedPeerStatus.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
            UITableViewCell cell = new UITableViewCell(CGRect.Empty);
            var item = CachedPeerStatus[indexPath.Row];

            cell.TextLabel.Text = item.DisplayText;
            return cell;
		}
	}
}