using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbk.mailrelay.Model
{
    public class Statistics
    {
        public string apiKey { get; set; }
        public int id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<string> smtpTags { get; set; }
    }

    public class StatisticsSpam
    {
        public string apiKey { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string sortField { get; set; }
        public string sortOrder { get; set; }
    }

    public class ResultStatistics
    {
        public int impressions { get; set; }
        public int unique_impressions { get; set; }
        public int clicks { get; set; }
        public int unique_clicks { get; set; }
        public int sent { get; set; }
        public int bounced { get; set; }
        public int reported_spam { get; set; }
        public int delivered { get; set; }
        public int optouts { get; set; }
        public int forwarded { get; set; }

    }

    public  class ResultsUniqueClicks
    {
        public DateTime date { get; set; }
        public int mailing_list { get; set; }
        public string email { get; set; }
        public string url { get; set; }
        public int link_no { get; set; } 
        public string browser { get; set; }
        public string os { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string screen_width { get; set; }
        public string screen_height { get; set; }
        public string location { get; set; }
        public string country { get; set; }
    }

    public class ResultImpressionsInfo
    {
        public int mailing_list { get; set; }
        public DateTime date { get; set; }
        public string email { get; set; }
        public string browser { get; set; }
        public string os { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public string location { get; set; }
        public string country { get; set; }

    }
}
