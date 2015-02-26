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
    [System.ComponentModel.DefaultProperty("TypeAndCode")]
    [Custom("Caption", "“≈º£Àı–¥")]
    public class FeatureCode : BaseObject
    {
        public FeatureCode(Session session) : base(session) { }

        [Custom("Caption", "¿‡±")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "Àı–¥")]
        public string Code
        {
            get { return GetPropertyValue<string>("Code"); }
            set { SetPropertyValue("Code", value); }
        }

        [Custom("Caption", "¿‡±_Àı–¥")]
        public string TypeAndCode
        {
            get { return GetPropertyValue<string>("Type") + GetPropertyValue<string>("Code"); }
        }
    }

}
