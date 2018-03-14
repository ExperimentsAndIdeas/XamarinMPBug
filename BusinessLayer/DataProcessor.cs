using Foundation;
using MultipeerConnectivity;
using System;

namespace AELPMP
{
    public class DataProcessor
    {
        public static void ProcessCommand(MCSession session, Foundation.NSData data, MCPeerID peerID)
        {
            Console.WriteLine("Received command to process " + data.ToString());

            // disconnect session if needed. 
            // forward to internet if available
        }

		internal static void StartConversation(MCSession session, MCPeerID peerID, MCSessionState state)
		{
            // do you have data to send? 
            // Do I have data to send to you? 
            // IF no to both, let's check back in within X minutes. 

            NSError error = null;
            session.SendData(NSData.FromString("hi"), session.ConnectedPeers, MCSessionSendDataMode.Reliable, out error);
            if (error != null)
                AppDelegate.PeerHistoryMonitor[peerID.DisplayName].LastSendDataError = error;
		}
	}
}