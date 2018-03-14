using Foundation;
using MultipeerConnectivity;
using System;
using UIKit;
 
namespace AELPMP
{
    public class ChatSessionDelegate : MCSessionDelegate
    {
        MCSession localSession = null;

        public ChatSessionDelegate(MCSession session)
        {
            localSession = session;
        }
        public override void DidChangeState(MCSession session, MCPeerID peerID, MCSessionState state)
        {
            AppDelegate.PeerHistoryMonitor[peerID.DisplayName].LastKnownState = state;
            AppDelegate.PeerHistoryMonitor[peerID.DisplayName].ConnectedPeers = session.ConnectedPeers;

            switch (state)
            {
                case MCSessionState.Connected:
                    Console.WriteLine("MCSessionDelegate Connected to " + peerID.DisplayName);
                    DataProcessor.StartConversation(session, peerID, state);
                    break;

                case MCSessionState.Connecting:
                    Console.WriteLine("MCSessionDelegate Connecting to " + peerID.DisplayName);
                    break;
                case MCSessionState.NotConnected:
                    Console.WriteLine("MCSessionDelegate No longer connected to " + peerID.DisplayName);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override void DidReceiveData(MCSession session, Foundation.NSData data, MCPeerID peerID)
        {
            System.Diagnostics.Debug.WriteLine("MCSessionDelegate ** DidReceiveData");
            AppDelegate.PeerHistoryMonitor[peerID.DisplayName].LastReceiveData = DateTime.UtcNow;

            DataProcessor.ProcessCommand(session, data, peerID);
        }

        public override void DidStartReceivingResource(MCSession session, string resourceName, MCPeerID peerID, Foundation.NSProgress progress)
        {
            AppDelegate.PeerHistoryMonitor[peerID.DisplayName].LastReceiveResource = DateTime.UtcNow;

            System.Diagnostics.Debug.WriteLine("MCSessionDelegate ** DidStartReceivingResource");
            InvokeOnMainThread(() => new UIAlertView("Msg", "DidStartReceivingResource()", null, "OK", null).Show());
        }

        public override void DidFinishReceivingResource(MCSession session, string resourceName, MCPeerID peerID, NSUrl localUrl, NSError error)
        {
            AppDelegate.PeerHistoryMonitor[peerID.DisplayName].LastReceiveResource = DateTime.UtcNow;

            System.Diagnostics.Debug.WriteLine("MCSessionDelegate ** DidFinishReceivingResource");

            InvokeOnMainThread(() => new UIAlertView("Msg", "DidFinishReceivingResource()", null, "OK", null).Show());
            error = null;
        }

        public override void DidReceiveStream(MCSession session, Foundation.NSInputStream stream, string streamName, MCPeerID peerID)
        {
            AppDelegate.PeerHistoryMonitor[peerID.DisplayName].LastReceiveStream = DateTime.UtcNow;

            System.Diagnostics.Debug.WriteLine("MCSessionDelegate ** DidReceiveStream");
            InvokeOnMainThread(() => new UIAlertView("Msg", "DidReceiveStream()", null, "OK", null).Show());
        }
    }
}