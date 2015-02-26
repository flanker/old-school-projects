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
    public class WorldDynasty : BaseObject
    {
        public WorldDynasty(Session session) : base(session) { }

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

        private WorldCulture _BelongCulture;
        public WorldCulture BelongCulture
        {
            get
            {
                return _BelongCulture;
            }
            set
            {
                SetPropertyValue("BelongCulture", ref _BelongCulture, value);
            }
        }

        private string _StartAt;
        public string StartAt
        {
            get
            {
                return _StartAt;
            }
            set
            {
                SetPropertyValue("StartAt", ref _StartAt, value);
            }
        }

        private string _EndAt;
        public string EndAt
        {
            get
            {
                return _EndAt;
            }
            set
            {
                SetPropertyValue("EndAt", ref _EndAt, value);
            }
        }




    }

}
