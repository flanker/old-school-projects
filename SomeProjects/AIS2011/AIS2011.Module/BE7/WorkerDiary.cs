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

      

        [Custom("Caption", "����")]
        public WorkerDiaryRecordWord DiaryRecordW
        {
            get { return GetPropertyValue<WorkerDiaryRecordWord>("DiaryRecordW"); }
            set { SetPropertyValue("DiaryRecordW", value); }
        }

        [Custom("Caption", "��ͼ")]
        public WorkerDiaryRecordDraw DiaryRecordD
        {
            get { return GetPropertyValue<WorkerDiaryRecordDraw>("DiaryRecordD"); }
            set { SetPropertyValue("DiaryRecordD", value); }
        }

        [Custom("Caption", "����")]
        public WorkerDiaryRecordMeasure DiaryRecordM
        {
            get { return GetPropertyValue<WorkerDiaryRecordMeasure>("DiaryRecordM"); }
            set { SetPropertyValue("DiaryRecordM", value); }
        }

        [Custom("Caption", "����")]
        public WorkerDiaryRecordPhoto DiaryRecordP
        {
            get { return GetPropertyValue<WorkerDiaryRecordPhoto>("DiaryRecordP"); }
            set { SetPropertyValue("DiaryRecordP", value); }
        }

        [Custom("Caption", "����")]
        public WorkerDiaryRecordCamara DiaryRecordC
        {
            get { return GetPropertyValue<WorkerDiaryRecordCamara>("DiaryRecordC"); }
            set { SetPropertyValue("DiaryRecordC", value); }
        }

        [Custom("Caption", "����")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        [Action(ToolTip = "���ڴ��ռǣ���д���ռ�")]
        
        public void Copydiary()
        {
           
            WorkerDiary wd = new WorkerDiary(Session);
            wd.RecordBy = RecordBy;
            wd.ObjectId = ObjectId;
            wd.Weather = Weather;
            wd.FWorker = FWorker;
            wd.StartOn = StartOn;
            wd.EndOn = EndOn;          
            
         }       

    }
    public enum WorkerDiaryStage { δ֪, �۲�, �����ƻ�, �۲�_�����ƻ�, ��Ϊ, �����ƻ�_��Ϊ, ��Ϊ_�۲� }
    public enum WorkerDiaryType { δ֪, ����, �ż�, �ѻ�, ����, ��Ʒ }

   
    
    public enum WorkerDiaryRecordWord { ��, �� }
    public enum WorkerDiaryRecordDraw {��, �� }
    public enum WorkerDiaryRecordMeasure { ��, �� }
    public enum WorkerDiaryRecordPhoto {��, �� }
    public enum WorkerDiaryRecordCamara { ��, �� }

}
