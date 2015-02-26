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
    [Custom("Caption", "��ͼ�Ǽ�")]
    public class Picture : BaseObject
    {
        public Picture(Session session) : base(session) { }

        [Custom("Caption", "����")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "���")]
        public PictureObjectType Type
        {
            get { return GetPropertyValue<PictureObjectType>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "��ͼ��")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "����")]
        public string Scale
        {
            get { return GetPropertyValue<string>("Scale"); }
            set { SetPropertyValue("Scale", value); }
        }


        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "������ڣ���ȷ���֣�")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "��ͼ��ʽ")]
        public PictureMethod PictureMethod
        {
            get { return GetPropertyValue<PictureMethod>("PictureMethod"); }
            set { SetPropertyValue("PictureMethod", value); }
        }

        [Custom("Caption", "��ͼ��")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }


        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "������ڣ���ȷ���֣�")]
        public DateTime CheckOn
        {
            get { return GetPropertyValue<DateTime>("CheckOn"); }
            set { SetPropertyValue("CheckOn", value); }
        }

        [Custom("Caption", "�����")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }


    }

    public enum PictureObjectType { δ֪, �ż�, ���� }

    public enum PictureMethod { δ֪, ����, ����ͼ, ��д } 
}
