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
    [Custom("Caption", "探方登记")]
    public class ExcavationTrench : BaseObject
    {
        public ExcavationTrench(Session session) : base(session) { }

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

        [Custom("Caption", "探方编号")]
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


        [Association("ExcavationTrench-Worker", typeof(Worker))]
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
        [Association("ExcavationTrench-Layer", typeof(Layer))]
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

        //堆积
        [Custom("Caption", "堆积")]

        [Association("ExcavationTrench-Accumulation", typeof(Accumulation))]
        public XPCollection Accumulation
        {
            get { return GetCollection("Accumulation"); }
        }

        //探方与遗迹 层位关系
        [Custom("Caption", "与遗迹层位关系")]

        [Association("ExcavationTrench-TrenchFeatureLayerRelation", typeof(TrenchFeatureLayerRelation))]
        public XPCollection TrenchFeatureLayerRelation
        {
            get { return GetCollection("TrenchFeatureLayerRelation"); }
        }


        //出土物
        [Custom("Caption", "出土物")]

        [Association("ExcavationTrench-RemainMark", typeof(RemainMark))]
        public XPCollection RemainMark
        {
            get { return GetCollection("RemainMark"); }
        }


        [Custom("Caption", "探方评价及工作总结")]
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

        //探方发掘记录

        [Size(3000)]
        [Custom("Caption", "自然环境")]
        public string Environment
        {
            get { return GetPropertyValue<string>("Environment"); }
            set { SetPropertyValue("Environment", value); }
        }

        [Size(3000)]
        [Custom("Caption", "历史地理概况")]
        public string Geohistory
        {
            get { return GetPropertyValue<string>("Geohistory"); }
            set { SetPropertyValue("Geohistory", value); }
        }


        [Size(3000)]
        [Custom("Caption", "发掘过程")]
        public string ExcavationProcess
        {
            get { return GetPropertyValue<string>("ExcavationProcess"); }
            set { SetPropertyValue("ExcavationProcess", value); }
        }

        [Size(3000)]
        [Custom("Caption", "层位关系")]
        public string LayerRelation
        {
            get { return GetPropertyValue<string>("LayerRelation"); }
            set { SetPropertyValue("LayerRelation", value); }
        }

        [Size(3000)]
        [Custom("Caption", "堆积描述")]
        public string AccumulationDescription
        {
            get { return GetPropertyValue<string>("AccumulationDescription"); }
            set { SetPropertyValue("AccumulationDescription", value); }
        }

        [Size(3000)]
        [Custom("Caption", "遗迹描述")]
        public string FeatureDescription
        {
            get { return GetPropertyValue<string>("FeatureDescription"); }
            set { SetPropertyValue("FeatureDescription", value); }
        }

        [Size(3000)]
        [Custom("Caption", "出土物")]
        public string RemainDescription
        {
            get { return GetPropertyValue<string>("RemainDescription"); }
            set { SetPropertyValue("RemainDescription", value); }
        }

        [Size(3000)]
        [Custom("Caption", "迹象")]
        public string SignDescription
        {
            get { return GetPropertyValue<string>("SignDescription"); }
            set { SetPropertyValue("SignDescription", value); }
        }

        [Size(3000)]
        [Custom("Caption", "价值及日后工作计划")]
        public string ValueAndPlan
        {
            get { return GetPropertyValue<string>("ValueAndPlan"); }
            set { SetPropertyValue("ValueAndPlan", value); }
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
