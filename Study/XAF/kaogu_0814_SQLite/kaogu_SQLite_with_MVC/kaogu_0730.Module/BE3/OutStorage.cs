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
    [Custom("Caption", "����Ǽ�")]
    public class OutStorage : BaseObject
    {

        public OutStorage(Session session) : base(session) { }

        [Custom("Caption", "������ʽ")]
        public WorkTypeStoreage WorkType
        {
            get { return GetPropertyValue<WorkTypeStoreage>("WorkType"); }
            set { SetPropertyValue("WorkType", value); }
        }

        [Custom("Caption", "��������")]
        public RemainType RemainType
        {
            get { return GetPropertyValue<RemainType>("RemainType"); }
            set { SetPropertyValue("RemainType", value); }
        }

        [Custom("Caption", "������")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "��������")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "����ʱ�䣨��ȷ���֣�")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "������")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("Caption", "����ԭ��")]
        public string Reason
        {
            get { return GetPropertyValue<string>("Reason"); }
            set { SetPropertyValue("Reason", value); }
        }
        

        [Custom("Caption", "�˶���")]
        public Worker CheckOutBy
        {
            get { return GetPropertyValue<Worker>("CheckOutBy"); }
            set { SetPropertyValue("CheckOutBy", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "�黹ʱ�䣨��ȷ���֣�")]
        public DateTime ReturnOn
        {
            get { return GetPropertyValue<DateTime>("ReturnOn"); }
            set { SetPropertyValue("ReturnOn", value); }
        }

        [Custom("Caption", "�黹�˶���")]
        public Worker CheckInBy
        {
            get { return GetPropertyValue<Worker>("CheckInBy"); }
            set { SetPropertyValue("CheckInBy", value); }
        }
    }

}
