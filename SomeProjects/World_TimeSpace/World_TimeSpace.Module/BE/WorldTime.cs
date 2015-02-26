using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace World_TimeSpace.Module
{
    [DefaultClassOptions]
    public class WorldTime : BaseObject
    {
        public WorldTime(Session session) : base(session) { }

        private string _Id;
        public string Id
        {
            get
            {
                return _Id;
            }
            set
            {
                SetPropertyValue("Id", ref _Id, value);
            }
        }

        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                SetPropertyValue("Name", ref _Name, value);
            }
        }

        private string _StartOn;
        public string StartOn
        {
            get
            {
                return _StartOn;
            }
            set
            {
                SetPropertyValue("StartOn", ref _StartOn, value);
            }
        }

        private string _EndOn;
        public string EndOn
        {
            get
            {
                return _EndOn;
            }
            set
            {
                SetPropertyValue("EndOn", ref _EndOn, value);
            }
        }

    }

}
