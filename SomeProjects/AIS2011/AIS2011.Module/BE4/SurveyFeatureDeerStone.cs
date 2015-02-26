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
    [Custom("Caption", "调查鹿石登记")]
    public class SurveyFeatureDeerStone : BaseObject
    {
        public SurveyFeatureDeerStone(Session session) : base(session) { }

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

        //鹿石编号
        [Custom("Caption", "鹿石编号")]
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

        //调查人 多对多
        [Association("SurveyFeatureDeerStone-Worker", typeof(Worker))]
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
        //石质-颜色-立面形状-断面形状
        [Custom("Caption", "石质")]
        public string Texture
        {
            get { return GetPropertyValue<string>("Texture"); }
            set { SetPropertyValue("Texture", value); }
        }

        [Custom("Caption", "颜色")]
        public string Color
        {
            get { return GetPropertyValue<string>("Color"); }
            set { SetPropertyValue("Color", value); }
        }


        [Custom("Caption", "立面形状")]
        public string ElevationShape
        {
            get { return GetPropertyValue<string>("ElevationShape"); }
            set { SetPropertyValue("ElevationShape", value); }
        }

        [Custom("Caption", "断面形状")]
        public string SectionShape
        {
            get { return GetPropertyValue<string>("SectionShape"); }
            set { SetPropertyValue("SectionShape", value); }
        }

        //材料选取:自然巨石/人工加工
        [Custom("Caption", "材料选取")]
        public SurveyDeerStoneMaterial SurveyDeerStoneMaterial
        {
            get { return GetPropertyValue<SurveyDeerStoneMaterial>("SurveyDeerStoneMaterial"); }
            set { SetPropertyValue("SurveyDeerStoneMaterial", value); }
        }

        //制作方法 雕琢/磨制
        [Custom("Caption", "制作方法")]
        public SurveyDeerStoneMethod SurveyDeerStoneMethod
        {
            get { return GetPropertyValue<SurveyDeerStoneMethod>("SurveyDeerStoneMethod"); }
            set { SetPropertyValue("SurveyDeerStoneMethod", value); }
        }
        
        //尺寸 地表部分 长厚高cm 地下部分 长厚高cm
        [Custom("Caption", "地表部分-长（m）")]
        public float GroundLength
        {
            get { return GetPropertyValue<float>("GroundLength"); }
            set { SetPropertyValue("GroundLength", value); }
        }

        [Custom("Caption", "地表部分-厚（m）")]
        public float GroundThickness
        {
            get { return GetPropertyValue<float>("GroundThickness"); }
            set { SetPropertyValue("GroundThickness", value); }
        }

        [Custom("Caption", "地表部分-高（m）")]
        public float GroundHeight
        {
            get { return GetPropertyValue<float>("GroundHeight"); }
            set { SetPropertyValue("GroundHeight", value); }
        }
        [Custom("Caption", "地下部分-长（m）")]
        public float UnderGroundLength
        {
            get { return GetPropertyValue<float>("UnderGroundLength"); }
            set { SetPropertyValue("UnderGroundLength", value); }
        }

        [Custom("Caption", "地下部分-厚（m）")]
        public float UnderGroundThickness
        {
            get { return GetPropertyValue<float>("UnderGroundThickness"); }
            set { SetPropertyValue("UnderGroundThickness", value); }
        }

        [Custom("Caption", "地下部分-高（m）")]
        public float UnderGroundHeight
        {
            get { return GetPropertyValue<float>("UnderGroundHeight"); }
            set { SetPropertyValue("UnderGroundHeight", value); }
        }

        //图案描述 
        //图案内容 动物纹 装饰纹 武器工具 
        [Custom("Caption", "动物纹")]
        public SurveyDeerStoneAnimal SurveyDeerStoneAnimal
        {
            get { return GetPropertyValue<SurveyDeerStoneAnimal>("SurveyDeerStoneAnimal"); }
            set { SetPropertyValue("SurveyDeerStoneAnimal", value); }
        }


        [Custom("Caption", "装饰纹")]
        public SurveyDeerStoneAdornment SurveyDeerStoneAdornment
        {
            get { return GetPropertyValue<SurveyDeerStoneAdornment>("SurveyDeerStoneAdornment"); }
            set { SetPropertyValue("SurveyDeerStoneAdornment", value); }
        }

        [Custom("Caption", "武器工具")]
        public SurveyDeerStoneArm SurveyDeerStoneArm
        {
            get { return GetPropertyValue<SurveyDeerStoneArm>("SurveyDeerStoneArm"); }
            set { SetPropertyValue("SurveyDeerStoneArm", value); }
        }

        //各面描述 前面 左侧面 右侧面 背面
        [Custom("Caption", "前面描述")]
        public string FrontDescription
        {
            get { return GetPropertyValue<string>("FrontDescription"); }
            set { SetPropertyValue("FrontDescription", value); }
        }

        [Custom("Caption", "左侧面描述")]
        public string LeftSideDescription
        {
            get { return GetPropertyValue<string>("LeftSideDescription"); }
            set { SetPropertyValue("LeftSideDescription", value); }
        }

        [Custom("Caption", "右侧面描述")]
        public string RightSideDescription
        {
            get { return GetPropertyValue<string>("RightSideDescription"); }
            set { SetPropertyValue("RightSideDescription", value); }
        }

        [Custom("Caption", "背面描述")]
        public string BackDescription
        {
            get { return GetPropertyValue<string>("BackDescription"); }
            set { SetPropertyValue("BackDescription", value); }
        }

        //总述
        [Custom("Caption", "总述")]
        public string Total
        {
            get { return GetPropertyValue<string>("Total"); }
            set { SetPropertyValue("Total", value); }
        }

        //附属设施 一对多
        [Association("SurveyFeatureDeerStone-SurveyAddition", typeof(SurveyAddition))]
        [Custom("Caption", "附属设施")]
        public XPCollection SurveyAddition
        {
            get { return GetCollection("SurveyAddition"); }
        }

        //遗物采集  一对多 
        [Association("SurveyFeatureDeerStone-SurveyRemainMark", typeof(SurveyRemainMark))]
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
        [Association("SurveyFeatureDeerStone-SurveyPicture", typeof(SurveyPicture))]
        [Custom("Caption", "遗物采集")]
        public XPCollection SurveyPicture
        {
            get { return GetCollection("SurveyPicture"); }
        }

        //调查照相编号
        [Association("SurveyFeatureDeerStone-SurveyDPhoto", typeof(SurveyDPhoto))]
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
    public enum SurveyDeerStoneMaterial {未知, 自然巨石, 人工加工 }
    public enum SurveyDeerStoneMethod { 未知, 雕凿, 磨制 }

    public enum SurveyDeerStoneAnimal { 未知, 自然写实性鹿纹样, 图案化装饰性鹿纹样, 马, 牛, 羊, 驴, 虎, 豹, 狼, 鸟类, 野猪, 其它 }
    public enum SurveyDeerStoneAdornment { 未知, 带饰, 耳环, 项饰, 铜镜, 连珠纹, 日, 月, 其它 }
    public enum SurveyDeerStoneArm { 未知, 剑, 斧, 弓囊, 刀, 盾, 砺石, 权杖, 弓, 弓形勾, 其它 }

}
