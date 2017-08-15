using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbk.mailrelay.Model
{
    public class Group
    {
        public string apiKey { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int position { get; set; }
        public int id { get; set; }
        public bool enable { get; set; }
        public bool visible { get; set; }
    }
}
