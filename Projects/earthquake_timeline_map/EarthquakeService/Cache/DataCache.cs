using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.ServiceModel.Syndication;

namespace EarthquakeService
{
    public class DataCache
    {
        private string m_XmlUri;

        private Event[] m_Events;

        public string XmlUri
        {
            get { return m_XmlUri; }
            set { m_XmlUri = value; }
        }

        public Event[] Events
        {
            get { return m_Events; }
            set { m_Events = value; }
        }

        public DataCache(string XmlUri)
        {
            this.XmlUri = XmlUri;
        }

        public void LoadXml(string xmlUri)
        {
            XmlReader feedReader = XmlReader.Create(this.XmlUri);

            SyndicationFeed feed = SyndicationFeed.Load(feedReader);

            List<Event> list = new List<Event>();

            SyndicationItem[] items = feed.Items.ToArray<SyndicationItem>();

            for (int i = 0; i < items.Length; i++)
            {
                Event e = new Event();

                e.Id = i.ToString();

                string title = items[i].Title.Text;
                string[] titles = title.Split(',');

                e.Info = title;
                e.Title = titles[0];

                DateTime dt = items[i].LastUpdatedTime.UtcDateTime;
                e.Start = e.End = Help.ConvertDateTime(dt);

                string point = items[i].ElementExtensions.ReadElementExtensions<string>("point", "http://www.georss.org/georss")[0];

                string[] points = point.Split(' ');

                e.Lat = points[0];
                e.Lng = points[1];

                list.Add(e);
            }

            this.Events = list.ToArray();
        }

        public void LoadXml()
        {
            this.LoadXml(XmlUri);
        }
    }
}
