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
    [Custom("Caption", "摄像登记")]
    public class DVideo : BaseObject
    {
        public DVideo(Session session) : base(session) { }

           

        [Custom("Caption", "摄相机型号")]
        public DVideoType DVideoType
        {
            get { return GetPropertyValue<DVideoType>("DVideoType"); }
            set { SetPropertyValue("DVideoType", value); }
        }
        
        
        [Custom("Caption", "摄像号")]
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

    public enum DVideoType {未知 ,摄像机一}
    

}
