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
    [Custom("Caption", "出库登记")]
    public class OutStorage : BaseObject
    {

        public OutStorage(Session session) : base(session) { }

        [Custom("Caption", "工作方式")]
        public WorkTypeStoreage WorkType
        {
            get { return GetPropertyValue<WorkTypeStoreage>("WorkType"); }
            set { SetPropertyValue("WorkType", value); }
        }

        [Custom("Caption", "遗物类型")]
        public RemainType RemainType
        {
            get { return GetPropertyValue<RemainType>("RemainType"); }
            set { SetPropertyValue("RemainType", value); }
        }

        [Custom("Caption", "遗物编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "遗物名称")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "出库时间（精确到分）")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "申请人")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("Caption", "出库原因")]
        public string Reason
        {
            get { return GetPropertyValue<string>("Reason"); }
            set { SetPropertyValue("Reason", value); }
        }
        

        [Custom("Caption", "核对人")]
        public Worker CheckOutBy
        {
            get { return GetPropertyValue<Worker>("CheckOutBy"); }
            set { SetPropertyValue("CheckOutBy", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "归还时间（精确到分）")]
        public DateTime ReturnOn
        {
            get { return GetPropertyValue<DateTime>("ReturnOn"); }
            set { SetPropertyValue("ReturnOn", value); }
        }

        [Custom("Caption", "归还核对人")]
        public Worker CheckInBy
        {
            get { return GetPropertyValue<Worker>("CheckInBy"); }
            set { SetPropertyValue("CheckInBy", value); }
        }
    }

}
