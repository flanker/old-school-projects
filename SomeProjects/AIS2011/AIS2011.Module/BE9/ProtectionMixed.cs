using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo.Metadata;

namespace kaogu_0730.Module
{
    //样品采集信息 
    //环境样品 样品编号-样品照片编号（一对多）-采样部位-采样方法-采样量
    //文物样品 样品编号-样品照片编号-采样部位-采样方法-采样量
    [Custom("Caption", "文物保护-样品采集信息")]
    [DefaultClassOptions]
    public class ProtectionSample : BaseObject
    {
        public ProtectionSample(Session session) : base(session) { }

        [Custom("Caption", "对应保护文物")]
        [Association("Protection-ProtectionSample", typeof(Protection))]
        public Protection Protection
        {
            get { return GetPropertyValue<Protection>("Protection"); }
            set { SetPropertyValue("Protection", value); }
        }

        [Custom("Caption", "样品类别")]
        public ProtectionSampleType ProtectionSampleType
        {
            get { return GetPropertyValue<ProtectionSampleType>("ProtectionSampleType"); }
            set { SetPropertyValue("ProtectionSampleType", value); }
        }

        [Custom("Caption", "样品编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "样品照片编号")]
        [Association("ProtectionSample-ProtectionPhoto", typeof(ProtectionPhoto))]
        public XPCollection ProtectionPhoto
        {
            get { return GetCollection("ProtectionPhoto"); }
        }

        [Size(3000)]
        [Custom("Caption", "采样部位")]
        public string Part
        {
            get { return GetPropertyValue<string>("Part"); }
            set { SetPropertyValue("Part", value); }
        }

        [Size(3000)]
        [Custom("Caption", "采样方法")]
        public string Method
        {
            get { return GetPropertyValue<string>("Method"); }
            set { SetPropertyValue("Method", value); }
        }

        [Custom("Caption", "采样量")]
        public string Quantity
        {
            get { return GetPropertyValue<string>("Quantity"); }
            set { SetPropertyValue("Quantity", value); }
        }
    }

    public enum ProtectionSampleType { 未知, 环境, 文物 }
    //照片 一对多 
    //文物保存现状照片 照片编号-拍摄时间-拍摄人

    //文物样品采集照片 采样前文物/环境局部 采样后文物/环境局部

    //文物现场保护处理照片 处理阶段 （处理前 处理后） - 保护处理方法
    [Custom("Caption", "文物保护-照片")]
    [DefaultClassOptions]
    public class ProtectionPhoto : BaseObject
    {

        public ProtectionPhoto(Session session) : base(session) { }

        [Custom("Caption", "对应保护文物")]
        [Association("Protection-ProtectionPhoto", typeof(Protection))]
        public Protection Protection
        {
            get { return GetPropertyValue<Protection>("Protection"); }
            set { SetPropertyValue("Protection", value); }
        }

        [Custom("Caption", "对应保护文物采样")]
        [Association("ProtectionSample-ProtectionPhoto", typeof(ProtectionSample))]
        public ProtectionSample ProtectionSample
        {
            get { return GetPropertyValue<ProtectionSample>("ProtectionSample"); }
            set { SetPropertyValue("ProtectionSample", value); }
        }

        [Custom("Caption", "对应保护阶段")]
        public ProtectionStep ProtectionStep
        {
            get { return GetPropertyValue<ProtectionStep>("ProtectionStep"); }
            set { SetPropertyValue("ProtectionStep", value); }
        }

        

        [Custom("Caption", "保护处理方法")]
        public string ProtectionMethod
        {
            get { return GetPropertyValue<string>("ProtectionMethod"); }
            set { SetPropertyValue("ProtectionMethod", value); }
        }

        [Custom("caption", "照片编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "拍摄人")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "拍摄时间")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

      //照片
        //[VisibleInListView(true)]
        //[DevExpress.Xpo.Size(SizeAttribute.Unlimited), ValueConverter(typeof(ImageValueConverter))]
        //[ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 40)]
        //[Custom("Caption", "照片")]
        //public Image Photo
        //{
        //    get { return GetPropertyValue<Image>("Photo"); }
        //    set { SetPropertyValue<Image>("Photo", value); }
        //}

    }

    public enum ProtectionStep { 未知, 保存现状, 采样前文物或环境局部, 采样后文物或环境局部, 现场保护处理前, 现场保护处理后 }

    //一对多 样品分析检测结果 检测目的-检测方法-样品种类-样品用量-检测结果-检测单位-检测人
    [Custom("Caption", "文物保护-样品分析检测结果")]
    [DefaultClassOptions]
    public class ProtectionSampleResult : BaseObject
    {
        public ProtectionSampleResult(Session session) : base(session) { }


        [Custom("Caption", "对应保护文物")]
        [Association("Protection-ProtectionSampleResult", typeof(Protection))]
        public Protection Protection
        {
            get { return GetPropertyValue<Protection>("Protection"); }
            set { SetPropertyValue("Protection", value); }
        }

        [Size(3000)]
        [Custom("Caption", "检测目的")]
        public string Goal
        {
            get { return GetPropertyValue<string>("Goal"); }
            set { SetPropertyValue("Goal", value); }
        }

        [Size(3000)]
        [Custom("Caption", "检测方法")]
        public string Method
        {
            get { return GetPropertyValue<string>("Method"); }
            set { SetPropertyValue("Method", value); }
        }

        [Size(3000)]
        [Custom("Caption", "样品种类")]
        public string SampleType
        {
            get { return GetPropertyValue<string>("SampleType"); }
            set { SetPropertyValue("SampleType", value); }
        }

        [Size(3000)]
        [Custom("Caption", "样品用量")]
        public string SampleDosage
        {
            get { return GetPropertyValue<string>("SampleDosage"); }
            set { SetPropertyValue("SampleDosage", value); }
        }

        [Size(20000)]
        [Custom("Caption", "检测结果")]
        public string Result
        {
            get { return GetPropertyValue<string>("Result"); }
            set { SetPropertyValue("Result", value); }
        }

        [Custom("Caption", "检测单位")]
        public PDepartment TestAt
        {
            get { return GetPropertyValue<PDepartment>("TestAt"); }
            set { SetPropertyValue("TestAt", value); }
        }

        [Custom("Caption", "检测人")]
        public Worker TestBy
        {
            get { return GetPropertyValue<Worker>("TestBy"); }
            set { SetPropertyValue("TestBy", value); }
        }
    }

}
