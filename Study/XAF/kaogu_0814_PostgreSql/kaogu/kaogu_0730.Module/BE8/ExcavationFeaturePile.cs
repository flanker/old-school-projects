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
    [System.ComponentModel.DefaultProperty("Id")]
    [Custom("Caption", "堆状遗迹登记")]
    public class ExcavationFeaturePile : BaseObject
    {
        public ExcavationFeaturePile(Session session) : base(session) { }

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

        [Custom("Caption", "所属遗址")]
        public string BelongSite
        {
            get { return GetPropertyValue<string>("BelongSite"); }
            set { SetPropertyValue("BelongSite", value); }
        }

        [Custom("Caption", "堆状遗迹编号")]
        public String Id
        {
            get { return GetPropertyValue<String>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "是否主从")]
        public IsMainOrPart MainOrPart
        {
            get { return GetPropertyValue<IsMainOrPart>("MainOrPart"); }
            set { SetPropertyValue("MainOrPart", value); }
        }


        [Association("ExcavationFeaturePile-Worker", typeof(Worker))]
        [Custom("Caption", "发掘人员")]
        public XPCollection Worker
        {
            get { return GetCollection("Worker"); }
        }


        [Custom("Caption", "发掘日期起")]
        public DateTime StartOn
        {
            get { return GetPropertyValue<DateTime>("StartOn"); }
            set { SetPropertyValue("StartOn", value); }
        }

        [Custom("Caption", "发掘日期终")]
        public DateTime EndOn
        {
            get { return GetPropertyValue<DateTime>("EndOn"); }
            set { SetPropertyValue("EndOn", value); }
        }

        [Custom("Caption", "用工")]
        public string FWorker
        {
            get { return GetPropertyValue<string>("FWorker"); }
            set { SetPropertyValue("EndOn", value); }
        }


        //地面位置
        [Custom("Caption", "地理坐标")]
        public string GPS
        {
            get { return GetPropertyValue<string>("GPS"); }
            set { SetPropertyValue("GPS", value); }
        }

        [Custom("Caption", "测量位置描述一")]
        public string GPSDescription
        {
            get { return GetPropertyValue<string>("GPSDescription"); }
            set { SetPropertyValue("GPSDescription", value); }
        }

        [Custom("Caption", "发掘坐标")] //全站仪
        public string TotalStation
        {
            get { return GetPropertyValue<string>("TotalStation"); }
            set { SetPropertyValue("TotalStation", value); }
        }

        [Custom("Caption", "测量位置描述二")]
        public string TotalStationDescription
        {
            get { return GetPropertyValue<string>("TotalStationDescription"); }
            set { SetPropertyValue("TotalStationDescription", value); }
        }

        [Custom("Caption", "所属遗迹")]
        public string BelongFeature
        {
            get { return GetPropertyValue<string>("BelongFeature"); }
            set { SetPropertyValue("BelongFeature", value); }
        }
        //基本信息
        //自然环境
        [Custom("Caption", "地形")]
        public string Terrain
        {
            get { return GetPropertyValue<string>("Terrain"); }
            set { SetPropertyValue("Terrain", value); }
        }

        [Custom("Caption", "地貌")]
        public string Landform
        {
            get { return GetPropertyValue<string>("Landform"); }
            set { SetPropertyValue("Landform", value); }
        }

        [Custom("Caption", "水文")]
        public string Hydrology
        {
            get { return GetPropertyValue<string>("Hydrology"); }
            set { SetPropertyValue("Hydrology", value); }
        }

        [Custom("Caption", "植被")]
        public string Vege
        {
            get { return GetPropertyValue<string>("Vege"); }
            set { SetPropertyValue("Vege", value); }
        }

        [Custom("Caption", "保存状况")]
        public string KeepState
        {
            get { return GetPropertyValue<string>("KeepState"); }
            set { SetPropertyValue("KeepState", value); }
        }

        [Custom("Caption", "清理方式")]
        public string CleanType
        {
            get { return GetPropertyValue<string>("CleanType"); }
            set { SetPropertyValue("CleanType", value); }
        }

        [Custom("Caption", "分布位置")]
        public string SpreadLocation
        {
            get { return GetPropertyValue<string>("SpreadLocation"); }
            set { SetPropertyValue("SpreadLocation", value); }
        }

        //与周临遗迹层位及位置关系 多对多
        [Custom("Caption", "与周临遗迹层位及位置关系")]
        [Association("ExcavationFeaturePile-Layer", typeof(Layer))]
        public XPCollection Layer
        {
            get { return GetCollection("Layer"); }
        }

        [Custom("Caption", "文字描述")]
        public string LayerDescription
        {
            get { return GetPropertyValue<string>("LayerDescription"); }
            set { SetPropertyValue("LayerDescription", value); }
        }


        //独立
        [Custom("Caption", "附属遗迹")]
        public string AdditionFeature
        {
            get { return GetPropertyValue<string>("AdditionFeature"); }
            set { SetPropertyValue("AdditionFeature", value); }
        }

        //地表建筑

        // 地表坡度
        [Custom("Caption", "地表坡度方向")]
        public string LandSlopeLocation
        {
            get { return GetPropertyValue<string>("LandSlopeLocation"); }
            set { SetPropertyValue("LandSlopeLocation", value); }
        }
        [Custom("Caption", "地表坡度角度")]
        public int LandSlopeDegree
        {
            get { return GetPropertyValue<int>("LandSlopeDegree"); }
            set { SetPropertyValue("LandSlopeDegree", value); }
        }

        [Custom("Caption", "平面形状")]
        public string PlaneShape
        {
            get { return GetPropertyValue<string>("PlaneShape"); }
            set { SetPropertyValue("PlaneShape", value); }
        }

        [Custom("Caption", "侧面形状")]
        public string SideShape
        {
            get { return GetPropertyValue<string>("SideShape"); }
            set { SetPropertyValue("SideShape", value); }
        }

        [Custom("Caption", "剖面形状")]
        public string ProfileShape
        {
            get { return GetPropertyValue<string>("ProfileShape"); }
            set { SetPropertyValue("ProfileShape", value); }
        }

        //体量
        //整体 
        [Custom("Caption", "是否长或直径")]
        public IsLengthOrDiameter SIzeEntireIsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("SIzeEntireIsLengthOrDiameter"); }
            set { SetPropertyValue("SIzeEntireIsLengthOrDiameter", value); }
        }


        [Custom("Caption", "长/直径")]
        public float SizeEntireLength
        {
            get { return GetPropertyValue<float>("SizeEntireLength"); }
            set { SetPropertyValue("SizeEntireLength", value); }
        }

        [Custom("Caption", "宽")]
        public float SizeEntireWidth
        {
            get { return GetPropertyValue<float>("SizeEntireWidth"); }
            set { SetPropertyValue("SizeEntireWidth", value); }
        }

        [Custom("Caption", "高")]
        public float SizeEntireHeight
        {
            get { return GetPropertyValue<float>("SizeEntireHeight"); }
            set { SetPropertyValue("SizeEntireHeight", value); }
        }

        //凹陷

        [Custom("Caption", "是否长或直径")]
        public IsLengthOrDiameter SIzeSunkerIsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("SIzeSunkerIsLengthOrDiameter"); }
            set { SetPropertyValue("SIzeSunkerIsLengthOrDiameter", value); }
        }
        [Custom("Caption", "长/直径")]
        public float SizeSunkerLength
        {
            get { return GetPropertyValue<float>("SizeSunkerLength"); }
            set { SetPropertyValue("SizeSunkerLength", value); }
        }

        [Custom("Caption", "宽")]
        public float SizeSunkerWidth
        {
            get { return GetPropertyValue<float>("SizeSunkerWidth"); }
            set { SetPropertyValue("SizeSunkerWidth", value); }
        }

        [Custom("Caption", "深")]
        public float SizeSunkerDepth
        {
            get { return GetPropertyValue<float>("SizeSunkerDepth"); }
            set { SetPropertyValue("SizeSunkerDepth", value); }
        }

        //覆盖物
        //石块
        [Custom("Caption", "范围")]
        public string StoneRange
        {
            get { return GetPropertyValue<string>("StoneRange"); }
            set { SetPropertyValue("StoneRange", value); }
        }

        [Custom("Caption", "质地")]
        public string StoneQuality
        {
            get { return GetPropertyValue<string>("StoneQuality"); }
            set { SetPropertyValue("StoneQuality", value); }
        }


        [Custom("Caption", "颜色")]
        public string StoneColor
        {
            get { return GetPropertyValue<string>("StoneColor"); }
            set { SetPropertyValue("StoneColor", value); }
        }

        [Custom("Caption", "比例")]
        public string StoneProportion
        {
            get { return GetPropertyValue<string>("StoneProportion"); }
            set { SetPropertyValue("StoneProportion", value); }
        }

        [Custom("Caption", "分选度")]
        public int StoneClassification
        {
            get { return GetPropertyValue<int>("StoneClassification"); }
            set { SetPropertyValue("StoneClassification", value); }
        }

        [Custom("Caption", "磨圆度")]
        public int StoneSmooth
        {
            get { return GetPropertyValue<int>("StoneSmooth"); }
            set { SetPropertyValue("StoneSmooth", value); }
        }

        [Custom("Caption", "最小尺寸")]
        public float StoneMinSize
        {
            get { return GetPropertyValue<float>("StoneMinSize"); }
            set { SetPropertyValue("StoneMinSize", value); }
        }

        [Custom("Caption", "最大尺寸")]
        public float StoneMaxSize
        {
            get { return GetPropertyValue<float>("StoneMaxSize"); }
            set { SetPropertyValue("StoneMaxSize", value); }
        }

        [Custom("Caption", "平均尺寸")]
        public float StoneAverageSize
        {
            get { return GetPropertyValue<float>("StoneAverageSize"); }
            set { SetPropertyValue("StoneAverageSize", value); }
        }

        //植物 一对多
        [Custom("Caption", "植物(范围-种类-颜色-高度-比例)")]
        [Association("ExcavationFeaturePile-Vegetation", typeof(Vegetation))]
        public XPCollection Vegetation
        {
            get { return GetCollection("Vegetation"); }
        }

        //堆积
        [Custom("Caption", "堆积")]

        [Association("ExcavationFeaturePile-Accumulation", typeof(Accumulation))]
        public XPCollection Accumulation
        {
            get { return GetCollection("Accumulation"); }
        }

        //出土物
        [Custom("Caption", "出土物")]

        [Association("ExcavationFeaturePile-RemainMark", typeof(RemainMark))]
        public XPCollection RemainMark
        {
            get { return GetCollection("RemainMark"); }
        }



        //注意：概述地表建筑整体的形状、体量、各层堆积情况；列举理由推断墓葬地表建筑的建筑方式（建筑材料、建筑过程）。
        [Custom("Caption", "描述")]
        public string SurfaceBuildingDescription
        {
            get { return GetPropertyValue<string>("SurfaceBuildingDescription"); }
            set { SetPropertyValue("SurfaceBuildingDescription", value); }
        }

        //下部建筑

        [Custom("Caption", "特殊建筑结构以及人工痕迹")]

        [Association("ExcavationFeaturePile-SpacialBuildingStructureAndArtificialVestige",
            typeof(SpacialBuildingStructureAndArtificialVestige))]
        public XPCollection SpacialBuildingStructureAndArtificialVestige
        {
            get { return GetCollection("SpacialBuildingStructureAndArtificialVestige"); }
        } 

        //注意：概述下部建筑形状、体量、各层堆积情况及特殊建筑结构和人工遗迹现象；
        //列举理由推断堆状遗迹的建筑方式及堆积形成的过程。
        [Custom("Caption","描述")]
        public string UnderBuildingDescription
        {
            get { return GetPropertyValue<string>("UnderBuildingDescription"); }
            set { SetPropertyValue("UnderBuildingDescription", value); }
        }

        //出土物

        //迹象
        //迹象
        [Custom("Caption", "迹象")]
        [Association("ExcavationFeaturePile-Sign", typeof(Sign))]
        public XPCollection Sign
        {
            get { return GetCollection("Sign"); }
        }

        [Custom("Caption", "各迹象相互关系")]
        public string SignRelation
        {
            get { return GetPropertyValue<string>("SignRelation"); }
            set { SetPropertyValue("SignRelation", value); }
        }



        [Custom("Caption", "性质判断及理由")]
        public string PropertyAndReason
        {
            get { return GetPropertyValue<string>("PropertyAndReason"); }
            set { SetPropertyValue("PropertyAndReason", value); }
        }

        [Custom("Caption", "与周临迹象组合关系及理由")]
        public string SignComponentAndReason
        {
            get { return GetPropertyValue<string>("SignComponentAndReason"); }
            set { SetPropertyValue("SignComponentAndReason", value); }
        }

        [Custom("Caption", "遗迹评价及工作总结")]
        public string Summary
        {
            get { return GetPropertyValue<string>("Summary"); }
            set { SetPropertyValue("Summary", value); }
        }

        [Custom("Caption", "备注")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

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
}
