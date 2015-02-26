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
    [System.ComponentModel.DefaultProperty("DiaryAll")]
    [Custom("Caption", "领队日记（总）")]
    public class LeaderDiaryAll : BaseObject
    {
        public LeaderDiaryAll(Session session) : base(session) { }

        [Custom("Caption", "领队工作日记")]
        public string DiaryAll
        {
            get { return GetPropertyValue<Worker>("RecordBy") + "; " + GetPropertyValue<DateTime>("RecordOn") + "; " + GetPropertyValue<LeaderDiaryAllType>("LeaderDiaryAllType"); }
        }

        [Custom("Caption", "记录人")]
        public Worker RecordBy
        {
            get { return GetPropertyValue<Worker>("RecordBy"); }
            set { SetPropertyValue("RecordBy", value); }
        }

        [Custom("Caption", "记录日期")]
        public DateTime RecordOn
        {
            get { return GetPropertyValue<DateTime>("RecordOn"); }
            set { SetPropertyValue("RecordOn", value); }
        }

        [Custom("Caption", "天气")]
        public string Weather
        {
            get { return GetPropertyValue<string>("Weather"); }
            set { SetPropertyValue("Weather", value); }
        }

        [Custom("Caption", "日记类别")]
        public LeaderDiaryAllType LeaderDiaryAllType
        {
            get { return GetPropertyValue<LeaderDiaryAllType>("LeaderDiaryAllType"); }
            set { SetPropertyValue("LeaderDiaryAllType", value); }
        }

        [Custom("Caption", "提取")]
        public Boolean IsGetThing
        {
            get { return GetPropertyValue<Boolean>("IsGetThing"); }
            set { SetPropertyValue("IsGetThing", value); }
        }

        [Custom("Caption", "样本数量")]
        public int SampleNum
        {
            get { return GetPropertyValue<int>("SampleNum"); }
            set { SetPropertyValue("SampleNum", value); }
        }
        [Custom("Caption", "器物数量")]
        public int ArtificialNum
        {
            get { return GetPropertyValue<int>("ArtificialNum"); }
            set { SetPropertyValue("ArtificialNum", value); }
        }

        [Custom("Caption", "陶片数量")]
        public int PotteryNum
        {
            get { return GetPropertyValue<int>("PotteryNum"); }
            set { SetPropertyValue("PotteryNum", value); }
        }

        [Custom("Caption", "骨骼数量")]
        public int BoneNum
        {
            get { return GetPropertyValue<int>("BoneNum"); }
            set { SetPropertyValue("BoneNum", value); }
        }

        [Custom("Caption", "给号")]
        public Boolean IsGetNum
        {
            get { return GetPropertyValue<Boolean>("IsGetNum"); }
            set { SetPropertyValue("IsGetNum", value); }
        }

        [Custom("Caption", "给号内容")]
        public string GetNum
        {
            get { return GetPropertyValue<string>("GetNum"); }
            set { SetPropertyValue("IsGetNum", value); }
        }

        [Custom("Caption", "改号")]
        public Boolean IsChangeNum
        {
            get { return GetPropertyValue<Boolean>("IsChangeNum"); }
            set { SetPropertyValue("IsChangeNum", value); }
        }

        [Custom("Caption", "改号内容")]
        public string ChangeNum
        {
            get { return GetPropertyValue<string>("ChangeNum"); }
            set { SetPropertyValue("ChangeNum", value); }
        }

        [Custom("Caption", "工作内容")]
        public string Content
        {
            get { return GetPropertyValue<string>("Content"); }
            set { SetPropertyValue("Content", value); }
        }

        [Custom("Caption", "经验总结")]
        public string Experience
        {
            get { return GetPropertyValue<string>("Experience"); }
            set { SetPropertyValue("Experience", value); }
        }

        [Custom("Caption", "备忘")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        [Custom("Caption", "审核人")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }

        [Custom("Caption", "审核时间")]
        public DateTime CheckOn
        {
            get { return GetPropertyValue<DateTime>("CheckOn"); }
            set { SetPropertyValue("CheckOn", value); }
        }

        [Association("LDA-LDAUnit", typeof(LDAUnit))]
        [Custom("Caption", "领队单位进度")]
        public XPCollection LDAUnit
        {
            get { return GetCollection("LDAUnit"); }
        }

    }
    public enum LeaderDiaryAllType { 未知, 调查, 发掘 }


    [DefaultClassOptions]
    [Custom("Caption", "领队单位进度")]
    public class LDAUnit : BaseObject
    {
        public LDAUnit(Session session) : base(session) { }

        [Custom("Caption", "单位类别")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "名称")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "进度")]
        public string Progress
        {
            get { return GetPropertyValue<string>("Progress"); }
            set { SetPropertyValue("Progress", value); }
        }

        [Association("LDA-LDAUnit", typeof(LeaderDiaryAll))]
        [Custom("Caption", "领队工作日记（总）")]
        public LeaderDiaryAll LeaderDiaryAll
        {
            get { return GetPropertyValue<LeaderDiaryAll>("LeaderDiaryAll"); }
            set { SetPropertyValue("LeaderDiaryAll", value); }
        }
    }

}
