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
    [Custom("Caption", "��Ա�ռ�")]
    public class WorkerDiary : BaseObject
    {
        public WorkerDiary(Session session) : base(session) { }

        [Custom("Caption", "��¼��")]
        public Worker RecordBy
        {
            get { return GetPropertyValue<Worker>("RecordBy"); }
            set { SetPropertyValue("RecordBy", value); }
        }


        [Custom("Caption", "�о��׶�")]
        public WorkerDiaryStage DiaryStage
        {
            get { return GetPropertyValue<WorkerDiaryStage>("DiaryStage"); }
            set { SetPropertyValue("DiaryStage", value); }
        }

        [Custom("Caption", "�о�����")]
        public WorkerDiaryType DiaryType
        {
            get { return GetPropertyValue<WorkerDiaryType>("DiaryType"); }
            set { SetPropertyValue("DiaryType", value); }
        }

        [Custom("Caption", "�о�������")]
        public string ObjectId
        {
            get { return GetPropertyValue<string>("ObjectId"); }
            set { SetPropertyValue("ObjectId", value); }
        }

        [Custom("Caption", "��")]
        public string FWorker
        {
            get { return GetPropertyValue<string>("FWorker"); }
            set { SetPropertyValue("FWorker", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "��ʼʱ�䣨��ȷ���֣�")]
        public DateTime StartOn
        {
            get { return GetPropertyValue<DateTime>("StartOn"); }
            set { SetPropertyValue("StartOn", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "����ʱ�䣨��ȷ���֣�")]
        public DateTime EndOn
        {
            get { return GetPropertyValue<DateTime>("EndOn"); }
            set { SetPropertyValue("EndOn", value); }
        }

        [Custom("Caption", "����")]
        public string Weather
        {
            get { return GetPropertyValue<string>("Weather"); }
            set { SetPropertyValue("Weather", value); }
        }

        [Size(3000)]
        [Custom("Caption", "��Ӧ����")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }

        [Custom("Caption", "��¼����")]
        public WorkerDiaryRecord DiaryRecord
        {
            get { return GetPropertyValue<WorkerDiaryRecord>("DiaryRecord"); }
            set { SetPropertyValue("DiaryRecord", value); }
        }

        [Custom("Caption", "����")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

    }
    public enum WorkerDiaryStage { δ֪, �۲�_�����ƻ�, �����ƻ�_��Ϊ, ��Ϊ }
    public enum WorkerDiaryType { δ֪, ����, �ż�, �ѻ�, ����, ��Ʒ }
    public enum WorkerDiaryRecord { δ֪, ����, ��ͼ, ����, ����, ���� }
}
