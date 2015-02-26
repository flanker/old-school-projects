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
    [Custom("Caption","编号改动")]
    public class MarkChange : BaseObject
    {

        public MarkChange(Session session) : base(session) { }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "记录时间（精确至分）")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }


        [Custom("Caption", "遗迹/遗物")]
        public WorkType MarkType
        {
            get { return GetPropertyValue<WorkType>("MarkType"); }
            set { SetPropertyValue("MarkType", value); }
        }

        [Custom("Caption", "类别")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }



        [Custom("Caption", "原编号")]
        public string OldId
        {
            get { return GetPropertyValue<string>("OldId"); }
            set { SetPropertyValue("OldId", value); }
        }

        [Custom("Caption", "新编号")]
        public string NewId
        {
            get { return GetPropertyValue<string>("NewId"); }
            set { SetPropertyValue("NewId", value); }
        }

        [Custom("Caption", "更改原因")]
        public string Reason
        {
            get { return GetPropertyValue<string>("Reason"); }
            set { SetPropertyValue("Reason", value); }
        }

        [Custom("Caption", "申请人")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("Caption", "审核人")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }
    }

    public enum WorkType { 未知, 遗迹, 遗物 }

}
