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

        [Custom("Caption", "记录类型")]
        public WorkerDiaryRecord DiaryRecord
        {
            get { return GetPropertyValue<WorkerDiaryRecord>("DiaryRecord"); }
            set { SetPropertyValue("DiaryRecord", value); }
        }

        [Custom("Caption", "其他")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

    }
    public enum WorkerDiaryStage { 未知, 观察_分析计划, 分析计划_行为, 行为 }
    public enum WorkerDiaryType { 未知, 调查, 遗迹, 堆积, 器物, 样品 }
    public enum WorkerDiaryRecord { 未知, 文字, 绘图, 测量, 照相, 摄像 }
}
