using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Xml;

namespace EarthquakeService
{
    class Service : IService
    {
        #region IService 成员

        public Event[] GetEvents(string Time)
        {
            SyndicationFeed feed;

            if (Time.ToLower() == "day")
            {
                //feed = SyndicationFeed.Load(DataCacheManager.Instance.GetXmlReader("day"));

                return DataCacheManager.Instance.GetEvents("day");
            }
            else
            {
               //feed = SyndicationFeed.Load(DataCacheManager.Instance.GetXmlReader("week"));
                return DataCacheManager.Instance.GetEvents("week");
            }

            //List<Event> list = new List<Event>();

            ////feed.Items.Count();

            ////foreach (SyndicationItem item in feed.Items) 
            ////{

            //SyndicationItem[] items = feed.Items.ToArray<SyndicationItem>();

            //for (int i = 0; i < items.Length; i++)
            //{
            //    Event e = new Event();

            //    e.Id = i.ToString();

            //    string title = items[i].Title.Text;
            //    string[] titles = title.Split(',');

            //    e.Info = title;
            //    e.Title = titles[0];

            //    DateTime dt = items[i].LastUpdatedTime.UtcDateTime;
            //    e.Start = e.End = Help.ConvertDateTime(dt);

            //    string point = items[i].ElementExtensions.ReadElementExtensions<string>("point", "http://www.georss.org/georss")[0];

            //    string[] points = point.Split(' ');

            //    e.Lat = points[0];
            //    e.Lng = points[1];

            //    list.Add(e);
            //}

            //return list.ToArray();
        }

        #endregion
    }
}
