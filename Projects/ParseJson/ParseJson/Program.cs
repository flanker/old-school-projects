using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net;

namespace ParseJson
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamReader sr = File.OpenText("data.json");

            //string json = sr.ReadToEnd();
           

            Uri uri = new Uri("http://twitter.com/statuses/user_timeline/flankerfc.json");
            WebClient wc = new WebClient();
            string json = wc.DownloadString(uri);

            JArray a1 = JArray.Parse(json);

            Console.WriteLine(a1[0]["in_reply_to_status_id_str"].ToString());

            Console.ReadKey();
        }
    }
}
