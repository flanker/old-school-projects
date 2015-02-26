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
    [Custom("Caption","仪器工具入库")]
    public class Tool : BaseObject
    {
        public Tool(Session session) : base(session) { }


        [Custom("Caption", "仪器工具类型")]
        public ToolType ToolType 
        {
            get { return GetPropertyValue<ToolType>("ToolType"); }
            set { SetPropertyValue("ToolType", value); }         
        }


       
        [Custom("Caption", "数量")]
        public int Number
        {
            get { return GetPropertyValue<int>("Number"); }
            set { SetPropertyValue("Number", value); }
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
