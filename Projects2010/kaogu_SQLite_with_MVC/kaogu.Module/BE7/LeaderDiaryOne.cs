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
    [Custom("Caption", "领队日记（分）")]
    public class LeaderDiaryOne : BaseObject
    {
        public LeaderDiaryOne(Session session) : base(session) { }

        [Custom("Caption", "记录人")]
        public Worker RecordBy
        {
            get { return GetPropertyValue<Worker>("RecordBy"); }
            set { SetPropertyValue("RecordBy", value); }
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
        [Custom("Caption", "指导内容")]
        public string Content
        {
            get { return GetPropertyValue<string>("Content"); }
            set { SetPropertyValue("Content", value); }
        }

        [Custom("Caption", "指导队员")]
        public Worker GuideWorker
        {
            get { return GetPropertyValue<Worker>("GuideWorker"); }
            set { SetPropertyValue("GuideWorker", value); }
        }

        [Custom("Caption", "评分")]
        public int GuideScorer
        {
            get { return GetPropertyValue<int>("GuideScorer"); }
            set { SetPropertyValue("GuideScorer", value); }
        }

    }

}
