using System;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace ProjectXAF.Module
{
    [DefaultClassOptions]
    public class Project : BaseObject
    {
        public Project(Session session) : base(session) { }

        public Project() : base(Session.DefaultSession)
        {
        }

        public string Code
        {
            get { return GetPropertyValue<string>("Code"); }
            set { SetPropertyValue("Code", value); }
        }

        public string Title
        {
            get { return GetPropertyValue<string>("Title"); }
            set { SetPropertyValue("Title", value); }
        }

        [Size(XpoConst.ShortTextLength)]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }

        public DateTime StartDate
        {
            get { return GetPropertyValue<DateTime>("StartDate"); }
            set { SetPropertyValue("StartDate", value); }
        }

        public DateTime EndDate
        {
            get { return GetPropertyValue<DateTime>("EndDate"); }
            set { SetPropertyValue("EndDate", value); }
        }

        [Size(0)]
        public string Detail
        {
            get { return GetPropertyValue<string>("Detail"); }
            set { SetPropertyValue("Detail", value); }
        }

        [Association("Project-YearProjects")]
        public XPCollection<YearProject> YearProjects
        {
            get { return GetCollection<YearProject>("YearProjects"); }
        }
    }
}
