using System;
using System.Collections.Generic;
using MultipeerConnectivity;

namespace AELPMP
{
    public static class MyPhoneStatus
    {
        static MyPhoneStatus()
        {
            ConnectedPeers = new List<MCPeerID>();
        }
        public static bool IsBrowsing { get; set; }
        public static bool IsAdvertising { get; set; }
        public static int MyPeerIDHash { get; set; }
        public static string MyPeerID { get; set; }
        public static List<MCPeerID> ConnectedPeers { get; set; }

        public static DateTime LastInvitation { get; set; }
    }
}