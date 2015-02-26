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
    [Custom("Caption","��������")]
    public class Tool : BaseObject
    {
        public Tool(Session session) : base(session) { }

        [Custom("Caption", "��ţ����֣�")]
        public int Id
        {
            get { return GetPropertyValue<int>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "����")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "��;")]
        public string Use
        {
            get { return GetPropertyValue<string>("Use"); }
            set { SetPropertyValue("Use", value); }
        }

        [Custom("Caption", "�ͺ�")]
        public string Style
        {
            get { return GetPropertyValue<string>("Style"); }
            set { SetPropertyValue("Style", value); }
        }

        [Custom("Caption", "����")]
        public int Number
        {
            get { return GetPropertyValue<int>("Number"); }
            set { SetPropertyValue("Number", value); }
        }

        [Custom("Caption", "��λ")]
        public string Unit
        {
            get { return GetPropertyValue<string>("Unit"); }
            set { SetPropertyValue("Unit", value); }
        }

        [Custom("Caption", "��������")]
        public DateTime BuyOn
        {
            get { return GetPropertyValue<DateTime>("BuyOn"); }
            set { SetPropertyValue("BuyOn", value); }
        }

        [Custom("Caption", "���λ��")]
        public string Storage
        {
            get { return GetPropertyValue<string>("Storage"); }
            set { SetPropertyValue("Storage", value); }
        }

        [Custom("Caption", "������")]
        public Worker Manager
        {
            get { return GetPropertyValue<Worker>("Manager"); }
            set { SetPropertyValue("Manager", value); }
        }

    }

}
