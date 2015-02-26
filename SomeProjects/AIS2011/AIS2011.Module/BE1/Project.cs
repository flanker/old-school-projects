using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace kaogu_0730.Module
{
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Name")]
    [Custom("Caption", "��Ŀ��Ϣ")]
    public class Project : BaseObject
    {

        private string name;
        private string identify;
        private DateTime start;
        private DateTime end;
        private string note;

        public Project(Session session) : base(session) { }

        public Project() : base(Session.DefaultSession)
        {
        }

        [Custom("Caption", "��Ŀ����")]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }
        [Custom("Caption", "��Ŀ���")]
        public string Identify
        {
            get { return identify; }
            set { SetPropertyValue("Identify", ref identify, value); }
        }
        [Custom("Caption", "��Ŀ��ʼʱ��")]
        public DateTime Start
        {
            get { return start; }
            set { SetPropertyValue("Start", ref start, value); }
        }
        [Custom("Caption", "��Ŀ����ʱ��")]
        public DateTime End
        {
            get { return end; }
            set { SetPropertyValue("End", ref end, value); }
        }


        [Custom("Caption", "��Ŀ�ſ�")]
        [Size(3000)]
        public string Note
        {
            get { return note; }
            set { SetPropertyValue("Note", ref note, value); }
        }

        [Association("Project-PAddress", typeof(PAddress))]
        [Custom("Caption", "��Ŀ��ַ")]
        public XPCollection PAddress
        {
            get { return GetCollection("PAddress"); }
        }
        [Association("Project-PDepartment", typeof(PDepartment))]
        [Custom("Caption", "���뵥λ")]
        public XPCollection PDepartment
        {
            get { return GetCollection("PDepartment"); }
        }

        [Association("Project-Worker", typeof(Worker))]
        [Custom("Caption", "������Ա")]
        public XPCollection Worker
        {
            get { return GetCollection("Worker"); }
        }


    }

    [DefaultClassOptions]
    [Custom("Caption", "��Ŀ��ַ")]
    public class PAddress : Address
    {
        public PAddress(Session session) : base(session) { }


       
        [Association("Project-PAddress", typeof(Project))]
        [Custom("Caption", "��Ŀ����")]
        public XPCollection Project
        {
            get { return GetCollection("Project"); }
        }


    }


    [DefaultClassOptions]
    [Custom("Caption", "��Ŀ��λ")]
    [System.ComponentModel.DefaultProperty("Name")]

    public class PDepartment : BaseObject
    {
        public PDepartment(Session session) : base(session) { }


        private string name;
        [Custom("Caption", "��λ����")]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }

     
        [Association("Project-PDepartment", typeof(Project))]
        [Custom("Caption", "��Ŀ����")]
        public XPCollection Project
        {
            get { return GetCollection("Project"); }
        }


    }

}
