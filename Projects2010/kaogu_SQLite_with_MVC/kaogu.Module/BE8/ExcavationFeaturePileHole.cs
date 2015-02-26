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
    [Custom("Caption", "带坑堆状遗迹登记")]
    public class ExcavationFeaturePileHole : BaseObject
    {
        public ExcavationFeaturePileHole(Session session) : base(session) { }

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

        [Custom("Caption", "带坑堆状遗迹编号")]
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


        [Association("ExcavationFeaturePileHole-Worker", typeof(Worker))]
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
        [Association("ExcavationFeaturePileHole-Layer", typeof(Layer))]
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

        //发掘前

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
        [Association("ExcavationFeaturePileHole-Vegetation", typeof(Vegetation))]
        public XPCollection Vegetation
        {
            get { return GetCollection("Vegetation"); }
        }

        //堆积
        [Custom("Caption", "地表建筑堆积")]

        [Association("ExcavationFeaturePileHole-Accumulation1", typeof(Accumulation))]
        public XPCollection Accumulation1
        {
            get { return GetCollection("Accumulation1"); }
        }
        //出土物

        [Custom("Caption", "地表建筑出土物")]

        [Association("ExcavationFeaturePileHole-RemainMark1", typeof(RemainMark))]
        public XPCollection RemainMark1
        {
            get { return GetCollection("RemainMark1"); }
        }

        //注意：概述地表建筑整体的形状、体量、各层堆积情况；列举理由推断墓葬地表建筑的建筑方式（建筑材料、建筑过程）。
        [Custom("Caption", "地表建筑描述")]
        public string SurfaceBuildingDescription
        {
            get { return GetPropertyValue<string>("SurfaceBuildingDescription"); }
            set { SetPropertyValue("SurfaceBuildingDescription", value); }
        }


        //地下建筑

        [Custom("Caption", "坑口在堆下位置")]
        public string HoleUnderPilePosition
        {
            get { return GetPropertyValue<string>("HoleUnderPilePosition"); }
            set { SetPropertyValue("HoleUnderPilePosition", value); }
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


        //堆积

        [Custom("Caption", "地下建筑堆积")]

        [Association("ExcavationFeaturePileHole-Accumulation2", typeof(Accumulation))]
        public XPCollection Accumulation2
        {
            get { return GetCollection("Accumulation2"); }
        }

        //出土物
        [Custom("Caption", "地下建筑堆积")]

        [Association("ExcavationFeaturePileHole-RemainMark2", typeof(RemainMark))]
        public XPCollection RemainMark2
        {
            get { return GetCollection("RemainMark2"); }
        }

        //描述
        [Custom("Caption", "地下建筑描述")]
        public string BottomBuildingDescription
        {
            get { return GetPropertyValue<string>("BottomBuildingDescription"); }
            set { SetPropertyValue("BottomBuildingDescription", value); }
        }


        //特殊建筑结构以及人工痕迹
        [Custom("Caption", "特殊建筑结构以及人工痕迹")]

        [Association("ExcavationFeaturePileHole-SpacialBuildingStructureAndArtificialVestige",
            typeof(SpacialBuildingStructureAndArtificialVestige))]
        public XPCollection SpacialBuildingStructureAndArtificialVestige
        {
            get { return GetCollection("SpacialBuildingStructureAndArtificialVestige"); }
        }

        //迹象
        [Custom("Caption", "迹象")]
        [Association("ExcavationFeaturePileHole-Sign", typeof(Sign))]
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

        [Custom("Caption", "总体描述")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
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
