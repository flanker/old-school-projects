using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace kaogu.Module
{
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Id")]
    [Custom("Caption", "地面及界面登记")]
    public class ExcavationFeatureGround : BaseObject
    {
        public ExcavationFeatureGround(Session session) : base(session) { }

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

        [Custom("Caption", "地面及界面编号")]
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


        [Association("ExcavationFeatureGround-Worker", typeof(Worker))]
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
        [Association("ExcavationFeatureGround-Layer", typeof(Layer))]
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

        [Custom("Caption", "分布范围")]
        public string SpreadScope
        {
            get { return GetPropertyValue<string>("SpreadScope"); }
            set { SetPropertyValue("SpreadScope", value); }
        }

        //形状shape

        [Custom("Caption", "表面形状")]
        public string FaceShape
        {
            get { return GetPropertyValue<string>("FaceShape"); }
            set { SetPropertyValue("FaceShape", value); }
        }

        [Custom("Caption", "平面形状")]
        public string PlaneShape
        {
            get { return GetPropertyValue<string>("PlaneShape"); }
            set { SetPropertyValue("PlaneShape", value); }
        }

        [Custom("Caption", "剖面形状")]
        public string ProfileShape
        {
            get { return GetPropertyValue<string>("ProfileShape"); }
            set { SetPropertyValue("ProfileShape", value); }
        }

        //体量

        [Custom("Caption", "方向一")]
        public string Direction1
        {
            get { return GetPropertyValue<string>("Direction1"); }
            set { SetPropertyValue("Direction1", value); }
        }

        [Custom("Caption", "是否长或直径")]
        public IsLengthOrDiameter IsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("IsLengthOrDiameter"); }
            set { SetPropertyValue("IsLengthOrDiameter", value); }
        }

        [Custom("Caption", "长/直径（m）")]
        public float DirectionLength
        {
            get { return GetPropertyValue<float>("DirectionLength"); }
            set { SetPropertyValue("DirectionLength", value); }
        }

        [Custom("Caption", "方向二")]
        public string Direction2
        {
            get { return GetPropertyValue<string>("Direction2"); }
            set { SetPropertyValue("Direction2", value); }
        }

        [Custom("Caption", "宽（m）")]
        public float DirectionWidth
        {
            get { return GetPropertyValue<float>("DirectionWidth"); }
            set { SetPropertyValue("DirectionWidth", value); }
        }

        [Custom("Caption", "坡度方向")]
        public string SlopeLocation
        {
            get { return GetPropertyValue<string>("SlopeLocation"); }
            set { SetPropertyValue("SlopeLocation", value); }
        }
        [Custom("Caption", "坡度角度")]
        public int SlopeDegree
        {
            get { return GetPropertyValue<int>("SlopeDegree"); }
            set { SetPropertyValue("SlopeDegree", value); }
        }


        //修整痕迹
        [Custom("Caption", "修整痕迹")]
        [Association("ExcavationFeatureGround-GroundModifyVestige", typeof(GroundModifyVestige))]
        public XPCollection GroundModifyVestige
        {
            get { return GetCollection("GroundModifyVestige"); }
        }

        //使用或活动迹象

        [Custom("Caption", "迹象")]
        [Association("ExcavationFeatureGround-Sign", typeof(Sign))]
        public XPCollection Sign
        {
            get { return GetCollection("Sign"); }
        }

        [Custom("Caption", "各迹象间相互关系")]
        public string SignRelation
        {
            get { return GetPropertyValue<string>("SignRelation"); }
            set { SetPropertyValue("SignRelation", value); }
        }

        //遗物采集 出土物

        [Custom("Caption", "出土物")]

        [Association("ExcavationFeatureGround-RemainMark", typeof(RemainMark))]
        public XPCollection RemainMark
        {
            get { return GetCollection("RemainMark"); }
        }


        //总体描述


        [Custom("Caption", "性质判断及理由")]
        public string PropertyAndReason
        {
            get { return GetPropertyValue<string>("PropertyAndReason"); }
            set { SetPropertyValue("PropertyAndReason", value); }
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
