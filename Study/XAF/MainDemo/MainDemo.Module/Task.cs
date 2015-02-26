using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MainDemo.Module
{
    public enum Priority { Low, Normal, High }

    [DefaultClassOptions]
    public class DemoTask : Task
    {
        private Priority priority;

        public DemoTask(Session session)
            : base(session)
        {
            priority = Priority.Normal;
        }
        public Priority Priority
        {
            get { return priority; }
            set { SetPropertyValue("Priority", ref priority, value); }
        }

        [Association("Contact-DemoTask")]
        public XPCollection<Contact> Contacts
        {
            get { return GetCollection<Contact>("Contacts"); }
        }
    }

}
