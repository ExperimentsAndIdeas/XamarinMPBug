using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;

namespace AELPMP
{
    public class AvailablePeersDataSource : UITableViewSource
    {
        List<PeerMonitorStatus> CachedPeerStatus = new List<PeerMonitorStatus>();

        public AvailablePeersDataSource()
        {
            CachedPeerStatus.AddRange(AppDelegate.PeerHistoryMonitor.Values);
        }

        public override nint RowsInSection(UITableView tableview, nint section)
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
