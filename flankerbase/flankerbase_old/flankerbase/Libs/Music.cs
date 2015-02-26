using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace flankerbase.Models
{
    public class track
    {
        public string annotation { get; set; }
        public string location { get; set; }
        public string info { get; set; }
        public string image { get; set; }
    }

    public class playlist
    {
        public string title { get; set; }
        public string info { get; set; }
        public List<track> trackList { get; set; }
    }
}
