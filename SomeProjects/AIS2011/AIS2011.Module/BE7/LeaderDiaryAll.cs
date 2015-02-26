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
    [Custom("Caption", "����ռǣ��ܣ�")]
    public class LeaderDiaryAll : BaseObject
    {
        public LeaderDiaryAll(Session session) : base(session) { }

        [Custom("Caption", "��ӹ����ռ�")]
        public string DiaryAll
        {
            get { return GetPropertyValue<Worker>("RecordBy") + "; " + GetPropertyValue<DateTime>("RecordOn") + "; " + GetPropertyValue<LeaderDiaryAllType>("LeaderDiaryAllType"); }
        }

        [Custom("Caption", "��¼��")]
        public Worker RecordBy
        {
            get { return GetPropertyValue<Worker>("RecordBy"); }
            set { SetPropertyValue("RecordBy", value); }
        }

        [Custom("Caption", "��¼����")]
        public DateTime RecordOn
        {
            get { return GetPropertyValue<DateTime>("RecordOn"); }
            set { SetPropertyValue("RecordOn", value); }
        }

        [Custom("Caption", "����")]
        public string Weather
        {
            get { return GetPropertyValue<string>("Weather"); }
            set { SetPropertyValue("Weather", value); }
        }

        [Custom("Caption", "�ռ����")]
        public LeaderDiaryAllType LeaderDiaryAllType
        {
            get { return GetPropertyValue<LeaderDiaryAllType>("LeaderDiaryAllType"); }
            set { SetPropertyValue("LeaderDiaryAllType", value); }
        }

        [Custom("Caption", "��ȡ")]
        public Boolean IsGetThing
        {
            get { return GetPropertyValue<Boolean>("IsGetThing"); }
            set { SetPropertyValue("IsGetThing", value); }
        }

        [Custom("Caption", "��������")]
        public int SampleNum
        {
            get { return GetPropertyValue<int>("SampleNum"); }
            set { SetPropertyValue("SampleNum", value); }
        }
        [Custom("Caption", "��������")]
        public int ArtificialNum
        {
            get { return GetPropertyValue<int>("ArtificialNum"); }
            set { SetPropertyValue("ArtificialNum", value); }
        }

        [Custom("Caption", "��Ƭ����")]
        public int PotteryNum
        {
            get { return GetPropertyValue<int>("PotteryNum"); }
            set { SetPropertyValue("PotteryNum", value); }
        }

        [Custom("Caption", "��������")]
        public int BoneNum
        {
            get { return GetPropertyValue<int>("BoneNum"); }
            set { SetPropertyValue("BoneNum", value); }
        }

        [Custom("Caption", "����")]
        public Boolean IsGetNum
        {
            get { return GetPropertyValue<Boolean>("IsGetNum"); }
            set { SetPropertyValue("IsGetNum", value); }
        }

        [Custom("Caption", "��������")]
        public string GetNum
        {
            get { return GetPropertyValue<string>("GetNum"); }
            set { SetPropertyValue("IsGetNum", value); }
        }

        [Custom("Caption", "�ĺ�")]
        public Boolean IsChangeNum
        {
            get { return GetPropertyValue<Boolean>("IsChangeNum"); }
            set { SetPropertyValue("IsChangeNum", value); }
        }

        [Custom("Caption", "�ĺ�����")]
        public string ChangeNum
        {
            get { return GetPropertyValue<string>("ChangeNum"); }
            set { SetPropertyValue("ChangeNum", value); }
        }

        [Custom("Caption", "��������")]
        public string Content
        {
            get { return GetPropertyValue<string>("Content"); }
            set { SetPropertyValue("Content", value); }
        }

        [Custom("Caption", "�����ܽ�")]
        public string Experience
        {
            get { return GetPropertyValue<string>("Experience"); }
            set { SetPropertyValue("Experience", value); }
        }

        [Custom("Caption", "����")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        [Custom("Caption", "�����")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }

        [Custom("Caption", "���ʱ��")]
        public DateTime CheckOn
        {
            get { return GetPropertyValue<DateTime>("CheckOn"); }
            set { SetPropertyValue("CheckOn", value); }
        }

        [Association("LDA-LDAUnit", typeof(LDAUnit))]
        [Custom("Caption", "��ӵ�λ����")]
        public XPCollection LDAUnit
        {
            get { return GetCollection("LDAUnit"); }
        }

    }
    public enum LeaderDiaryAllType { δ֪, ����, ���� }


    [DefaultClassOptions]
    [Custom("Caption", "��ӵ�λ����")]
    public class LDAUnit : BaseObject
    {
        public LDAUnit(Session session) : base(session) { }

        [Custom("Caption", "��λ���")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "����")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "����")]
        public string Progress
        {
            get { return GetPropertyValue<string>("Progress"); }
            set { SetPropertyValue("Progress", value); }
        }

        [Association("LDA-LDAUnit", typeof(LeaderDiaryAll))]
        [Custom("Caption", "��ӹ����ռǣ��ܣ�")]
        public LeaderDiaryAll LeaderDiaryAll
        {
            get { return GetPropertyValue<LeaderDiaryAll>("LeaderDiaryAll"); }
            set { SetPropertyValue("LeaderDiaryAll", value); }
        }
    }

}
