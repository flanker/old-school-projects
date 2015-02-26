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
    [Custom("Caption", "堆积登记")]
    public class Accumulation : BaseObject
    {
        public Accumulation(Session session) : base(session) { }

        [Custom("Caption", "记录人")]
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

        //所属遗址

        //遗迹编号
        [Custom("Caption", "遗迹编号")]
        public FeatureMark FeatureMark
        {
            get { return GetPropertyValue<FeatureMark>("FeatureMark"); }
            set { SetPropertyValue("FeatureMark", value); }
        }

        [Custom("Caption", "堆积编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        //遗迹主从
        [Custom("Caption", "是否主从")]
        public IsMainOrPart MainOrPart
        {
            get { return GetPropertyValue<IsMainOrPart>("MainOrPart"); }
            set { SetPropertyValue("MainOrPart", value); }
        }

        [Association("Accumulation-Worker", typeof(Worker))]
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

        [Custom("Caption", "所属遗迹？")]
        public string BelongFeature
        {
            get { return GetPropertyValue<string>("BelongFeature"); }
            set { SetPropertyValue("BelongFeature", value); }
        }

        [Custom("Caption", "保存状况")]
        public string Protection
        {
            get { return GetPropertyValue<string>("Protection"); }
            set { SetPropertyValue("Protection", value); }
        }

        [Custom("Caption", "清理方式")]
        public string CleanType
        {
            get { return GetPropertyValue<string>("CleanType"); }
            set { SetPropertyValue("CleanType", value); }
        }

        [Custom("Caption", "分布范围")]
        public string SpreadScope
        {
            get { return GetPropertyValue<string>("SpreadScope"); }
            set { SetPropertyValue("SpreadScope", value); }
        }

        //形状shape

        [Custom("Caption", "平面形状")]
        public AccPlaneShape AccPlaneShape
        {
            get { return GetPropertyValue<AccPlaneShape>("AccPlaneShape"); }
            set { SetPropertyValue("AccPlaneShape", value); }
        }

        [Custom("Caption", "表面形状")]
        public AccFaceShape AccFaceShape
        {
            get { return GetPropertyValue<AccFaceShape>("AccFaceShape"); }
            set { SetPropertyValue("AccFaceShape", value); }
        }

        [Custom("Caption", "剖面形状（边）")]
        public AccProfileSideShape AccProfileSideShape
        {
            get { return GetPropertyValue<AccProfileSideShape>("AccProfileSideShape"); }
            set { SetPropertyValue("AccProfileSideShape", value); }
        }

        [Custom("Caption", "剖面形状（底）")]
        public AccProfileBottomShape AccProfileBottomShape
        {
            get { return GetPropertyValue<AccProfileBottomShape>("AccProfileBottomShape"); }
            set { SetPropertyValue("AccProfileBottomShape", value); }
        }

        //体量
        //平面

        [Custom("Caption", "平面方向一")]
        public string PlaneDirection1
        {
            get { return GetPropertyValue<string>("PlaneDirection1"); }
            set { SetPropertyValue("PlaneDirection1", value); }
        }

        [Custom("Caption", "是否长或直径")]
        public IsLengthOrDiameter IsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("IsLengthOrDiameter"); }
            set { SetPropertyValue("IsLengthOrDiameter", value); }
        }

        [Custom("Caption", "长/直径（m）")]
        public float PlaneDirectionLength
        {
            get { return GetPropertyValue<float>("PlaneDirectionLength"); }
            set { SetPropertyValue("PlaneDirectionLength", value); }
        }

        [Custom("Caption", "平面方向二")]
        public string PlaneDirection2
        {
            get { return GetPropertyValue<string>("PlaneDirection2"); }
            set { SetPropertyValue("PlaneDirection2", value); }
        }

        [Custom("Caption", "宽（m）")]
        public float PlaneDirectionWidth
        {
            get { return GetPropertyValue<float>("PlaneDirectionWidth"); }
            set { SetPropertyValue("PlaneDirectionWidth", value); }
        }

        //剖面（m）
        [Custom("Caption", "是否深度或高度")]
        public IsDepthOrHeight IsDepthOrHeight
        {
            get { return GetPropertyValue<IsDepthOrHeight>("IsDepthOrHeight"); }
            set { SetPropertyValue("IsDepthOrHeight", value); }
        }

        //表面Surface
        [Custom("Caption", "东南")]
        public float SurfaceSouthEast
        {
            get { return GetPropertyValue<float>("SurfaceSouthEast"); }
            set { SetPropertyValue("SurfaceSouthEast", value); }
        }

        [Custom("Caption", "西南")]
        public float SurfaceSouthWest
        {
            get { return GetPropertyValue<float>("SurfaceSouthWest"); }
            set { SetPropertyValue("SurfaceSouthWest", value); }
        }

        [Custom("Caption", "中部")]
        public float SurfaceMiddle
        {
            get { return GetPropertyValue<float>("SurfaceMiddle"); }
            set { SetPropertyValue("SurfaceMiddle", value); }
        }

        [Custom("Caption", "东北")]
        public float SurfaceNorthEast
        {
            get { return GetPropertyValue<float>("SurfaceNorthEast"); }
            set { SetPropertyValue("SurfaceNorthEast", value); }
        }

        [Custom("Caption", "西北")]
        public float SurfaceNorthWest
        {
            get { return GetPropertyValue<float>("SurfaceNorthWest"); }
            set { SetPropertyValue("SurfaceNorthWest", value); }
        }

        [Custom("Caption", "最高")]
        public float SurfaceHighest
        {
            get { return GetPropertyValue<float>("SurfaceHighest"); }
            set { SetPropertyValue("SurfaceHighest", value); }
        }

        [Custom("Caption", "位置")]
        public string SurfaceHighestPosition
        {
            get { return GetPropertyValue<string>("SurfaceHighestPosition"); }
            set { SetPropertyValue("SurfaceHighestPosition", value); }
        }


        [Custom("Caption", "最低")]
        public float SurfaceLowest
        {
            get { return GetPropertyValue<float>("SurfaceLowest"); }
            set { SetPropertyValue("SurfaceLowest", value); }
        }

        [Custom("Caption", "位置")]
        public string SurfaceLowestPosition
        {
            get { return GetPropertyValue<string>("SurfaceLowestPosition"); }
            set { SetPropertyValue("SurfaceLowestPosition", value); }
        }

        //底面Floor

        [Custom("Caption", "东南")]
        public float FloorSouthEast
        {
            get { return GetPropertyValue<float>("FloorSouthEast"); }
            set { SetPropertyValue("FloorSouthEast", value); }
        }

        [Custom("Caption", "西南")]
        public float FloorSouthWest
        {
            get { return GetPropertyValue<float>("FloorSouthWest"); }
            set { SetPropertyValue("FloorSouthWest", value); }
        }

        [Custom("Caption", "中部")]
        public float FloorMiddle
        {
            get { return GetPropertyValue<float>("FloorMiddle"); }
            set { SetPropertyValue("FloorMiddle", value); }
        }

        [Custom("Caption", "东北")]
        public float FloorNorthEast
        {
            get { return GetPropertyValue<float>("FloorNorthEast"); }
            set { SetPropertyValue("FloorNorthEast", value); }
        }

        [Custom("Caption", "西北")]
        public float FloorNorthWest
        {
            get { return GetPropertyValue<float>("FloorNorthWest"); }
            set { SetPropertyValue("FloorNorthWest", value); }
        }

        [Custom("Caption", "最高")]
        public float FloorHighest
        {
            get { return GetPropertyValue<float>("FloorHighest"); }
            set { SetPropertyValue("FloorHighest", value); }
        }

        [Custom("Caption", "位置")]
        public string FloorHighestPosition
        {
            get { return GetPropertyValue<string>("FloorHighestPosition"); }
            set { SetPropertyValue("FloorHighestPosition", value); }
        }


        [Custom("Caption", "最低")]
        public float FloorLowest
        {
            get { return GetPropertyValue<float>("FloorLowest"); }
            set { SetPropertyValue("FloorLowest", value); }
        }

        [Custom("Caption", "位置")]
        public string FloorLowestPosition
        {
            get { return GetPropertyValue<string>("FloorLowestPosition"); }
            set { SetPropertyValue("FloorLowestPosition", value); }
        }

        //厚度

        [Custom("Caption", "最厚")]
        public float Thickest
        {
            get { return GetPropertyValue<float>("Thickest"); }
            set { SetPropertyValue("Thickest", value); }
        }

        [Custom("Caption", "位置")]
        public string ThickestPosition
        {
            get { return GetPropertyValue<string>("ThickestPosition"); }
            set { SetPropertyValue("ThickestPosition", value); }
        }


        [Custom("Caption", "最薄")]
        public float Thinest
        {
            get { return GetPropertyValue<float>("Thinest"); }
            set { SetPropertyValue("Thinest", value); }
        }

        [Custom("Caption", "位置")]
        public string ThinestPosition
        {
            get { return GetPropertyValue<string>("ThinestPosition"); }
            set { SetPropertyValue("ThinestPosition", value); }
        }

        //土质

        [Custom("Caption", "土质")]
        public SoilProperty SoilProperty
        {
            get { return GetPropertyValue<SoilProperty>("SoilProperty"); }
            set { SetPropertyValue("SoilProperty", value); }
        }

        [Custom("Caption", "土色")]
        public string SoilColor
        {
            get { return GetPropertyValue<string>("SoilColor"); }
            set { SetPropertyValue("SoilColor", value); }
        }

        [Custom("Caption", "致密度")]
        public Density Density
        {
            get { return GetPropertyValue<Density>("Density"); }
            set { SetPropertyValue("Density", value); }
        }

        //包含物

        [Custom("Caption", "包含物")]
        [Association("Accumulation-AccumulationContain", typeof(AccumulationContain))]
        public XPCollection AccumulationContain
        {
            get { return GetCollection("AccumulationContain"); }
        }

        //层位关系
        [Custom("Caption", "层位关系")]
        [Association("Accumulation-Layer", typeof(Layer))]
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

        [Custom("Caption", "遗物采集")]
        [Association("Accumulation-RemainMark", typeof(RemainMark))]
        public XPCollection RemainMark
        {
            get { return GetCollection("RemainMark"); }
        }

        [Custom("Caption", "迹象")]
        [Association("Accumulation-Sign", typeof(Sign))]
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

        [Custom("Caption", "总体描述")]
        public string TotalDescription
        {
            get { return GetPropertyValue<string>("TotalDescription"); }
            set { SetPropertyValue("TotalDescription", value); }
        }

        [Custom("Caption", "堆积性质判断及理由")]
        public string PropertyAndReason
        {
            get { return GetPropertyValue<string>("PropertyAndReason"); }
            set { SetPropertyValue("PropertyAndReason", value); }
        }

        [Custom("Caption", "堆积评价及工作总结")]
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


        //探方-各遗迹 包含堆积
        [Custom("Caption", "所属探方")]
        [Association("ExcavationTrench-Accumulation", typeof(ExcavationTrench))]
        public ExcavationTrench ExcavationTrench
        {
            get { return GetPropertyValue<ExcavationTrench>("ExcavationTrench"); }
            set { SetPropertyValue("ExcavationTrench", value); }
        }

        [Custom("Caption", "所属遗迹")]

        public string FeatureId
        {
            get
            {

                if (GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole") != null)
                { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile") != null)
                { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole1") != null)
                { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole1").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole2") != null)
                { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole2").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole") != null)
                { return GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole").ToString(); }
                else if (GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb1") != null)
                { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb1").ToString(); }
                else if (GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2") != null)
                { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2").ToString(); }
                else if (GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb3") != null)
                { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb3").ToString(); }
                else return null;
            }
        }

        [Custom("Caption", "对应坑状遗迹")]
        [Association("ExcavationFeatureHole-Accumulation", typeof(ExcavationFeatureHole))]
        public ExcavationFeatureHole ExcavationFeatureHole
        {
            get { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole"); }
            set { SetPropertyValue("ExcavationFeatureHole", value); }
        }

        [Custom("Caption", "对应堆状遗迹")]
        [Association("ExcavationFeaturePile-Accumulation", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile"); }
            set { SetPropertyValue("ExcavationFeaturePile", value); }
        }

        [Custom("Caption", "对应带坑堆状遗迹-地表建筑")]
        [Association("ExcavationFeaturePileHole-Accumulation1", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole1
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole1"); }
            set { SetPropertyValue("ExcavationFeaturePileHole1", value); }
        }

        [Custom("Caption", "对应带坑堆状遗迹-地下建筑")]
        [Association("ExcavationFeaturePileHole-Accumulation2", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole2
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole2"); }
            set { SetPropertyValue("ExcavationFeaturePileHole2", value); }
        }

        [Custom("Caption", "对应柱洞遗迹")]
        [Association("ExcavationFeaturePillarHole-Accumulation", typeof(ExcavationFeaturePillarHole))]
        public ExcavationFeaturePillarHole ExcavationFeaturePillarHole
        {
            get { return GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole"); }
            set { SetPropertyValue("ExcavationFeaturePillarHole", value); }
        }

        [Custom("Caption", "对应墓葬遗迹-地表建筑")]
        [Association("ExcavationFeatureTomb-Accumulation1", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb1
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb1"); }
            set { SetPropertyValue("ExcavationFeatureTomb1", value); }
        }

        [Custom("Caption", "对应墓葬遗迹-墓圹")]
        [Association("ExcavationFeatureTomb-Accumulation2", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb2
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2"); }
            set { SetPropertyValue("ExcavationFeatureTomb2", value); }
        }

        [Custom("Caption", "对应墓葬遗迹-墓室")]
        [Association("ExcavationFeatureTomb-Accumulation3", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb3
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb3"); }
            set { SetPropertyValue("ExcavationFeatureTomb3", value); }
        }


    }
    public enum AccPlaneShape { 未知, 圆形, 方形, 圆角方形, 矩形, 梯形, 椭圆形, 卵圆形, 亚腰形, 不规则形, 其他 }
    public enum AccFaceShape { 未知, 坑状, 筒状, 袋状, 水平状, 坡状, 波状, 凸镜状, 凹镜状, 其他 }
    public enum AccProfileSideShape { 未知, 锥形, 筒形, 袋形, 弧形, 其他 }
    public enum AccProfileBottomShape { 未知, 平底, 圆底, 尖底, 斜底, 凸底, 其他 }

    public enum IsLengthOrDiameter { 未知, 长, 直径 }
    public enum IsDepthOrHeight { 未知, 深度, 高度 }
    public enum SoilProperty { 未知, 粘土, 粉沙土, 细沙土, 粗沙土, 细砾, 粗砾 }
    public enum Density { 未知, 疏松, 较疏松, 较致密, 致密 }

    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Id")]
    [Custom("Caption", "堆积包含物")]
    public class AccumulationContain : BaseObject
    {
        public AccumulationContain(Session session) : base(session) { }
        [Custom("Caption", "类别")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "比例")]
        public string Proportion
        {
            get { return GetPropertyValue<string>("Proportion"); }
            set { SetPropertyValue("Proportion", value); }
        }

        [Custom("Caption", "分选度")]
        public string Separation
        {
            get { return GetPropertyValue<string>("Separation"); }
            set { SetPropertyValue("Separation", value); }
        }

        [Custom("Caption", "圆整度")]
        public string Round
        {
            get { return GetPropertyValue<string>("Round"); }
            set { SetPropertyValue("Round", value); }
        }

        [Custom("Caption", "植物(范围-种类-颜色-高度-比例)")]
        [Association("Accumulation-AccumulationContain", typeof(Accumulation))]
        public Accumulation Accumulation
        {
            get { return GetPropertyValue<Accumulation>("Accumulation"); }
            set { SetPropertyValue("Accumulation", value); }
        }
    }
}
