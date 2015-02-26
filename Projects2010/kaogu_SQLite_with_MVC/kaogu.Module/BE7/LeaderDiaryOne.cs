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
    [Custom("Caption", "����ռǣ��֣�")]
    public class LeaderDiaryOne : BaseObject
    {
        public LeaderDiaryOne(Session session) : base(session) { }

        [Custom("Caption", "��¼��")]
        public Worker RecordBy
        {
            get { return GetPropertyValue<Worker>("RecordBy"); }
            set { SetPropertyValue("RecordBy", value); }
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
        [Custom("Caption", "ָ������")]
        public string Content
        {
            get { return GetPropertyValue<string>("Content"); }
            set { SetPropertyValue("Content", value); }
        }

        [Custom("Caption", "ָ����Ա")]
        public Worker GuideWorker
        {
            get { return GetPropertyValue<Worker>("GuideWorker"); }
            set { SetPropertyValue("GuideWorker", value); }
        }

        [Custom("Caption", "����")]
        public int GuideScorer
        {
            get { return GetPropertyValue<int>("GuideScorer"); }
            set { SetPropertyValue("GuideScorer", value); }
        }

    }

}
