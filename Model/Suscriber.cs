using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rbk.mailrelay.Model
{
    public class Suscriber
    {
        public Suscriber()
        {
            groups = new List<int>();
        }

        public string apiKey { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public List<int> groups { get; set; }
        public List<string> subscribers { get; set; }
    }
}
