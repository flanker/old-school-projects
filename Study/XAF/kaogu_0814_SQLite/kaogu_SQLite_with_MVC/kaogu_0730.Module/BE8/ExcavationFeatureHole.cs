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
    [Custom("Caption", "坑状遗迹登记")]
    public class ExcavationFeatureHole : BaseObject
    {
        public ExcavationFeatureHole(Session session) : base(session) { }

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

        [Custom("Caption", "坑状遗迹编号")]
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


        [Association("ExcavationFeatureHole-Worker", typeof(Worker))]
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
        [Association("ExcavationFeatureHole-Layer", typeof(Layer))]
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

        //总体 体量

        [Custom("Caption", "方向一")]
        public string Direction1
        {
            get { return GetPropertyValue<string>("Direction1"); }
            set { SetPropertyValue("Direction1", value); }
        }

        [Custom("Caption", "是否长或直径")]
        public IsLengthOrDiameter TotalIsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("TotalIsLengthOrDiameter"); }
            set { SetPropertyValue("TotalIsLengthOrDiameter", value); }
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

        //深度
        [Custom("Caption", "最深")]
        public float Deepest
        {
            get { return GetPropertyValue<float>("Deepest"); }
            set { SetPropertyValue("Deepest", value); }
        }

        [Custom("Caption", "位置")]
        public string DeepestPosition
        {
            get { return GetPropertyValue<string>("DeepestPosition"); }
            set { SetPropertyValue("DeepestPosition", value); }
        }


        [Custom("Caption", "最浅")]
        public float Shallowest
        {
            get { return GetPropertyValue<float>("Shallowest"); }
            set { SetPropertyValue("Shallowest", value); }
        }

        [Custom("Caption", "位置")]
        public string ShallowestPosition
        {
            get { return GetPropertyValue<string>("ShallowestPosition"); }
            set { SetPropertyValue("ShallowestPosition", value); }
        }

        //堆积 堆积表
        [Custom("Caption", "出土物")]

        [Association("ExcavationFeatureHole-Accumulation", typeof(Accumulation))]
        public XPCollection Accumulation
        {
            get { return GetCollection("Accumulation"); }
        }

        //出土物 遗物
        [Custom("Caption", "出土物")]

        [Association("ExcavationFeatureHole-RemainMark", typeof(RemainMark))]
        public XPCollection RemainMark
        {
            get { return GetCollection("RemainMark"); }
        }



        //坑缘
        [Custom("Caption", "形状")]
        public string EdgeShape
        {
            get { return GetPropertyValue<string>("EdgeShape"); }
            set { SetPropertyValue("EdgeShape", value); }
        }

        [Custom("Caption", "构筑物材质")]
        public string EdgeMaterial
        {
            get { return GetPropertyValue<string>("EdgeMaterial"); }
            set { SetPropertyValue("EdgeMaterial", value); }
        }

        [Custom("Caption", "颜色")]
        public string EdgeColor
        {
            get { return GetPropertyValue<string>("EdgeColor"); }
            set { SetPropertyValue("EdgeColor", value); }
        }

        //坑缘体量Size

        [Custom("Caption", "方向一")]
        public string EdgeSizeDirection1
        {
            get { return GetPropertyValue<string>("EdgeSizeDirection1"); }
            set { SetPropertyValue("EdgeSizeDirection1", value); }
        }

        [Custom("Caption", "是否长或直径")]
        public IsLengthOrDiameter EdgeSizeIsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("EdgeSizeIsLengthOrDiameter"); }
            set { SetPropertyValue("EdgeSizeIsLengthOrDiameter", value); }
        }

        [Custom("Caption", "长/直径（m）")]
        public float EdgeSizeDirectionLength
        {
            get { return GetPropertyValue<float>("EdgeSizeDirectionLength"); }
            set { SetPropertyValue("EdgeSizeDirectionLength", value); }
        }

        [Custom("Caption", "方向二")]
        public string EdgeSizeDirection2
        {
            get { return GetPropertyValue<string>("EdgeSizeDirection2"); }
            set { SetPropertyValue("EdgeSizeDirection2", value); }
        }

        [Custom("Caption", "宽（m）")]
        public float EdgeSizeDirectionWidth
        {
            get { return GetPropertyValue<float>("EdgeSizeDirectionWidth"); }
            set { SetPropertyValue("EdgeSizeDirectionWidth", value); }
        }

        [Custom("Caption", "高（m）")]
        public float EdgeSizeDirectionHeight
        {
            get { return GetPropertyValue<float>("EdgeSizeDirectionHeight"); }
            set { SetPropertyValue("EdgeSizeDirectionHeight", value); }
        }

        [Custom("Caption", "深（m）")]
        public float EdgeSizeDirectionDepth
        {
            get { return GetPropertyValue<float>("EdgeSizeDirectionDepth"); }
            set { SetPropertyValue("EdgeSizeDirectionDepth", value); }
        }


        //构筑物体量 BulitSize
        [Custom("Caption", "形状")]
        public string EdgeBulitSizeShape
        {
            get { return GetPropertyValue<string>("EdgeBulitSizeShape"); }
            set { SetPropertyValue("EdgeBulitSizeShape", value); }
        }

        [Custom("Caption", "是否长或直径")]
        public IsLengthOrDiameter EdgeBulitSizeIsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("EdgeBulitSizeIsLengthOrDiameter"); }
            set { SetPropertyValue("EdgeBulitSizeIsLengthOrDiameter", value); }
        }

        [Custom("Caption", "长/直径（m）")]
        public float EdgeBulitSizeLength
        {
            get { return GetPropertyValue<float>("EdgeBulitSizeLength"); }
            set { SetPropertyValue("EdgeBulitSizeLength", value); }
        }


        [Custom("Caption", "宽（m）")]
        public float EdgeBulitSizeWidth
        {
            get { return GetPropertyValue<float>("EdgeBulitSizeWidth"); }
            set { SetPropertyValue("EdgeBulitSizeWidth", value); }
        }

        [Custom("Caption", "高（m）")]
        public float EdgeBulitSizeHeight
        {
            get { return GetPropertyValue<float>("EdgeBulitSizeHeight"); }
            set { SetPropertyValue("EdgeBulitSizeHeight", value); }
        }

        [Custom("Caption", "间距（m）")]
        public float EdgeBulitSizeSpace
        {
            get { return GetPropertyValue<float>("EdgeBulitSizeSpace"); }
            set { SetPropertyValue("EdgeBulitSizeSpace", value); }
        }

        [Custom("Caption", "构筑方式")]
        public string EdgeBuiltType
        {
            get { return GetPropertyValue<string>("EdgeBuiltType"); }
            set { SetPropertyValue("EdgeBuiltType", value); }
        }


      


        [Custom("Caption", "使用痕迹")]
        public string EdgeUse
        {
            get { return GetPropertyValue<string>("EdgeUse"); }
            set { SetPropertyValue("EdgeUse", value); }
        }

        [Custom("Caption", "文字描述")]
        public string EdgeDescription
        {
            get { return GetPropertyValue<string>("EdgeDescription"); }
            set { SetPropertyValue("EdgeDescription", value); }
        }


        //坑口
        [Custom("Caption", "平面形状")]
        public AccPlaneShape EntryPlaneShape
        {
            get { return GetPropertyValue<AccPlaneShape>("EntryPlaneShape"); }
            set { SetPropertyValue("EntryPlaneShape", value); }
        }


        [Custom("Caption", "修整痕迹")]
        public string EntryModify
        {
            get { return GetPropertyValue<string>("EntryModify"); }
            set { SetPropertyValue("EntryModify", value); }
        }

        [Custom("Caption", "使用痕迹")]
        public string EntryUse
        {
            get { return GetPropertyValue<string>("EntryUse"); }
            set { SetPropertyValue("EntryUse", value); }
        }

        [Custom("Caption", "文字描述")]
        public string EntryDescription
        {
            get { return GetPropertyValue<string>("EntryDescription"); }
            set { SetPropertyValue("EntryDescription", value); }
        }

        //坑壁
        //剖面形状

        [Custom("Caption", "剖面方向一")]
        public string WallDirectionOne
        {
            get { return GetPropertyValue<string>("WallDirectionOne"); }
            set { SetPropertyValue("WallDirectionOne", value); }
        }

        [Custom("Caption", "剖面形状一")]
        public AccProfileSideShape WallShapeOne
        {
            get { return GetPropertyValue<AccProfileSideShape>("WallShapeOne"); }
            set { SetPropertyValue("WallShapeOne", value); }
        }


        [Custom("Caption", "剖面方向二")]
        public string WallDirectionTwo
        {
            get { return GetPropertyValue<string>("WallDirectionTwo"); }
            set { SetPropertyValue("WallDirectionTwo", value); }
        }

        [Custom("Caption", "剖面形状二")]
        public AccProfileSideShape WallShapeTwo
        {
            get { return GetPropertyValue<AccProfileSideShape>("WallShapeTwo"); }
            set { SetPropertyValue("WallShapeTwo", value); }
        }

        [Custom("Caption", "修整痕迹")]
        public string WallModify
        {
            get { return GetPropertyValue<string>("WallModify"); }
            set { SetPropertyValue("WallModify", value); }
        }

        [Custom("Caption", "使用痕迹")]
        public string WallUse
        {
            get { return GetPropertyValue<string>("WallUse"); }
            set { SetPropertyValue("WallUse", value); }
        }

        [Custom("Caption", "文字描述")]
        public string WallDescription
        {
            get { return GetPropertyValue<string>("WallDescription"); }
            set { SetPropertyValue("WallDescription", value); }
        }

        //坑底

        [Custom("Caption", "平面形状")]
        public AccPlaneShape BottomPlaneShape
        {
            get { return GetPropertyValue<AccPlaneShape>("BottomPlaneShape"); }
            set { SetPropertyValue("BottomPlaneShape", value); }
        }


        [Custom("Caption", "修整痕迹")]
        public string BottomModify
        {
            get { return GetPropertyValue<string>("BottomModify"); }
            set { SetPropertyValue("BottomModify", value); }
        }

        [Custom("Caption", "使用痕迹")]
        public string BottomUse
        {
            get { return GetPropertyValue<string>("BottomUse"); }
            set { SetPropertyValue("BottomUse", value); }
        }

        [Custom("Caption", "遗留物")]
        public string BottomRemain
        {
            get { return GetPropertyValue<string>("BottomRemain"); }
            set { SetPropertyValue("BottomRemain", value); }
        }

        [Custom("Caption", "文字描述")]
        public string BottomDescription
        {
            get { return GetPropertyValue<string>("BottomDescription"); }
            set { SetPropertyValue("BottomDescription", value); }
        }

        //特殊建筑结构以及人工痕迹
        [Custom("Caption", "特殊建筑结构以及人工痕迹")]

        [Association("ExcavationFeatureHole-SpacialBuildingStructureAndArtificialVestige",
            typeof(SpacialBuildingStructureAndArtificialVestige))]
        public XPCollection SpacialBuildingStructureAndArtificialVestige
        {
            get { return GetCollection("SpacialBuildingStructureAndArtificialVestige"); }
        }


        //迹象
        [Custom("Caption", "迹象")]
        [Association("ExcavationFeatureHole-Sign", typeof(Sign))]
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
