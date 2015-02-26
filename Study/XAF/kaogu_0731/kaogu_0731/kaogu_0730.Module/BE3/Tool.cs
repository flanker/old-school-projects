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
    [Custom("Caption","仪器工具")]
    public class Tool : BaseObject
    {
        public Tool(Session session) : base(session) { }

        [Custom("Caption", "编号（数字）")]
        public int Id
        {
            get { return GetPropertyValue<int>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "名称")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "用途")]
        public string Use
        {
            get { return GetPropertyValue<string>("Use"); }
            set { SetPropertyValue("Use", value); }
        }

        [Custom("Caption", "型号")]
        public string Style
        {
            get { return GetPropertyValue<string>("Style"); }
            set { SetPropertyValue("Style", value); }
        }

        [Custom("Caption", "数量")]
        public int Number
        {
            get { return GetPropertyValue<int>("Number"); }
            set { SetPropertyValue("Number", value); }
        }

        [Custom("Caption", "单位")]
        public string Unit
        {
            get { return GetPropertyValue<string>("Unit"); }
            set { SetPropertyValue("Unit", value); }
        }

        [Custom("Caption", "购置日期")]
        public DateTime BuyOn
        {
            get { return GetPropertyValue<DateTime>("BuyOn"); }
            set { SetPropertyValue("BuyOn", value); }
        }

        [Custom("Caption", "存放位置")]
        public string Storage
        {
            get { return GetPropertyValue<string>("Storage"); }
            set { SetPropertyValue("Storage", value); }
        }

        [Custom("Caption", "管理人")]
        public Worker Manager
        {
            get { return GetPropertyValue<Worker>("Manager"); }
            set { SetPropertyValue("Manager", value); }
        }

    }

}
