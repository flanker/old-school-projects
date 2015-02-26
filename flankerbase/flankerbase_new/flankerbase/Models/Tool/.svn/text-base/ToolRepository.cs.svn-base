using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json.Linq;

namespace flankerbase.Models
{
    public class ToolRepository
    {
        // Google Spreadsheets Key
        private string spreadsheetsKey = "0ApprjhYB-ZEVdDQ3TDI0ZTF2WWo5bGg5akRqeW5wRXc";
        private string worksheetID = "od6";

        public List<ToolDTO> GetAll()
        {
            Uri uri = new Uri("http://spreadsheets.google.com/feeds/list/" + spreadsheetsKey + "/" + worksheetID + "/public/values?v=3.0&alt=json");
            WebClient wc = new WebClient();
            wc.Encoding = System.Text.Encoding.UTF8;
            string rawResult = wc.DownloadString(uri);

            JObject json = JObject.Parse(rawResult);

            JArray entryList = json["feed"]["entry"] as JArray;

            List<ToolDTO> results = new List<ToolDTO>();

            foreach (JObject t in entryList)
            {
                ToolDTO dto = new ToolDTO();

                dto.ID = int.Parse((t["gsx$id"]["$t"] as JValue).Value.ToString());
                dto.Category = (t["gsx$category"]["$t"] as JValue).Value.ToString();
                dto.Type = (t["gsx$type"]["$t"] as JValue).Value.ToString();
                dto.Name = (t["gsx$name"]["$t"] as JValue).Value.ToString();
                dto.Description = (t["gsx$description"]["$t"] as JValue).Value.ToString();

                results.Add(dto);
            }

            return results;
        }

        public string GetTestString()
        {
            string result = String.Empty;

            Uri uri = new Uri("http://spreadsheets.google.com/feeds/list/" + spreadsheetsKey + "/" + worksheetID + "/public/values?v=3.0&alt=json");
            WebClient wc = new WebClient();
            string rawResult = wc.DownloadString(uri);

            JObject json = JObject.Parse(rawResult);

            JArray entryList = json["feed"]["entry"] as JArray;

            foreach (JObject t in entryList)
            {
                ToolDTO dto = new ToolDTO();

                result = (t["gsx$id"]["$t"] as JValue).Value.ToString();
                break;
            }

            return result;
        }
    }
}
