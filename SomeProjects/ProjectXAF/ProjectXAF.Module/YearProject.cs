using System;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace ProjectXAF.Module
{
    [DefaultClassOptions]
    public class YearProject : BaseObject
    {
        public YearProject()
            : base(Session.DefaultSession)
        {
        }

        public YearProject(Session session)
            : base(session)
        {
        }

        public int Year
        {
            get { return GetPropertyValue<int>("Year"); }
            set { SetPropertyValue("Year", value); }
        }

        [Association("Project-YearProjects", typeof(Project))]
        public Project Project
        {
            get { return GetPropertyValue<Project>("Project"); }
            set { SetPropertyValue("Project", value); }
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
    }
}