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
    [Custom("Caption","��ŸĶ�")]
    public class MarkChange : BaseObject
    {

        public MarkChange(Session session) : base(session) { }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "��¼ʱ�䣨��ȷ���֣�")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }


        [Custom("Caption", "�ż�/����")]
        public WorkType MarkType
        {
            get { return GetPropertyValue<WorkType>("MarkType"); }
            set { SetPropertyValue("MarkType", value); }
        }

        [Custom("Caption", "���")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }



        [Custom("Caption", "ԭ���")]
        public string OldId
        {
            get { return GetPropertyValue<string>("OldId"); }
            set { SetPropertyValue("OldId", value); }
        }

        [Custom("Caption", "�±��")]
        public string NewId
        {
            get { return GetPropertyValue<string>("NewId"); }
            set { SetPropertyValue("NewId", value); }
        }

        [Custom("Caption", "����ԭ��")]
        public string Reason
        {
            get { return GetPropertyValue<string>("Reason"); }
            set { SetPropertyValue("Reason", value); }
        }

        [Custom("Caption", "������")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("Caption", "�����")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }
    }

    public enum WorkType { δ֪, �ż�, ���� }

}
