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
    [Custom("Caption", "遗迹-附属设施")]
    [System.ComponentModel.DefaultProperty("Id")]
    [DefaultClassOptions]
    public class SurveyAddition : BaseObject
    {
        public SurveyAddition(Session session) : base(session) { }

        [Custom("Caption", "所属遗迹")]
        public string FeatureId
        {
           get
           {
               if (GetPropertyValue<SurveyFeatureSettlement>("SurveyFeatureSettlement") != null)
               { return GetPropertyValue<SurveyFeatureSettlement>("SurveyFeatureSettlement").ToString(); }
               else if (GetPropertyValue<SurveyFeatureAlignment>("SurveyFeatureAlignment") != null)
               { return GetPropertyValue<SurveyFeatureAlignment>("SurveyFeatureAlignment").ToString(); }
               else if (GetPropertyValue<SurveyFeatureDeerStone>("SurveyFeatureDeerStone") != null)
               { return GetPropertyValue<SurveyFeatureDeerStone>("SurveyFeatureDeerStone").ToString(); }
               else if (GetPropertyValue<SurveyFeatureTomb>("SurveyFeatureTomb") != null)
               { return GetPropertyValue<SurveyFeatureTomb>("SurveyFeatureTomb").ToString(); }

                else return null;
            }
        }

        [Custom("Caption", "对应居址遗迹编号")]
        [Association("SurveyFeatureSettlement-SurveyAddition", typeof(SurveyFeatureSettlement))]
        public SurveyFeatureSettlement SurveyFeSurveyFeatureSettlementatureTomb
        {
            get { return GetPropertyValue<SurveyFeatureSettlement>("SurveyFeatureSettlement"); }
            set { SetPropertyValue("SurveyFeatureSettlement", value); }
        }

        [Custom("Caption", "对应列石遗迹编号")]
        [Association("SurveyFeatureAlignment-SurveyAddition", typeof(SurveyFeatureAlignment))]
        public SurveyFeatureAlignment SurveyFeatureAlignment
        {
            get { return GetPropertyValue<SurveyFeatureAlignment>("SurveyFeatureAlignment"); }
            set { SetPropertyValue("SurveyFeatureAlignment", value); }
        }

        [Custom("Caption", "对应鹿石遗迹编号")]
        [Association("SurveyFeatureDeerStone-SurveyAddition", typeof(SurveyFeatureDeerStone))]
        public SurveyFeatureDeerStone SurveyFeatureDeerStone
        {
            get { return GetPropertyValue<SurveyFeatureDeerStone>("SurveyFeatureDeerStone"); }
            set { SetPropertyValue("SurveyFeatureDeerStone", value); }
        }

        [Custom("Caption", "对应墓葬遗迹编号")]
        [Association("SurveyFeatureTomb-SurveyAddition", typeof(SurveyFeatureTomb))]
        public SurveyFeatureTomb SurveyFeatureTomb
        {
            get { return GetPropertyValue<SurveyFeatureTomb>("SurveyFeatureTomb"); }
            set { SetPropertyValue("SurveyFeatureTomb", value); }
        }


        [Custom("Caption", "位置")]
        public string Location
        {
            get { return GetPropertyValue<string>("Location"); }
            set { SetPropertyValue("Location", value); }
        }

        [Custom("Caption", "类别")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "数量")]
        public string Number
        {
            get { return GetPropertyValue<string>("Number"); }
            set { SetPropertyValue("Number", value); }
        }

        [Custom("Caption", "编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }
    }

    [Custom("Caption", "居址-单体描述")]
    [System.ComponentModel.DefaultProperty("Id")]
    [DefaultClassOptions]
    public class SurveySettlementSingle : BaseObject
    {
        public SurveySettlementSingle(Session session) : base(session) { }

        [Custom("Caption", "所属居址")]
        [Association("SurveyFeatureSettlement-SurveySettlementSingle", typeof(SurveyFeatureSettlement))]
        public SurveyFeatureSettlement SurveyFeatureSettlement
        {
            get { return GetPropertyValue<SurveyFeatureSettlement>("SurveyFeatureSettlement"); }
            set { SetPropertyValue("SurveyFeatureSettlement", value); }
        }

        //居址体量
        //外廓 长宽高m 墙基列数

        [Custom("Caption", "外廓-长（m）")]
        public float OutlineLength
        {
            get { return GetPropertyValue<float>("OutlineLength"); }
            set { SetPropertyValue("OutlineLength", value); }
        }

        [Custom("Caption", "外廓-宽（m）")]
        public float OutlineWidth
        {
            get { return GetPropertyValue<float>("OutlineWidth"); }
            set { SetPropertyValue("OutlineWidth", value); }
        }

        [Custom("Caption", "外廓-高（m）")]
        public float OutlineHeight
        {
            get { return GetPropertyValue<float>("OutlineHeight"); }
            set { SetPropertyValue("OutlineHeight", value); }
        }

        [Custom("Caption", "墙基列数")]
        public int WallRootNumber
        {
            get { return GetPropertyValue<int>("WallRootNumber"); }
            set { SetPropertyValue("WallRootNumber", value); }
        }

        //内径 长宽高 深度m

        [Custom("Caption", "内径-长（m）")]
        public float InnerLength
        {
            get { return GetPropertyValue<float>("InnerLength"); }
            set { SetPropertyValue("InnerLength", value); }
        }

        [Custom("Caption", "内径-宽（m）")]
        public float InnerWidth
        {
            get { return GetPropertyValue<float>("InnerWidth"); }
            set { SetPropertyValue("InnerWidth", value); }
        }

        [Custom("Caption", "内径-高（m）")]
        public float InnerHeight
        {
            get { return GetPropertyValue<float>("InnerHeight"); }
            set { SetPropertyValue("InnerHeight", value); }
        }

        [Custom("Caption", "内径-深（m）")]
        public float InnerDepth
        {
            get { return GetPropertyValue<float>("InnerDepth"); }
            set { SetPropertyValue("InnerDepth", value); }
        }
        //门道 位置 数量 宽度m

        [Custom("Caption", "门道-位置")]
        public string DoorwayLocation
        {
            get { return GetPropertyValue<string>("DoorwayLocation"); }
            set { SetPropertyValue("DoorwayLocation", value); }
        }

        [Custom("Caption", "门道-数量")]
        public int DoorwayQuantity
        {
            get { return GetPropertyValue<int>("DoorwayQuantity"); }
            set { SetPropertyValue("DoorwayQuantity", value); }
        }

        [Custom("Caption", "门道-宽度")]
        public float DoorwayWidth
        {
            get { return GetPropertyValue<float>("DoorwayWidth"); }
            set { SetPropertyValue("DoorwayWidth", value); }
        }
        //堆积描述 
        //石 形状 颜色 石质 尺寸
        [Custom("Caption", "石-形状")]
        public string StoneShape
        {
            get { return GetPropertyValue<string>("StoneShape"); }
            set { SetPropertyValue("StoneShape", value); }
        }

        [Custom("Caption", "石-颜色")]
        public string StoneColor
        {
            get { return GetPropertyValue<string>("StoneColor"); }
            set { SetPropertyValue("StoneColor", value); }
        }

        [Custom("Caption", "石质")]
        public string StoneTexture
        {
            get { return GetPropertyValue<string>("StoneTexture"); }
            set { SetPropertyValue("StoneTexture", value); }
        }

        [Custom("Caption", "石-尺寸")]
        public string StoneSize
        {
            get { return GetPropertyValue<string>("StoneSize"); }
            set { SetPropertyValue("StoneSize", value); }
        }
        //土 土质 土色 包含物 

        [Custom("Caption", "土-土质")]
        public string SoilTexture
        {
            get { return GetPropertyValue<string>("SoilTexture"); }
            set { SetPropertyValue("SoilTexture", value); }
        }

        [Custom("Caption", "土-土色")]
        public string SoilColor
        {
            get { return GetPropertyValue<string>("SoilColor"); }
            set { SetPropertyValue("SoilColor", value); }
        }

        [Custom("Caption", "土-包含物")]
        public string SoilContain
        {
            get { return GetPropertyValue<string>("SoilContain"); }
            set { SetPropertyValue("SoilContain", value); }
        }
        //堆积描述 其他

        [Custom("Caption", "其他")]
        public string Other
        {
            get { return GetPropertyValue<string>("Other"); }
            set { SetPropertyValue("Other", value); }
        }
    }
}
