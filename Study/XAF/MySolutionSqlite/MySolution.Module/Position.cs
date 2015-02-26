using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MySolution.Module
{
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Title")]
    [ImageName("BO_Position")]
    public class Position : BaseObject
    {
        public Position(Session session)
            : base(session)
        {
        }

        private string title;

        [RuleRequiredField("RuleRequiredField for Position.Title", DefaultContexts.Save)]
        public string Title
        {
            get { return title; }
            set { SetPropertyValue("Title", ref title, value); }
        }

        [Association("Departments-Positions", typeof(Department))]
        public XPCollection Departments
        {
            get { return GetCollection("Departments"); }
        }

    }

}
