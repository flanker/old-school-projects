using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EarthquakeService
{
    public class DataCacheManager
    {

        private Dictionary<string, DataCache> m_CacheList;

        public Dictionary<string, DataCache> CacheList
        {
            get { return m_CacheList; }
            set { m_CacheList = value; }
        }

        private static DataCacheManager m_Instance = new DataCacheManager();

        //public List<DataCache> CacheList
        //{
        //    get { return m_CacheList; }
        //    set { m_CacheList = value; }
        //}

        private DataCacheManager()
        {
            CacheList = new Dictionary<string, DataCache>();
        }

        public static DataCacheManager Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public void Add(string Key, DataCache DataCache)
        {
            CacheList.Add(Key, DataCache);
        }

        public void Add(string Key, string XmlUri)
        {
            CacheList.Add(Key, new DataCache(XmlUri));
        }

        public void Refresh()
        {
            foreach (KeyValuePair<string, DataCache> keyValue in CacheList)
            {
                keyValue.Value.LoadXml();
            }
        }

        public Event[] GetEvents(string Key)
        {
            return CacheList[Key].Events;
        }
    }
}
