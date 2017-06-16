using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rbk.mailrelay.Model
{
    public class Mailing
    {
        public int id { get; set; }
        public string subject { get; set; }
        public string mailbox_from_id { get; set; }
        public string mailbox_reply_id { get; set; }
        public string mailbox_report_id { get; set; }
        public string groups { get; set; }
        public string text { get; set; }
        public string html { get; set; }
        public string attachs { get; set; }
        public DateTime date { get; set; }
        public DateTime created { get; set; }
        public DateTime last_sent { get; set; }
        public string deleted { get; set; }
        public DateTime start_sent { get; set; }
        public DateTime send_date { get; set; }
        public int subscribers_total { get; set; }
        public int package_id { get; set; }
        public int id_mailing_list_folder { get; set; }
        public int admin_id { get; set; }
        public string is_spam { get; set; }
        public string spam_report { get; set; }
        public string analytics_utm_campaign { get; set; }
        public string auth_token { get; set; }
        public string notification_url { get; set; }
        public int campaign_id { get; set; }
        public int sent { get; set; }
        public int bounced { get; set; }


    }
}
