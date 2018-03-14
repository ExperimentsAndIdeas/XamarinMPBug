using System;
using Foundation;
using MultipeerConnectivity;

namespace AELPMP
{
    public class PeerMonitorStatus
    {
        public MCPeerID PeerID { get; set; }

        public string DisplayText { get; set; }

        public DateTime LastActive { get; set; }

        public DateTime LastError { get; set; }
        public string LastErrorString { get; set; }
		public MCSessionState LastKnownState { get; internal set; }
		public MCPeerID[] ConnectedPeers { get; internal set; }
		public NSError LastSendDataError { get; internal set; }
		public DateTime LastReceiveData { get; internal set; }
		public DateTime LastReceiveResource { get; internal set; }
		public DateTime LastReceiveStream { get; internal set; }
	}
}