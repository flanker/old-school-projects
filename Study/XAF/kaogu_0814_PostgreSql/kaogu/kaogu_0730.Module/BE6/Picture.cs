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
    [Custom("Caption", "绘图登记")]
    public class Picture : BaseObject
    {
        public Picture(Session session) : base(session) { }

        [Custom("Caption", "名称")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "类别")]
        public PictureObjectType Type
        {
            get { return GetPropertyValue<PictureObjectType>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "绘图号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "比例")]
        public string Scale
        {
            get { return GetPropertyValue<string>("Scale"); }
            set { SetPropertyValue("Scale", value); }
        }


        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "审核日期（精确到分）")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "绘图方式")]
        public PictureMethod PictureMethod
        {
            get { return GetPropertyValue<PictureMethod>("PictureMethod"); }
            set { SetPropertyValue("PictureMethod", value); }
        }

        [Custom("Caption", "绘图人")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }


        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "审核日期（精确到分）")]
        public DateTime CheckOn
        {
            get { return GetPropertyValue<DateTime>("CheckOn"); }
            set { SetPropertyValue("CheckOn", value); }
        }

        [Custom("Caption", "审核人")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }


    }

    public enum PictureObjectType { 未知, 遗迹, 遗物 }

    public enum PictureMethod { 未知, 剖面, 剖视图, 特写 } 
}
