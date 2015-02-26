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
    [Custom("Caption", "���Ǽ�")]
    public class InStorage : BaseObject
    {
        public InStorage(Session session) : base(session) { }

        

        [Custom("Caption", "������ʽ")]
        public WorkTypeStoreage WorkType
        {
            get { return GetPropertyValue<WorkTypeStoreage>("WorkType"); }
            set { SetPropertyValue("WorkType", value); }
        }

        [Custom("Caption", "��������")]
        public RemainType RemainType
        {
            get { return GetPropertyValue<RemainType>("RemainType"); }
            set { SetPropertyValue("RemainType", value); }
        }

        [Custom("Caption", "������")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }          
        }       

        [Custom("Caption", "��������")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "��¼ʱ�䣨��ȷ���֣�")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "�ɼ���")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("Caption", "�˶���")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }

        [Custom("Caption", "��ע")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        [Action(ToolTip = "�ɿ���������ɳ���Ǽ�")]
        public void PutOut()
        {

            OutStorage os = new OutStorage(Session);
            os.WorkType = WorkType;
            os.RemainType = RemainType;
            os.Id = Id;
            os.Name = Name;
            
        }
    }

    public enum WorkTypeStoreage { δ֪, ����, �ھ� }


}
