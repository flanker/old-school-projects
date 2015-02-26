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
    [Custom("Caption", "数码照片登记")]
    public class DPhoto : BaseObject
    {
        public DPhoto(Session session) : base(session) { }

        [Custom("Caption", "相机型号")]
        public CameraType CameraType
        {
            get { return GetPropertyValue<CameraType>("CameraType"); }
            set { SetPropertyValue("CameraType", value); }
        }
        
        
        [Custom("Caption", "照片编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "拍摄对象")]
        public string Object
        {
            get { return GetPropertyValue<string>("Object"); }
            set { SetPropertyValue("Object", value); }
        }

        [Custom("Caption", "描述")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }

        [Custom("Caption", "从")]
        public string DirectionFrom
        {
            get { return GetPropertyValue<string>("DirectionFrom"); }
            set { SetPropertyValue("DirectionFrom", value); }
        }

        [Custom("Caption", "到")]
        public string DirectionTo
        {
            get { return GetPropertyValue<string>("DirectionTo"); }
            set { SetPropertyValue("DirectionTo", value); }
        }

        [Custom("Caption", "拍摄方向")]
        public string Direction
        {
            get { return GetPropertyValue<string>("DirectionFrom") + "→" + GetPropertyValue<string>("DirectionTo"); }

        }  

        [Custom("Caption", "天气")]
        public string Weather
        {
            get { return GetPropertyValue<string>("Weather"); }
            set { SetPropertyValue("Weather", value); }
        } 

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "记录时间（精确至分）")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "拍摄者")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        } 

    }

    public enum CameraType {未知, CANONEOS5DMARKII,SONYA230}

}
