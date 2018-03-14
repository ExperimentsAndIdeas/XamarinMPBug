using System;
using System.Collections.Generic;
using Foundation;
using MultipeerConnectivity;

namespace AELPMP
{
    public class MyBrowserDelegate : MCNearbyServiceBrowserDelegate
    {
        NSData context;
        MCPeerID browserPeerID;
        MCSession session;

        public MyBrowserDelegate( MCPeerID myPeerID, MCSession sharedSession)
        {
            context = new NSData();
            this.browserPeerID = myPeerID;
            this.session = sharedSession;
        }

        public override void FoundPeer(MCNearbyServiceBrowser browser, MCPeerID peerID, NSDictionary info)
        {
            System.Console.WriteLine("MCNearbyServiceBrowserDelegate Found peer " + peerID.DisplayName);

            // Initialize dual purpose object status and cache object for PeerID
            if (!AppDelegate. PeerHistoryMonitor.ContainsKey(peerID.DisplayName))
                AppDelegate. PeerHistoryMonitor.Add(peerID.DisplayName, new PeerMonitorStatus()
                {
                    LastActive = DateTime.UtcNow,
                    PeerID = peerID
                });

            // Connect to server if the hash value is greater
            if (browser.MyPeerID.GetNativeHash() > peerID.GetNativeHash())
            {
                System.Console.WriteLine("browser ID" + browser.MyPeerID.GetNativeHash());
                System.Console.WriteLine("PeerID " + peerID.GetNativeHash());
                browser.InvitePeer(peerID, session, context, 60);
            }
        }

        public override void LostPeer(MCNearbyServiceBrowser browser, MCPeerID peerID)
        {
            System.Console.WriteLine("MCNearbyServiceBrowserDelegate LOST peer " + peerID.DisplayName);

            // Safe to skip null check in dictionary b/c FoundPeer runs first
            //AppDelegate. PeerHistoryMonitor[peerID.DisplayName].LastError = DateTime.UtcNow;
            //AppDelegate. PeerHistoryMonitor[peerID.DisplayName].LastErrorString = "Lost peer";
        }

        public override void DidNotStartBrowsingForPeers(MCNearbyServiceBrowser browser, NSError error)
        {
            System.Console.WriteLine("MCNearbyServiceBrowserDelegate ERROR peer ");

            //TODO: Error dialog 
            //parent.Status("DidNotStartBrowingForPeers " + error.Description);
        }

    }
}