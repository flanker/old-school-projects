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
    [Custom("Caption", "采样登记")]
    public class Sample : BaseObject
    {
        public Sample(Session session) : base(session) { }

        [Custom("Caption", "采样人")]
        public Worker RecordBy
        {
            get { return GetPropertyValue<Worker>("RecordBy"); }
            set { SetPropertyValue("RecordBy", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "记录时间（精确至分）")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "样品编号")]
        public RemainMark Id
        {
            get { return GetPropertyValue<RemainMark>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "工作方式")]
        public WorkType WorkType
        {
            get { return GetPropertyValue<WorkType>("WorkType"); }
            set { SetPropertyValue("WorkType", value); }
        }

        [Custom("Caption", "样品类别")]
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

        [Custom("Caption", "占总体堆积数量的百分比")]
        public PersentInAll PersentInAll
        {
            get { return GetPropertyValue<PersentInAll>("PersentInAll"); }
            set { SetPropertyValue("PersentInAll", value); }
        }

        //样品规格（厘米）

        [Custom("Caption", "长（厘米）")]
        public float Length
        {
            get { return GetPropertyValue<float>("Length"); }
            set { SetPropertyValue("Length", value); }
        }

        [Custom("Caption", "宽")]
        public float Width
        {
            get { return GetPropertyValue<float>("Width"); }
            set { SetPropertyValue("Width", value); }
        }

        [Custom("Caption", "高")]
        public float Height
        {
            get { return GetPropertyValue<float>("Height"); }
            set { SetPropertyValue("Height", value); }
        }

        [Custom("Caption", "样本体积（毫升）")]
        public float Size
        {
            get { return GetPropertyValue<float>("Size"); }
            set { SetPropertyValue("Size", value); }
        }

        [Custom("Caption", "样本重量（克）")]
        public float Weight
        {
            get { return GetPropertyValue<float>("Weight"); }
            set { SetPropertyValue("Weight", value); }
        }

        [Custom("Caption", "取样方式")]
        public GetSampleType GetSampleType
        {
            get { return GetPropertyValue<GetSampleType>("GetSampleType"); }
            set { SetPropertyValue("GetSampleType", value); }
        }

        [Custom("Caption", "取样工具")]
        public GetTool GetTool
        {
            get { return GetPropertyValue<GetTool>("GetTool"); }
            set { SetPropertyValue("GetTool", value); }
        }

        [Custom("Caption", "天气状况")]
        public string Weather
        {
            get { return GetPropertyValue<string>("Weather"); }
            set { SetPropertyValue("Weather", value); }
        }

        [Custom("Caption", "保存状况")]
        public string Protection
        {
            get { return GetPropertyValue<string>("Protection"); }
            set { SetPropertyValue("Protection", value); }
        }

        [Custom("Caption", "样品污染")]
        public SamplePollution SamplePollution
        {
            get { return GetPropertyValue<SamplePollution>("SamplePollution"); }
            set { SetPropertyValue("SamplePollution", value); }
        }

        [Custom("Caption", "包装方式")]
        public PackType PackType
        {
            get { return GetPropertyValue<PackType>("PackType"); }
            set { SetPropertyValue("PackType", value); }
        }

        [Custom("Caption", "包含物")]
        public string Contain
        {
            get { return GetPropertyValue<string>("Contain"); }
            set { SetPropertyValue("Contain", value); }
        }

        [Custom("Caption", "堆积性质")]
        public string AccumulationProperty
        {
            get { return GetPropertyValue<string>("AccumulationProperty"); }
            set { SetPropertyValue("AccumulationProperty", value); }
        }

        [Custom("Caption", "判断理由")]
        public string AccumulationReason
        {
            get { return GetPropertyValue<string>("AccumulationReason"); }
            set { SetPropertyValue("AccumulationReason", value); }
        }

        [Custom("Caption", "文化性质")]
        public string CultureProperty
        {
            get { return GetPropertyValue<string>("CultureProperty"); }
            set { SetPropertyValue("CultureProperty", value); }
        }

        [Custom("Caption", "判断理由")]
        public string CultureReason
        {
            get { return GetPropertyValue<string>("CultureReason"); }
            set { SetPropertyValue("CultureReason", value); }
        }

        [Custom("Caption", "取样目的")]
        public string SampleAim
        {
            get { return GetPropertyValue<string>("SampleAim"); }
            set { SetPropertyValue("SampleAim", value); }
        }

        [Custom("Caption", "考古问题")]
        public string ArchQuestion
        {
            get { return GetPropertyValue<string>("ArchQuestion"); }
            set { SetPropertyValue("ArchQuestion", value); }
        }

        //绘图号 照相号 摄像号

        //采样点示意图

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
    }

    public enum SampleType { 未知, 土样, 碳样, 金属样, 骨骼样, 玉石样, 陶瓷样, 纺织品样, 漆器样, 其他 }
    public enum PersentInAll { 未知, 小于5, 从5到15, 从25到50, 大于50, 近100}
    public enum GetSampleType { 未知, 平面, 剖面, 其他 }
    public enum GetTool { 未知, 手铲, 铁锹, 其他 }
    public enum SamplePollution { 未知, 无, 轻微, 严重, 其他 }
    public enum PackType { 未知, 铝箔, 保鲜膜, 塑封袋, 脱脂棉, 纸, 其他 } 

}
