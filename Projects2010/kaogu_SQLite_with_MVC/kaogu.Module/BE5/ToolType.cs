using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace kaogu.Module
{
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Type")]
    [Custom("Caption", "仪器工具类型")]
    public class ToolType : BaseObject
    {
        public ToolType(Session session) : base(session) { }

        [Custom("Caption", "名称")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "型号")]
        public string Style
        {
            get { return GetPropertyValue<string>("Style"); }
            set { SetPropertyValue("Style", value); }
        }

        [Custom("Caption", "单位")]
        public string Unit
        {
            get { return GetPropertyValue<string>("Unit"); }
            set { SetPropertyValue("Unit", value); }
        } 

        [Custom("Caption", "仪器工具类型")]
        public string Type
        {
            get { return GetPropertyValue<string>("Name") + "; " + GetPropertyValue<string>("Style") + "; " +GetPropertyValue<string>("Unit"); }
        }

        [Custom("Caption", "用途")]
        public string Use
        {
            get { return GetPropertyValue<string>("Use"); }
            set { SetPropertyValue("Use", value); }
        }
    }

}
