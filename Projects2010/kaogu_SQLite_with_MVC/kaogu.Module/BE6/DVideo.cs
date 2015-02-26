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
    [Custom("Caption", "����Ǽ�")]
    public class DVideo : BaseObject
    {
        public DVideo(Session session) : base(session) { }

           

        [Custom("Caption", "������ͺ�")]
        public DVideoType DVideoType
        {
            get { return GetPropertyValue<DVideoType>("DVideoType"); }
            set { SetPropertyValue("DVideoType", value); }
        }
        
        
        [Custom("Caption", "�����")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "�������")]
        public string Object
        {
            get { return GetPropertyValue<string>("Object"); }
            set { SetPropertyValue("Object", value); }
        }

        [Custom("Caption", "����")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }
     

        [Custom("Caption", "����")]
        public string Weather
        {
            get { return GetPropertyValue<string>("Weather"); }
            set { SetPropertyValue("Weather", value); }
        } 

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "��¼ʱ�䣨��ȷ���֣�")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "������")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        } 

    }

    public enum DVideoType {δ֪ ,�����һ}
    

}
