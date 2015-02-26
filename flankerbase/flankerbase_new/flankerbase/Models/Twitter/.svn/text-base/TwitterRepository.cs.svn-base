using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json.Linq;

namespace flankerbase.Models
{
    public class TwitterRepository
    {
        public List<TwitterDTO> GetAll()
        {
            Uri uri = new Uri("http://twitter.com/statuses/user_timeline/flankerfc.json");
            WebClient wc = new WebClient();
            string json = wc.DownloadString(uri);

            JArray a1 = JArray.Parse(json);

            List<TwitterDTO> results = new List<TwitterDTO>();

            foreach (JObject t in a1)
            {
                TwitterDTO dto = new TwitterDTO();

                dto.ID = long.Parse(t["id"].ToString());
                dto.UserScreenName = (t["user"]["screen_name"] as JValue).Value.ToString();
                dto.UserName = (t["user"]["name"] as JValue).Value.ToString();
                dto.CreatedAt = (t["created_at"] as JValue).Value.ToString();
                dto.Source = (t["source"] as JValue).Value.ToString();
                dto.Text = (t["text"] as JValue).Value.ToString();

                results.Add(dto);
            }

            return results;
        }
    }
}
