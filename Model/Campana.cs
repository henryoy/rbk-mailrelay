using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rbk.mailrelay.Model
{
    public class Campana
    {
        public Campana()
        {
            groups = new List<int>();
        }
        public string subject { get; set; }
        public int mailboxFromId { get; set; }
        public int mailboxReplyId { get; set; }
        public int mailboxReportId { get; set; }
        public bool emailReport { get; set; }
        public List<int> groups { get; set; }
        public string text { get; set; }
        public string html { get; set; }
        public int packageId { get; set; }
        public int campaignFolderId { get; set; }
    }
}
