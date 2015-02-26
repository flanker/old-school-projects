using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace EarthquakeService
{
    [DataContract(Namespace = "http://timecomet/service", Name = "Event")]
    public class Event
    {
        #region private field

        private string m_Start;
        private string m_End;
        private string m_Title;
        private string m_Lat;
        private string m_Lng;
        private string m_Info;
        private string m_Id;

        #endregion

        #region property

        [DataMember(Order = 3)]
        public string Start
        {
            get { return m_Start; }
            set { m_Start = value; }
        }

        [DataMember(Order = 4)]
        public string End
        {
            get { return m_End; }
            set { m_End = value; }
        }

        [DataMember(Order = 1)]
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        [DataMember(Order = 5)]
        public string Lat
        {
            get { return m_Lat; }
            set { m_Lat = value; }
        }

        [DataMember(Order = 6)]
        public string Lng
        {
            get { return m_Lng; }
            set { m_Lng = value; }
        }

        [DataMember(Order = 2)]
        public string Info
        {
            get { return m_Info; }
            set { m_Info = value; }
        }

        [DataMember(Order = 0)]
        public string Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        #endregion
    }
}
