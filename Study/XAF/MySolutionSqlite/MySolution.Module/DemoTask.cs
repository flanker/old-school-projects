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
    [Custom("Caption", "Task")]
    public class DemoTask : Task
    {
        public DemoTask(Session session)
            : base(session)
        {
        }

        [Association("Contact-DemoTask", typeof(Contact))]
        public XPCollection Contacts
        {
            get { return GetCollection("Contacts"); }
        }

        public override string ToString()
        {
            return this.Subject;
        }

        private Priority priority;
        public Priority Priority
        {
            get { return priority; }
            set
            {
                SetPropertyValue("Priority", ref priority,
                value);
            }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Priority = Priority.Normal;
        }

        [Action(ToolTip = "Postpone the task to the next day")]
        public void Postpone()
        {
            if (DueDate == DateTime.MinValue)
            {
                DueDate = DateTime.Now;
            }
            DueDate = DueDate + TimeSpan.FromDays(1);
        }
    }

    public enum Priority { Low, Normal, High }

}
