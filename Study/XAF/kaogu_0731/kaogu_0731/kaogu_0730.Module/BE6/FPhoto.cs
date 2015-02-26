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
    [Custom("Caption", "��Ƭ��Ƭ�Ǽ�")]
    public class FPhoto : BaseObject
    {
        public FPhoto(Session session) : base(session) { }

        [Custom("Caption", "����ͺ�")]
        public FCameraType FCameraType
        {
            get { return GetPropertyValue<FCameraType>("FCameraType"); }
            set { SetPropertyValue("FCameraType", value); }
        }


        [Custom("Caption", "��-��")]
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

        

        [Custom("Caption", "��")]
        public string DirectionFrom
        {
            get { return GetPropertyValue<string>("DirectionFrom"); }
            set { SetPropertyValue("DirectionFrom", value); }
        }

        [Custom("Caption", "��")]
        public string DirectionTo
        {
            get { return GetPropertyValue<string>("DirectionTo"); }
            set { SetPropertyValue("DirectionTo", value); }
        }

        [Custom("Caption", "���㷽��")]
        public string Direction
        {
            get { return GetPropertyValue<string>("DirectionFrom") + "��" + GetPropertyValue<string>("DirectionTo"); }

        }

        [Custom("Caption", "��Ȧ")]
        public string Aperture
        {
            get { return GetPropertyValue<string>("Aperture"); }
            set { SetPropertyValue("Aperture", value); }
        }

        [Custom("Caption", "�ٶ�")]
        public string Speed
        {
            get { return GetPropertyValue<string>("Speed"); }
            set { SetPropertyValue("Speed", value); }
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

    public enum FCameraType {δ֪ ,���X}

}
