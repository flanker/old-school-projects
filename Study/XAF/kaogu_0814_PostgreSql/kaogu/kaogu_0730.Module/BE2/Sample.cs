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
    [Custom("Caption", "�����Ǽ�")]
    public class Sample : BaseObject
    {
        public Sample(Session session) : base(session) { }

        [Custom("Caption", "������")]
        public Worker RecordBy
        {
            get { return GetPropertyValue<Worker>("RecordBy"); }
            set { SetPropertyValue("RecordBy", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "��¼ʱ�䣨��ȷ���֣�")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "��Ʒ���")]
        public RemainMark Id
        {
            get { return GetPropertyValue<RemainMark>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "������ʽ")]
        public WorkType WorkType
        {
            get { return GetPropertyValue<WorkType>("WorkType"); }
            set { SetPropertyValue("WorkType", value); }
        }

        [Custom("Caption", "��Ʒ���")]
        public SampleType SampleType
        {
            get { return GetPropertyValue<SampleType>("SampleType"); }
            set { SetPropertyValue("SampleType", value); }
        }

        public float X
        {
            get { return GetPropertyValue<float>("X"); }
            set { SetPropertyValue("X", value); }
        }


        public float Y
        {
            get { return GetPropertyValue<float>("Y"); }
            set { SetPropertyValue("Y", value); }
        }

        public float Z
        {
            get { return GetPropertyValue<float>("Z"); }
            set { SetPropertyValue("Z", value); }
        }

        [Custom("Caption", "ռ����ѻ������İٷֱ�")]
        public PersentInAll PersentInAll
        {
            get { return GetPropertyValue<PersentInAll>("PersentInAll"); }
            set { SetPropertyValue("PersentInAll", value); }
        }

        //��Ʒ������ף�

        [Custom("Caption", "�������ף�")]
        public float Length
        {
            get { return GetPropertyValue<float>("Length"); }
            set { SetPropertyValue("Length", value); }
        }

        [Custom("Caption", "��")]
        public float Width
        {
            get { return GetPropertyValue<float>("Width"); }
            set { SetPropertyValue("Width", value); }
        }

        [Custom("Caption", "��")]
        public float Height
        {
            get { return GetPropertyValue<float>("Height"); }
            set { SetPropertyValue("Height", value); }
        }

        [Custom("Caption", "���������������")]
        public float Size
        {
            get { return GetPropertyValue<float>("Size"); }
            set { SetPropertyValue("Size", value); }
        }

        [Custom("Caption", "�����������ˣ�")]
        public float Weight
        {
            get { return GetPropertyValue<float>("Weight"); }
            set { SetPropertyValue("Weight", value); }
        }

        [Custom("Caption", "ȡ����ʽ")]
        public GetSampleType GetSampleType
        {
            get { return GetPropertyValue<GetSampleType>("GetSampleType"); }
            set { SetPropertyValue("GetSampleType", value); }
        }

        [Custom("Caption", "ȡ������")]
        public GetTool GetTool
        {
            get { return GetPropertyValue<GetTool>("GetTool"); }
            set { SetPropertyValue("GetTool", value); }
        }

        [Custom("Caption", "����״��")]
        public string Weather
        {
            get { return GetPropertyValue<string>("Weather"); }
            set { SetPropertyValue("Weather", value); }
        }

        [Custom("Caption", "����״��")]
        public string Protection
        {
            get { return GetPropertyValue<string>("Protection"); }
            set { SetPropertyValue("Protection", value); }
        }

        [Custom("Caption", "��Ʒ��Ⱦ")]
        public SamplePollution SamplePollution
        {
            get { return GetPropertyValue<SamplePollution>("SamplePollution"); }
            set { SetPropertyValue("SamplePollution", value); }
        }

        [Custom("Caption", "��װ��ʽ")]
        public PackType PackType
        {
            get { return GetPropertyValue<PackType>("PackType"); }
            set { SetPropertyValue("PackType", value); }
        }

        [Custom("Caption", "������")]
        public string Contain
        {
            get { return GetPropertyValue<string>("Contain"); }
            set { SetPropertyValue("Contain", value); }
        }

        [Custom("Caption", "�ѻ�����")]
        public string AccumulationProperty
        {
            get { return GetPropertyValue<string>("AccumulationProperty"); }
            set { SetPropertyValue("AccumulationProperty", value); }
        }

        [Custom("Caption", "�ж�����")]
        public string AccumulationReason
        {
            get { return GetPropertyValue<string>("AccumulationReason"); }
            set { SetPropertyValue("AccumulationReason", value); }
        }

        [Custom("Caption", "�Ļ�����")]
        public string CultureProperty
        {
            get { return GetPropertyValue<string>("CultureProperty"); }
            set { SetPropertyValue("CultureProperty", value); }
        }

        [Custom("Caption", "�ж�����")]
        public string CultureReason
        {
            get { return GetPropertyValue<string>("CultureReason"); }
            set { SetPropertyValue("CultureReason", value); }
        }

        [Custom("Caption", "ȡ��Ŀ��")]
        public string SampleAim
        {
            get { return GetPropertyValue<string>("SampleAim"); }
            set { SetPropertyValue("SampleAim", value); }
        }

        [Custom("Caption", "��������")]
        public string ArchQuestion
        {
            get { return GetPropertyValue<string>("ArchQuestion"); }
            set { SetPropertyValue("ArchQuestion", value); }
        }

        //��ͼ�� ����� �����

        //������ʾ��ͼ

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
    }

    public enum SampleType { δ֪, ����, ̼��, ������, ������, ��ʯ��, �մ���, ��֯Ʒ��, ������, ���� }
    public enum PersentInAll { δ֪, С��5, ��5��15, ��25��50, ����50, ��100}
    public enum GetSampleType { δ֪, ƽ��, ����, ���� }
    public enum GetTool { δ֪, �ֲ�, ����, ���� }
    public enum SamplePollution { δ֪, ��, ��΢, ����, ���� }
    public enum PackType { δ֪, ����, ����Ĥ, �ܷ��, ��֬��, ֽ, ���� } 

}
