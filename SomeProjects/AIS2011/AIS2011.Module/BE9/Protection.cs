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
    [Custom("Caption", "考古发掘现场文物保护处理技术档案")]
    [System.ComponentModel.DefaultProperty("Id")]
    [DefaultClassOptions]
    public class Protection : BaseObject
    {
        public Protection(Session session) : base(session) { }

        [Custom("Caption", "档案编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        //记录人 记录时间
        [Custom("Caption", "记录人")]
        public Worker RecordBy
        {
            get { return GetPropertyValue<Worker>("RecordBy"); }
            set { SetPropertyValue("RecordBy", value); }
        }

        [Custom("Caption", "保护时间")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }


        //文物基本信息： 名称-编号-材质-尺寸-质量-数量-出土位置-发现时间
        [Custom("Caption", "文物名称")]
        public string RelicName
        {
            get { return GetPropertyValue<string>("RelicName"); }
            set { SetPropertyValue("RelicName", value); }
        }

        [Custom("Caption", "文物编号")]
        public string RelicId
        {
            get { return GetPropertyValue<string>("RelicId"); }
            set { SetPropertyValue("RelicId", value); }
        }

        [Custom("Caption", "材质")]
        public string Material
        {
            get { return GetPropertyValue<string>("Material"); }
            set { SetPropertyValue("Material", value); }
        }
        [Size(3000)]
        [Custom("Caption", "尺寸")]
        public string Size
        {
            get { return GetPropertyValue<string>("Size"); }
            set { SetPropertyValue("Size", value); }
        }

        [Custom("Caption", "质量")]
        public string Quality
        {
            get { return GetPropertyValue<string>("Quality"); }
            set { SetPropertyValue("Quality", value); }
        }

        [Custom("Caption", "数量")]
        public string Quantity
        {
            get { return GetPropertyValue<string>("Quantity"); }
            set { SetPropertyValue("Quantity", value); }
        }

        [Size(3000)]
        [Custom("Caption", "出土位置")]
        public string Location
        {
            get { return GetPropertyValue<string>("Location"); }
            set { SetPropertyValue("Location", value); }
        }

        [Custom("Caption", "发现时间")]
        public DateTime FindOn
        {
            get { return GetPropertyValue<DateTime>("FindOn"); }
            set { SetPropertyValue("FindOn", value); }
        }

        //相关环境信息 埋藏环境： 温度-含水率-ph值-埋藏深度-其他
        [Custom("Caption", "温度")]
        public string Temperature
        {
            get { return GetPropertyValue<string>("Temperature"); }
            set { SetPropertyValue("Temperature", value); }
        }

        [Custom("Caption", "含水率")]
        public string Watery
        {
            get { return GetPropertyValue<string>("Watery"); }
            set { SetPropertyValue("Watery", value); }
        }

        [Custom("Caption", "PH值")]
        public string PH
        {
            get { return GetPropertyValue<string>("PH"); }
            set { SetPropertyValue("PH", value); }
        }

        [Custom("Caption", "埋藏深度")]
        public string Depth
        {
            get { return GetPropertyValue<string>("Depth"); }
            set { SetPropertyValue("Depth", value); }
        }

        [Size(3000)]
        [Custom("Caption", "埋藏环境-其他")]
        public string AmbushOther
        {
            get { return GetPropertyValue<string>("Temperature"); }
            set { SetPropertyValue("Temperature", value); }
        }

        //相关环境信息 发掘出土环境： 现场温度日变化记录-现场湿度日变化记录-照度水平-考古发掘现场其他防护措施
        [Size(10000)]
        [Custom("Caption", "现场温度日变化记录")]
        public string TemperatureChanged
        {
            get { return GetPropertyValue<string>("Temperature"); }
            set { SetPropertyValue("Temperature", value); }
        }
        [Size(10000)]
        [Custom("Caption", "现场湿度日变化记录")]
        public string HumidityChanged
        {
            get { return GetPropertyValue<string>("HumidityChanged"); }
            set { SetPropertyValue("HumidityChanged", value); }
        }

        [Custom("Caption", "照度水平")]
        public string Illumination
        {
            get { return GetPropertyValue<string>("Illumination"); }
            set { SetPropertyValue("Illumination", value); }
        }
        [Size(10000)]
        [Custom("Caption", "考古发掘现场其他防护措施")]
        public string OtherProtection
        {
            get { return GetPropertyValue<string>("OtherProtection"); }
            set { SetPropertyValue("OtherProtection", value); }
        }


        //样品采集信息 
        [Custom("Caption", "样品采集信息")]
        [Association("Protection-ProtectionSample", typeof(ProtectionSample))]
        public XPCollection ProtectionSample
        {
            get { return GetCollection("ProtectionSample"); }
        }

        //保护处理人员 技术负责人

        [Association("Protection-Worker", typeof(Worker))]
        [Custom("Caption", "保护处理人员")]
        public XPCollection Worker
        {
            get { return GetCollection("Worker"); }
        }

        [Custom("Caption", "技术负责人")]
        public Worker Leader
        {
            get { return GetPropertyValue<Worker>("Leader"); }
            set { SetPropertyValue("Leader", value); }
        }

        //文物保存现状
        [Size(10000)]
        [Custom("Caption", "文物保存现状")]
        public string CurrentSituation
        {
            get { return GetPropertyValue<string>("CurrentSituation"); }
            set { SetPropertyValue("CurrentSituation", value); }
        }

        //现场处理方法及步骤
        [Size(20000)]
        [Custom("Caption", "现场处理方法及步骤")]
        public string LiveMake
        {
            get { return GetPropertyValue<string>("LiveMake"); }
            set { SetPropertyValue("LiveMake", value); }
        }
        
        
        //文物临时存储微环境变化记录
        [Size(10000)]
        [Custom("Caption", "文物临时存储微环境变化记录")]
        public string MicroEnvironment
        {
            get { return GetPropertyValue<string>("MicroEnvironment"); }
            set { SetPropertyValue("MicroEnvironment", value); }
        }

        //文物包装盒运输的方法及步骤
        [Size(10000)]
        [Custom("Caption", "文物包装盒运输的方法及步骤")]
        public string Transfer
        {
            get { return GetPropertyValue<string>("Transfer"); }
            set { SetPropertyValue("Transfer", value); }
        }
      
        
        // 保护处理所使用的化学材料及试剂
        [Size(10000)]
        [Custom("Caption", "保护处理所使用的化学材料及试剂")]
        public string ChemistryMaterial
        {
            get { return GetPropertyValue<string>("Material"); }
            set { SetPropertyValue("Material", value); }
        }

        //保护处理所使用的其他材料
        [Size(10000)]
        [Custom("Caption", "保护处理所使用的其他材料")]
        public string OtherChemistryMaterial
        {
            get { return GetPropertyValue<string>("OtherChemistryMaterial"); }
            set { SetPropertyValue("OtherChemistryMaterial", value); }
        }


        //文物接受单位
        [Custom("Caption", "文物接受单位")]
        public PDepartment ReceiveBy
        {
            get { return GetPropertyValue<PDepartment>("ReceiveBy"); }
            set { SetPropertyValue("ReceiveBy", value); }
        }

        //备注
        [Size(10000)]
        [Custom("Caption", "备注")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        //附录 
        //照片 一对多
        [Custom("Caption", "照片编号")]
        [Association("Protection-ProtectionPhoto", typeof(ProtectionPhoto))]
        public XPCollection ProtectionPhoto
        {
            get { return GetCollection("ProtectionPhoto"); }
        }


        // 样品分析检测结果 一对多
        [Custom("Caption", "样品分析检测结果")]
        [Association("Protection-ProtectionSampleResult", typeof(ProtectionSampleResult))]
        public XPCollection ProtectionSampleResult
        {
            get { return GetCollection("ProtectionSampleResult"); }
        }

    }

}
