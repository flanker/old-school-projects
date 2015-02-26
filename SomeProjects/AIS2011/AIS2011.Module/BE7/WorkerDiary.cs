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
    [Custom("Caption", "队员日记")]
    public class WorkerDiary : BaseObject
    {
        public WorkerDiary(Session session) : base(session) { }

        [Custom("Caption", "记录人")]
        public Worker RecordBy
        {
            get { return GetPropertyValue<Worker>("RecordBy"); }
            set { SetPropertyValue("RecordBy", value); }
        }


        [Custom("Caption", "研究阶段")]
        public WorkerDiaryStage DiaryStage
        {
            get { return GetPropertyValue<WorkerDiaryStage>("DiaryStage"); }
            set { SetPropertyValue("DiaryStage", value); }
        }

        [Custom("Caption", "研究类型")]
        public WorkerDiaryType DiaryType
        {
            get { return GetPropertyValue<WorkerDiaryType>("DiaryType"); }
            set { SetPropertyValue("DiaryType", value); }
        }

        [Custom("Caption", "研究对象编号")]
        public string ObjectId
        {
            get { return GetPropertyValue<string>("ObjectId"); }
            set { SetPropertyValue("ObjectId", value); }
        }

        [Custom("Caption", "民工")]
        public string FWorker
        {
            get { return GetPropertyValue<string>("FWorker"); }
            set { SetPropertyValue("FWorker", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "开始时间（精确至分）")]
        public DateTime StartOn
        {
            get { return GetPropertyValue<DateTime>("StartOn"); }
            set { SetPropertyValue("StartOn", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "结束时间（精确至分）")]
        public DateTime EndOn
        {
            get { return GetPropertyValue<DateTime>("EndOn"); }
            set { SetPropertyValue("EndOn", value); }
        }

        [Custom("Caption", "天气")]
        public string Weather
        {
            get { return GetPropertyValue<string>("Weather"); }
            set { SetPropertyValue("Weather", value); }
        }

        [Size(3000)]
        [Custom("Caption", "对应描述")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }

      

        [Custom("Caption", "文字")]
        public WorkerDiaryRecordWord DiaryRecordW
        {
            get { return GetPropertyValue<WorkerDiaryRecordWord>("DiaryRecordW"); }
            set { SetPropertyValue("DiaryRecordW", value); }
        }

        [Custom("Caption", "绘图")]
        public WorkerDiaryRecordDraw DiaryRecordD
        {
            get { return GetPropertyValue<WorkerDiaryRecordDraw>("DiaryRecordD"); }
            set { SetPropertyValue("DiaryRecordD", value); }
        }

        [Custom("Caption", "测量")]
        public WorkerDiaryRecordMeasure DiaryRecordM
        {
            get { return GetPropertyValue<WorkerDiaryRecordMeasure>("DiaryRecordM"); }
            set { SetPropertyValue("DiaryRecordM", value); }
        }

        [Custom("Caption", "照相")]
        public WorkerDiaryRecordPhoto DiaryRecordP
        {
            get { return GetPropertyValue<WorkerDiaryRecordPhoto>("DiaryRecordP"); }
            set { SetPropertyValue("DiaryRecordP", value); }
        }

        [Custom("Caption", "摄像")]
        public WorkerDiaryRecordCamara DiaryRecordC
        {
            get { return GetPropertyValue<WorkerDiaryRecordCamara>("DiaryRecordC"); }
            set { SetPropertyValue("DiaryRecordC", value); }
        }

        [Custom("Caption", "其他")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        [Action(ToolTip = "基于此日记，填写新日记")]
        
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
    public enum WorkerDiaryStage { 未知, 观察, 分析计划, 观察_分析计划, 行为, 分析计划_行为, 行为_观察 }
    public enum WorkerDiaryType { 未知, 调查, 遗迹, 堆积, 器物, 样品 }

   
    
    public enum WorkerDiaryRecordWord { 有, 无 }
    public enum WorkerDiaryRecordDraw {无, 有 }
    public enum WorkerDiaryRecordMeasure { 无, 有 }
    public enum WorkerDiaryRecordPhoto {无, 有 }
    public enum WorkerDiaryRecordCamara { 无, 有 }

}
