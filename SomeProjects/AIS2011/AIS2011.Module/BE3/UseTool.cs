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
    [Custom("Caption", "仪器工具使用")]
    public class UseTool : BaseObject
    {
        public UseTool(Session session) : base(session) { }

        

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

        [Custom("Caption", "使用者")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "借出日期（精确到分）")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "经手人")]
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

        [Custom("Caption", "归还经手人")]
        public Worker CheckInBy
        {
            get { return GetPropertyValue<Worker>("CheckInBy"); }
            set { SetPropertyValue("CheckInBy", value); }
        }

        [Custom("Caption", "备注")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

    }

}
