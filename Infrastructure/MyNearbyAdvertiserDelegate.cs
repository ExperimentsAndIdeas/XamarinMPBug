using System;
using Foundation;
using MultipeerConnectivity;

namespace AELPMP
{ 

    public  class MyNearbyAdvertiserDelegate : MCNearbyServiceAdvertiserDelegate
    {
        MCSession session;

        public MyNearbyAdvertiserDelegate(NearbyDevicesViewController session)
        {
            this.session = session.Session;
        }

        public override void DidReceiveInvitationFromPeer(MCNearbyServiceAdvertiser advertiser, MCPeerID peerID, NSData context, MCNearbyServiceAdvertiserInvitationHandler invitationHandler)
        {
            System.Diagnostics.Debug.WriteLine("Advertiser [" + session.MyPeerID.GetNativeHash() + "] will accept invite from " + peerID.DisplayName + " [" + peerID.GetNativeHash() + "]");

            MyPhoneStatus.LastInvitation = DateTime.UtcNow;

            MyPhoneStatus.ConnectedPeers.Clear();
            MyPhoneStatus.ConnectedPeers.AddRange(session.ConnectedPeers);

            invitationHandler(true, session); 
        }
    }
}