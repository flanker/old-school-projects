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
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Id")]
    [Custom("Caption", "调查居址登记")]
    public class SurveyFeatureSettlement : BaseObject
    {
        public SurveyFeatureSettlement(Session session) : base(session) { }

        //记录人 记录时间
        [Custom("Caption", "记录人")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("Caption", "记录日期")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        //天气
        [Custom("Caption", "天气")]
        public string Weather
        {
            get { return GetPropertyValue<string>("Weather"); }
            set { SetPropertyValue("Weather", value); }
        }

        //遗址名称
        [Custom("Caption", "遗址名称")]
        public string SiteBelong
        {
            get { return GetPropertyValue<string>("SiteBelong"); }
            set { SetPropertyValue("SiteBelong", value); }
        }

        //遗址编号
        [Custom("Caption", "遗址编号")]
        public string SiteId
        {
            get { return GetPropertyValue<string>("SiteId"); }
            set { SetPropertyValue("SiteId", value); }
        }

        //调查方法
        [Custom("Caption", "调查方法")]
        public SurveyMethod SurveyMethod
        {
            get { return GetPropertyValue<SurveyMethod>("SurveyMethod"); }
            set { SetPropertyValue("SurveyMethod", value); }
        }

        //分区编号
        [Custom("Caption", "分区编号")]
        public string GridId
        {
            get { return GetPropertyValue<string>("GridId"); }
            set { SetPropertyValue("GridId", value); }
        }

        //墓葬编号
        [Custom("Caption", "居址编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        //位置
        [Custom("Caption", "位置")]
        public string Location
        {
            get { return GetPropertyValue<string>("Location"); }
            set { SetPropertyValue("Location", value); }
        }
        //经纬坐标N E H
        [Custom("Caption", "N")]
        public float N
        {
            get { return GetPropertyValue<float>("N"); }
            set { SetPropertyValue("N", value); }
        }

        [Custom("Caption", "E")]
        public float E
        {
            get { return GetPropertyValue<float>("E"); }
            set { SetPropertyValue("E", value); }
        }

        [Custom("Caption", "H")]
        public float H
        {
            get { return GetPropertyValue<float>("H"); }
            set { SetPropertyValue("H", value); }
        }
        //全站仪坐标X Y Z
        [Custom("Caption", "X")]
        public float X
        {
            get { return GetPropertyValue<float>("X"); }
            set { SetPropertyValue("X", value); }
        }

        [Custom("Caption", "Y")]
        public float Y
        {
            get { return GetPropertyValue<float>("Y"); }
            set { SetPropertyValue("Y", value); }
        }

        [Custom("Caption", "Z")]
        public float Z
        {
            get { return GetPropertyValue<float>("Z"); }
            set { SetPropertyValue("Z", value); }
        }

        //测量位置
        [Custom("Caption", "测量位置")]
        public string SurveyDrawLocation
        {
            get { return GetPropertyValue<string>("SurveyDrawLocation"); }
            set { SetPropertyValue("SurveyDrawLocation", value); }
        }

        //测绘方式 全站仪 GPS
        [Custom("Caption", "测绘方式")]
        public SurveyDrawType SurveyDrawType
        {
            get { return GetPropertyValue<SurveyDrawType>("SurveyDrawType"); }
            set { SetPropertyValue("SurveyDrawType", value); }
        }

        //仪器型号
        [Custom("Caption", "仪器型号")]
        public string SurveyDrawTool
        {
            get { return GetPropertyValue<string>("SurveyDrawTool"); }
            set { SetPropertyValue("SurveyDrawTool", value); }
        }

        //测量精度 米
        [Custom("Caption", "测量精度（米）")]
        public string SurveyDrawDefinition
        {
            get { return GetPropertyValue<string>("SurveyDrawDefinition"); }
            set { SetPropertyValue("SurveyDrawDefinition", value); }
        }

        //调查人 一对多
        [Association("SurveyFeatureSettlement-Worker", typeof(Worker))]
        [Custom("Caption", "调查人")]
        public XPCollection Worker
        {
            get { return GetCollection("Worker"); }
        }

        //调查路线
        [Custom("Caption", "调查路线")]
        public string SurveyPath
        {
            get { return GetPropertyValue<string>("SurveyPath"); }
            set { SetPropertyValue("SurveyPath", value); }
        }

        //保存现状  好-较好-一般-较差-差
        [Custom("Caption", "保存现状")]
        public SurveyProtectionSituation SurveyProtectionSituation
        {
            get { return GetPropertyValue<SurveyProtectionSituation>("SurveyProtectionSituation"); }
            set { SetPropertyValue("SurveyProtectionSituation", value); }
        }

        //现状描述
        [Custom("Caption", "现状描述")]
        public string SituationDescription
        {
            get { return GetPropertyValue<string>("SituationDescription"); }
            set { SetPropertyValue("SituationDescription", value); }
        }

        //损毁原因 自然因素 人为因素
        [Custom("Caption", "自然因素")]
        public NatureDamageType NatureDamageType
        {
            get { return GetPropertyValue<NatureDamageType>("NatureDamageType"); }
            set { SetPropertyValue("NatureDamageType", value); }
        }

        [Custom("Caption", "人为因素")]
        public ArtifactDamageType ArtifactDamageType
        {
            get { return GetPropertyValue<ArtifactDamageType>("ArtifactDamageType"); }
            set { SetPropertyValue("ArtifactDamageType", value); }
        }

        //自然环境 地表覆盖物 覆盖率 地形地貌
        [Custom("Caption", "地表覆盖物")]
        public string SurveySurfaceCovering
        {
            get { return GetPropertyValue<string>("SurveySurfaceCovering"); }
            set { SetPropertyValue("SurveySurfaceCovering", value); }
        }

        [Custom("Caption", "覆盖率")]
        public int SurveySurfaceCoveringRate
        {
            get { return GetPropertyValue<int>("SurveySurfaceCoveringRate"); }
            set { SetPropertyValue("SurveySurfaceCoveringRate", value); }
        }

        [Custom("Caption", "地形地貌")]
        public string TerrainGround
        {
            get { return GetPropertyValue<string>("TerrainGround"); }
            set { SetPropertyValue("TerrainGround", value); }
        }

        //人文环境
        [Custom("Caption", "人文环境")]
        public string CultureEnvironment
        {
            get { return GetPropertyValue<string>("CultureEnvironment"); }
            set { SetPropertyValue("CultureEnvironment", value); }
        }

        //遗迹描述

        //层位关系
        [Custom("Caption", "层位关系")]
        public string LayerRelation
        {
            get { return GetPropertyValue<string>("LayerRelation"); }
            set { SetPropertyValue("LayerRelation", value); }
        }
        // 平面 侧面 剖面
        [Custom("Caption", "平面形状")]
        public SurveyPlaneShape PlaneShape
        {
            get { return GetPropertyValue<SurveyPlaneShape>("PlaneShape"); }
            set { SetPropertyValue("PlaneShape", value); }
        }

        [Custom("Caption", "侧面形状")]
        public SurveySideShape SideShape
        {
            get { return GetPropertyValue<SurveySideShape>("SideShape"); }
            set { SetPropertyValue("SideShape", value); }
        }

        [Custom("Caption", "剖面形状")]
        public SurveyProfileShape ProfileShape
        {
            get { return GetPropertyValue<SurveyProfileShape>("ProfileShape"); }
            set { SetPropertyValue("ProfileShape", value); }
        }

        //平面布局类型
        [Custom("Caption", "平面布局类型")]
        public string PlaneLayourType
        {
            get { return GetPropertyValue<string>("PlaneLayourType"); }
            set { SetPropertyValue("PlaneLayourType", value); }
        }

        //平面布局描述
        [Custom("Caption", "平面布局描述")]
        public string PlaneLayourDescription
        {
            get { return GetPropertyValue<string>("PlaneLayourDescription"); }
            set { SetPropertyValue("PlaneLayourDescription", value); }
        }
        //单体描述 一对多
        [Association("SurveyFeatureSettlement-SurveySettlementSingle", typeof(SurveySettlementSingle))]
        [Custom("Caption", "单体描述")]
        public XPCollection SurveySettlementSingle
        {
            get { return GetCollection("SurveySettlementSingle"); }
        }

        //遗迹结构

        [Custom("Caption", "遗迹结构")]
        public string Structure
        {
            get { return GetPropertyValue<string>("Structure"); }
            set { SetPropertyValue("Structure", value); }
        }


        //草图
        //[Custom("Caption", "草图")]
        //[DevExpress.Xpo.Size(SizeAttribute.Unlimited), ValueConverter(typeof(ImageValueConverter))]
        //[ImageEditor(DetailViewImageEditorMode = ImageEditorMode.PictureEdit)]
        //public Image Sketch
        //{
        //    get { return GetPropertyValue<Image>("Sketch"); }
        //    set { SetPropertyValue<Image>("Sketch", value); }
        //}

        [Custom("Caption", "草图")]
        public string Sketch
        {
            get { return GetPropertyValue<string>("Sketch"); }
            set { SetPropertyValue("Sketch", value); }
        }

        //附属设施 一对多
        [Association("SurveyFeatureSettlement-SurveyAddition", typeof(SurveyAddition))]
        [Custom("Caption", "附属设施")]
        public XPCollection SurveyAddition
        {
            get { return GetCollection("SurveyAddition"); }
        }

        //遗物采集  一对多 
        [Association("SurveyFeatureSettlement-SurveyRemainMark", typeof(SurveyRemainMark))]
        [Custom("Caption", "遗物采集")]
        public XPCollection SurveyRemainMark
        {
            get { return GetCollection("SurveyRemainMark"); }
        }


        //与周边遗迹关系
        [Custom("Caption", "与周边遗迹关系")]
        public string FeatureRelation
        {
            get { return GetPropertyValue<string>("FeatureRelation"); }
            set { SetPropertyValue("FeatureRelation", value); }
        }

        //性质判断 理由
        [Custom("Caption", "性质判断")]
        public string PropertyDetermine
        {
            get { return GetPropertyValue<string>("PropertyDetermine"); }
            set { SetPropertyValue("PropertyDetermine", value); }
        }

        [Custom("Caption", "性质判断-理由")]
        public string PropertyReason
        {
            get { return GetPropertyValue<string>("PropertyReason"); }
            set { SetPropertyValue("PropertyReason", value); }
        }

        //年代判断 理由
        [Custom("Caption", "年代判断")]
        public string AgeDetermine
        {
            get { return GetPropertyValue<string>("AgeDetermine"); }
            set { SetPropertyValue("AgeDetermine", value); }
        }

        [Custom("Caption", "年代判断-理由")]
        public string AgeReason
        {
            get { return GetPropertyValue<string>("AgeReason"); }
            set { SetPropertyValue("AgeReason", value); }
        }


        //调查绘图编号
        [Association("SurveyFeatureSettlement-SurveyPicture", typeof(SurveyPicture))]
        [Custom("Caption", "遗物采集")]
        public XPCollection SurveyPicture
        {
            get { return GetCollection("SurveyPicture"); }
        }

        //调查照相编号
        [Association("SurveyFeatureSettlement-SurveyDPhoto", typeof(SurveyDPhoto))]
        [Custom("Caption", "遗物采集")]
        public XPCollection SurveyDPhoto
        {
            get { return GetCollection("SurveyDPhoto"); }
        }
        //审核人 审核时间
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

    public enum PlaneLayourType { 未知, 单体, 多间复合式, 其他 }
}
