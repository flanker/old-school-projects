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
    [Custom("Caption","墓葬遗迹登记")]
    public class ExcavationFeatureTomb : BaseObject
    {
        public ExcavationFeatureTomb(Session session) : base(session) { }

        [Custom("Caption","记录人")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("Caption","记录日期")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption","所属遗址")]
        public string BelongSite
        {
            get { return GetPropertyValue<string>("BelongSite"); }
            set { SetPropertyValue("BelongSite", value); }
        }

        [Custom("Caption","墓葬编号")]
        public String Id
        {
            get { return GetPropertyValue<String>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption","是否主从")]
        public IsMainOrPart MainOrPart
        {
            get { return GetPropertyValue<IsMainOrPart>("MainOrPart"); }
            set { SetPropertyValue("MainOrPart", value); }
        }


        [Association("ExcavationFeatureTomb-Worker", typeof(Worker))]
        [Custom("Caption", "发掘人员")]
        public XPCollection Worker
        {
            get { return GetCollection("Worker"); }
        }


        [Custom("Caption","发掘日期起")]
        public DateTime StartOn
        {
            get { return GetPropertyValue<DateTime>("StartOn"); }
            set { SetPropertyValue("StartOn", value); }
        }

        [Custom("Caption","发掘日期终")]
        public DateTime EndOn
        {
            get { return GetPropertyValue<DateTime>("EndOn"); }
            set { SetPropertyValue("EndOn", value); }
        }

        [Custom("Caption","用工")]
        public string FWorker
        {
            get { return GetPropertyValue<string>("FWorker"); }
            set { SetPropertyValue("EndOn", value); }
        }


        //地面位置
        [Custom("Caption","地理坐标")]
        public string GPS
        {
            get { return GetPropertyValue<string>("GPS"); }
            set { SetPropertyValue("GPS", value); }
        }

        [Custom("Caption","测量位置描述一")]
        public string GPSDescription
        {
            get { return GetPropertyValue<string>("GPSDescription"); }
            set { SetPropertyValue("GPSDescription", value); }
        }

        [Custom("Caption","发掘坐标")] //全站仪
        public string TotalStation
        {
            get { return GetPropertyValue<string>("TotalStation"); }
            set { SetPropertyValue("TotalStation", value); }
        }

        [Custom("Caption","测量位置描述二")]
        public string TotalStationDescription
        {
            get { return GetPropertyValue<string>("TotalStationDescription"); }
            set { SetPropertyValue("TotalStationDescription", value); }
        }
        
        [Custom("Caption","所属遗迹？")]
        public string BelongFeature
        {
            get { return GetPropertyValue<string>("BelongFeature"); }
            set { SetPropertyValue("BelongFeature", value); }
        }
        //基本信息
        //自然环境
        [Custom("Caption","地形")]
        public string Terrain
        {
            get { return GetPropertyValue<string>("Terrain"); }
            set { SetPropertyValue("Terrain", value); }
        }

        [Custom("Caption","地貌")]
        public string Landform
        {
            get { return GetPropertyValue<string>("Landform"); }
            set { SetPropertyValue("Landform", value); }
        }

        [Custom("Caption","水文")]
        public string Hydrology
        {
            get { return GetPropertyValue<string>("Hydrology"); }
            set { SetPropertyValue("Hydrology", value); }
        }

        [Custom("Caption","植被")]
        public string Vege
        {
            get { return GetPropertyValue<string>("Vege"); }
            set { SetPropertyValue("Vege", value); }
        }

        [Custom("Caption","保存状况")]
        public string KeepState
        {
            get { return GetPropertyValue<string>("KeepState"); }
            set { SetPropertyValue("KeepState", value); }
        }

        [Custom("Caption","清理方式")]
        public string CleanType
        {
            get { return GetPropertyValue<string>("CleanType"); }
            set { SetPropertyValue("CleanType", value); }
        }

        [Custom("Caption","分布位置")]
        public string SpreadLocation
        {
            get { return GetPropertyValue<string>("SpreadLocation"); }
            set { SetPropertyValue("SpreadLocation", value); }
        }
        
        //与周临遗迹层位及位置关系 多对多

        [Custom("Caption", "与周临遗迹层位及位置关系)")]
        [Association("ExcavationFeatureTomb-Layer", typeof(Layer))]
        public XPCollection Layer
        {
            get { return GetCollection("Layer"); }
        }


        [Custom("Caption","文字描述")]
        public string LayerDescription
        {
            get { return GetPropertyValue<string>("LayerDescription"); }
            set { SetPropertyValue("LayerDescription", value); }
        }


        //独立
        [Custom("Caption","附属遗迹")]
        public string AdditionFeature
        {
            get { return GetPropertyValue<string>("AdditionFeature"); }
            set { SetPropertyValue("AdditionFeature", value); }
        }

        //地表建筑

        //发掘前

        // 地表坡度
        [Custom("Caption","地表坡度方向")]
        public string LandSlopeLocation
        {
            get { return GetPropertyValue<string>("LandSlopeLocation"); }
            set { SetPropertyValue("LandSlopeLocation", value); }
        }
        [Custom("Caption","地表坡度角度")]
        public int LandSlopeDegree
        {
            get { return GetPropertyValue<int>("LandSlopeDegree"); }
            set { SetPropertyValue("LandSlopeDegree", value); }
        }

        [Custom("Caption","平面形状")]
        public string PlaneShape
        {
            get { return GetPropertyValue<string>("PlaneShape"); }
            set { SetPropertyValue("PlaneShape", value); }
        }

        [Custom("Caption","侧面形状")]
        public string SideShape
        {
            get { return GetPropertyValue<string>("SideShape"); }
            set { SetPropertyValue("SideShape", value); }
        }

        [Custom("Caption","剖面形状")]
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


        [Custom("Caption","长/直径")]
        public float SizeEntireLength
        {
            get { return GetPropertyValue<float>("SizeEntireLength"); }
            set { SetPropertyValue("SizeEntireLength", value); }
        }

        [Custom("Caption","宽")]
        public float SizeEntireWidth
        {
            get { return GetPropertyValue<float>("SizeEntireWidth"); }
            set { SetPropertyValue("SizeEntireWidth", value); }
        }

        [Custom("Caption","高")]
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
        [Custom("Caption","长/直径")]
        public float SizeSunkerLength
        {
            get { return GetPropertyValue<float>("SizeSunkerLength"); }
            set { SetPropertyValue("SizeSunkerLength", value); }
        }

        [Custom("Caption","宽")]
        public float SizeSunkerWidth
        {
            get { return GetPropertyValue<float>("SizeSunkerWidth"); }
            set { SetPropertyValue("SizeSunkerWidth", value); }
        }

        [Custom("Caption","深")]
        public float SizeSunkerDepth
        {
            get { return GetPropertyValue<float>("SizeSunkerDepth"); }
            set { SetPropertyValue("SizeSunkerDepth", value); }
        }

        //覆盖物
        //石块
        [Custom("Caption","范围")]
        public string StoneRange
        {
            get { return GetPropertyValue<string>("StoneRange"); }
            set { SetPropertyValue("StoneRange", value); }
        }

        [Custom("Caption","质地")]
        public string StoneQuality
        {
            get { return GetPropertyValue<string>("StoneQuality"); }
            set { SetPropertyValue("StoneQuality", value); }
        }


        [Custom("Caption","颜色")]
        public string StoneColor
        {
            get { return GetPropertyValue<string>("StoneColor"); }
            set { SetPropertyValue("StoneColor", value); }
        }

        [Custom("Caption","比例")]
        public string StoneProportion
        {
            get { return GetPropertyValue<string>("StoneProportion"); }
            set { SetPropertyValue("StoneProportion", value); }
        }

        [Custom("Caption","分选度")]
        public int StoneClassification
        {
            get { return GetPropertyValue<int>("StoneClassification"); }
            set { SetPropertyValue("StoneClassification", value); }
        }

        [Custom("Caption","磨圆度")]
        public int StoneSmooth
        {
            get { return GetPropertyValue<int>("StoneSmooth"); }
            set { SetPropertyValue("StoneSmooth", value); }
        }

        [Custom("Caption","最小尺寸")]
        public float StoneMinSize
        {
            get { return GetPropertyValue<float>("StoneMinSize"); }
            set { SetPropertyValue("StoneMinSize", value); }
        }

        [Custom("Caption","最大尺寸")]
        public float StoneMaxSize
        {
            get { return GetPropertyValue<float>("StoneMaxSize"); }
            set { SetPropertyValue("StoneMaxSize", value); }
        }

        [Custom("Caption","平均尺寸")]
        public float StoneAverageSize
        {
            get { return GetPropertyValue<float>("StoneAverageSize"); }
            set { SetPropertyValue("StoneAverageSize", value); }
        }

        //植物 一对多
        [Custom("Caption","植物(范围-种类-颜色-高度-比例)")]
        [Association("ExcavationFeatureTomb-Vegetation", typeof(Vegetation))]
        public XPCollection Vegetation
        {
            get { return GetCollection("Vegetation"); }
        }
      
        //注意:列举理由判断墓葬的类型及其可能从属的考古学文化
        [Custom("Caption","墓葬类型")]
        public string TombType
        {
            get { return GetPropertyValue<string>("TombType"); }
            set { SetPropertyValue("TombType", value); }
        }

        //堆积  多对多
       // [Custom("Caption","堆积编号")]
        [Custom("Caption", "地表建筑堆积")]

        [Association("ExcavationFeatureTomb-Accumulation1", typeof(Accumulation))]
        public XPCollection Accumulation1
        {
            get { return GetCollection("Accumulation1"); }
        }

        //出土物 多对多
        [Custom("Caption", "地表建筑出土物")]

        [Association("ExcavationFeatureTomb-RemainMark1", typeof(RemainMark))]
        public XPCollection RemainMark1
        {
            get { return GetCollection("RemainMark1"); }
        }

        //注意：概述地表建筑整体的形状、体量、各层堆积情况；列举理由推断墓葬地表建筑的建筑方式（建筑材料、建筑过程）。
        [Custom("Caption","描述")]
        public string SurfaceBuildingDescription
        {
            get { return GetPropertyValue<string>("SurfaceBuildingDescription"); }
            set { SetPropertyValue("SurfaceBuildingDescription", value); }
        }



        //墓圹
        [Custom("Caption","墓口位置")]
        public string TombEntryPosition
        {
            get { return GetPropertyValue<string>("TombEntryPosition"); }
            set { SetPropertyValue("TombEntryPosition", value); }
        }

        [Custom("Caption","开口层位及判断理由")]
        public string TombEntryLayerAndReason
        {
            get { return GetPropertyValue<string>("TombEntryLayerAndReason"); }
            set { SetPropertyValue("TombEntryLayerAndReason", value); }
        }

        [Custom("Caption","墓口形状")]
        public string TombEntryShape
        {
            get { return GetPropertyValue<string>("TombEntryShape"); }
            set { SetPropertyValue("TombEntryShape", value); }
        }

        [Custom("Caption","墓口方向(角度)")]
        public string TombEntryDirectionDegree
        {
            get { return GetPropertyValue<string>("TombEntryDirectionDegree"); }
            set { SetPropertyValue("TombEntryDirectionDegree", value); }
        }

        [Custom("Caption","墓口方向")]
        public string TombEntryDirectionOne
        {
            get { return GetPropertyValue<string>("TombEntryDirectionOne"); }
            set { SetPropertyValue("TombEntryDirectionOne", value); }
        }

        [Custom("Caption","墓口方向(长/直径)")]
        public string TombEntryDirectionLength
        {
            get { return GetPropertyValue<string>("TombEntryDirectionLength"); }
            set { SetPropertyValue("TombEntryDirectionLength", value); }
        }

        [Custom("Caption","墓口方向")]
        public string TombEntryDirectionLengthTwo
        {
            get { return GetPropertyValue<string>("TombEntryDirectionLengthTwo"); }
            set { SetPropertyValue("TombEntryDirectionLengthTwo", value); }
        }

        [Custom("Caption","墓口方向(宽)")]
        public string TombEntryDirectionLengthWidth
        {
            get { return GetPropertyValue<string>("TombEntryDirectionLengthWidth"); }
            set { SetPropertyValue("TombEntryDirectionLengthWidth", value); }
        }


        [Custom("Caption","墓底形状")]
        public string TombBottomShape
        {
            get { return GetPropertyValue<string>("TombBottomShape"); }
            set { SetPropertyValue("TombBottomShape", value); }
        }


        [Custom("Caption","坑底方向(角度)")]
        public string TombBottomDirectionDegree
        {
            get { return GetPropertyValue<string>("TombBottomDirectionDegree"); }
            set { SetPropertyValue("TombBottomDirectionDegree", value); }
        }


        [Custom("Caption","坑底方向")]
        public string TombBottomDirectionOne
        {
            get { return GetPropertyValue<string>("TombBottomDirectionOne"); }
            set { SetPropertyValue("TombBottomDirectionOne", value); }
        }

        [Custom("Caption","坑底方向(长/直径)")]
        public string TombBottomDirectionLength
        {
            get { return GetPropertyValue<string>("TombBottomDirectionLength"); }
            set { SetPropertyValue("TombBottomDirectionLength", value); }
        }

        [Custom("Caption","坑底方向")]
        public string TombBottomDirectionTwo
        {
            get { return GetPropertyValue<string>("TombBottomDirectionTwo"); }
            set { SetPropertyValue("TombBottomDirectionTwo", value); }
        }

        [Custom("Caption","坑底方向(宽)")]
        public string TombBottomDirectionWidth
        {
            get { return GetPropertyValue<string>("TombBottomDirectionWidth"); }
            set { SetPropertyValue("TombBottomDirectionWidth", value); }
        }


        //墓坑剖面形状
        [Custom("Caption","墓坑剖面方向一")]
        public string TombProfileDirectionOne
        {
            get { return GetPropertyValue<string>("TombProfileDirectionOne"); }
            set { SetPropertyValue("TombProfileDirectionOne", value); }
        }

        [Custom("Caption","墓坑剖面形状一")]
        public string TombProfileShapeOne
        {
            get { return GetPropertyValue<string>("TombProfileShapeOne"); }
            set { SetPropertyValue("TombProfileShapeOne", value); }
        }


        [Custom("Caption","墓坑剖面方向二")]
        public string TombProfileDirectionTwo
        {
            get { return GetPropertyValue<string>("TombProfileDirectionTwo"); }
            set { SetPropertyValue("TombProfileDirectionTwo", value); }
        }

        [Custom("Caption","墓坑剖面形状二")]
        public string TombProfileShapeTwo
        {
            get { return GetPropertyValue<string>("TombProfileShapeTwo"); }
            set { SetPropertyValue("TombProfileShapeTwo", value); }
        }

        //人工堆积 (编号-分布范围-描述(参照堆积登记表进行概述))
        [Custom("Caption", "墓圹人工堆积")]

        [Association("ExcavationFeatureTomb-Accumulation2", typeof(Accumulation))]
        public XPCollection Accumulation2
        {
            get { return GetCollection("Accumulation2"); }
        }

        //自然堆积(编号-分布范围-描述(参照堆积登记表进行概述))
        [Custom("Caption", "墓圹自然堆积")]

        [Association("ExcavationFeatureTomb-NatureAccumulation2", typeof(NatureAccumulation))]
        public XPCollection NatureAccumulation2
        {
            get { return GetCollection("NatureAccumulation2"); }
        }


        //出土物(位置-类别-数量-单位-编号)
        [Custom("Caption", "墓圹出土物")]

        [Association("ExcavationFeatureTomb-RemainMark2", typeof(RemainMark))]
        public XPCollection RemainMark2
        {
            get { return GetCollection("RemainMark2"); }
        }

        //特殊建筑结构以及人工痕迹描述（位置、结构、形状、体量、包含物、出土物、人工遗物、加工痕迹等）
        //注意：墓壁加工痕迹、脚窝、棚架、偏室、龛、墓底棺椁底部铺垫物、腰坑、二层台等

        [Custom("Caption","特殊建筑结构以及人工痕迹描述（墓圹）")]

        [Association("ExcavationFeatureTomb-SpacialBuildingStructureAndArtificialVestige", 
            typeof(SpacialBuildingStructureAndArtificialVestige))]
        public XPCollection SpacialBuildingStructureAndArtificialVestige
        {
            get { return GetCollection("SpacialBuildingStructureAndArtificialVestige"); }
        }
      

        //注意：概述墓圹形状、体量、各层堆积情况及特殊建筑结构和人工遗迹现象；
        //列举理由推断墓坑的建筑方式及堆积形成的过程。
        [Custom("Caption","描述")]
        public string TombWallDescription
        {
            get { return GetPropertyValue<string>("TombWallDescription"); }
            set { SetPropertyValue("TombWallDescription", value); }
        }

        //墓室

        //人工堆积 (编号-分布范围-描述(参照堆积登记表进行概述))
        [Custom("Caption", "墓室人工堆积")]
        [Association("ExcavationFeatureTomb-Accumulation3", typeof(Accumulation))]
        public XPCollection Accumulation3
        {
            get { return GetCollection("Accumulation3"); }
        }

        //自然堆积 (编号-分布范围-描述(参照堆积登记表进行概述))
        [Custom("Caption", "墓室人工堆积")]
        [Association("ExcavationFeatureTomb-NatureAccumulation3", typeof(NatureAccumulation))]
        public XPCollection NatureAccumulation3
        {
            get { return GetCollection("NatureAccumulation3"); }
        }


        [Custom("Caption","在墓坑内的位置")]
        public string TombRoomPosition
        {
            get { return GetPropertyValue<string>("TombRoomPosition"); }
            set { SetPropertyValue("TombRoomPosition", value); }
        }

         //体量

        [Custom("Caption","体量长")]
        public float TombRoomLength
        {
            get { return GetPropertyValue<float>("TombRoomLength"); }
            set { SetPropertyValue("TombRoomLength", value); }
        }

        [Custom("Caption","体量宽")]
        public float TombRoomWidth
        {
            get { return GetPropertyValue<float>("TombRoomWidth"); }
            set { SetPropertyValue("TombRoomWidth", value); }
        }

        [Custom("Caption","体量高")]
        public float TombRoomHeight
        {
            get { return GetPropertyValue<float>("TombRoomHeight"); }
            set { SetPropertyValue("TombRoomHeight", value); }
        }

        //葬具 一对多(类型-平面形状-材质-体量)
        [Custom("Caption", "葬具")]

        [Association("ExcavationFeatureTomb-TombTool", typeof(TombTool))]
        public XPCollection TombTool
        {
            get { return GetCollection("TombTool"); }
        }


        [Custom("Caption", "葬具描述")]
        public string TombContainerDescription
        {
            get { return GetPropertyValue<string>("TombContainerDescription"); }
            set { SetPropertyValue("TombContainerDescription", value); }
        }

        //人骨 一对多(具-位置-葬式-头向-其他)
        [Custom("Caption", "人骨")]

        [Association("ExcavationFeatureTomb-TombSkeleton", typeof(TombSkeleton))]
        public XPCollection TombSkeleton
        {
            get { return GetCollection("TombSkeleton"); }
        }


        [Custom("Caption","人骨相互间位置关系")]
        public string SkeletonRelation
        {
            get { return GetPropertyValue<string>("SkeletonRelation"); }
            set { SetPropertyValue("SkeletonRelation", value); }
        }

        //出土物(位置-类别-数量-单位-编号)
        [Custom("Caption", "墓室出土物")]

        [Association("ExcavationFeatureTomb-RemainMark3", typeof(RemainMark))]
        public XPCollection RemainMark3
        {
            get { return GetCollection("RemainMark3"); }
        }

        //特殊建筑结构以及人工痕迹描述（位置、结构、形状、体量、包含物、出土物、人工遗物、加工痕迹等）
        //注意：墓壁加工痕迹、脚窝、棚架、偏室、龛、墓底棺椁底部铺垫物、腰坑、二层台等

        [Custom("Caption","特殊建筑结构以及人工痕迹描述（墓室）")]

        [Association("ExcavationFeatureTomb-SpacialBuildingStructureAndArtificialVestige2", 
            typeof(SpacialBuildingStructureAndArtificialVestige))]
        public XPCollection SpacialBuildingStructureAndArtificialVestige2
        {
            get { return GetCollection("SpacialBuildingStructureAndArtificialVestige2"); }
        }

        //注意：概述墓室形状、体量、各层堆积情况及特殊建筑结构和人工遗迹现象
        //列举理由推断墓室的建筑方式及堆积形成（下葬）的过程。
        [Custom("Caption","描述")]
        public string TombRoomDescription
        {
            get { return GetPropertyValue<string>("TombRoomDescription"); }
            set { SetPropertyValue("TombRoomDescription", value); }
        }

        //殉人 人牲 殉牲 牺牲 一对多(编号-类别-出土位置-伴出物类别-数量-编号-描述)
        [Custom("Caption", "殉人 人牲 殉牲 牺牲")]

        [Association("ExcavationFeatureTomb-TombSacrifice", typeof(TombSacrifice))]
        public XPCollection TombSacrifice
        {
            get { return GetCollection("TombSacrifice"); }
        }


        [Custom("Caption","描述")]
        public string SacrificeDescription
        {
            get { return GetPropertyValue<string>("SacrificeDescription"); }
            set { SetPropertyValue("SacrificeDescription", value); }
        }

        //迹象 一对多 (位置-描述)
        [Custom("Caption", "迹象")]

        [Association("ExcavationFeatureTomb-Sign", typeof(Sign))]
        public XPCollection Sign
        {
            get { return GetCollection("Sign"); }
        }


        [Custom("Caption","各迹象间相互关系")]
        public string SignRelation
        {
            get { return GetPropertyValue<string>("SignRelation"); }
            set { SetPropertyValue("SignRelation", value); }
        }

        [Custom("Caption","文化性质判定及理由")]
        public string PropertyAndReason
        {
            get { return GetPropertyValue<string>("PropertyAndReason"); }
            set { SetPropertyValue("PropertyAndReason", value); }
        }
        [Custom("Caption","遗迹评价、工作总结及建议")]
        public string Summary
        {
            get { return GetPropertyValue<string>("Summary"); }
            set { SetPropertyValue("Summary", value); }
        }
        //照相号 一对多

        //摄像号 一对多

        //绘图号 一对多

         [Custom("Caption","备注")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        //墓葬发掘记录
        [Size(3000)]
        [Custom("Caption","自然环境")]
        public string Environment
        {
            get { return GetPropertyValue<string>("Environment"); }
            set { SetPropertyValue("Environment", value); }
        }

        [Size(3000)]
        [Custom("Caption","历史地理概况")]
        public string Geohistory
        {
            get { return GetPropertyValue<string>("Geohistory"); }
            set { SetPropertyValue("Geohistory", value); }
        }

        [Size(3000)]
        [Custom("Caption","以往工作")]
        public string PreviousWork
        {
            get { return GetPropertyValue<string>("PreviousWork"); }
            set { SetPropertyValue("PreviousWork", value); }
        }

        [Size(3000)]
        [Custom("Caption","发掘过程")]
        public string ExcavationProcess
        {
            get { return GetPropertyValue<string>("ExcavationProcess"); }
            set { SetPropertyValue("ExcavationProcess", value); }
        }

        [Size(3000)]
        [Custom("Caption","层位关系")]
        public string LayerRelation
        {
            get { return GetPropertyValue<string>("LayerRelation"); }
            set { SetPropertyValue("LayerRelation", value); }
        }

        [Size(3000)]
        [Custom("Caption","地表建筑")]
        public string SurfaceBuilding
        {
            get { return GetPropertyValue<string>("SurfaceBuilding"); }
            set { SetPropertyValue("SurfaceBuilding", value); }
        }

        [Size(3000)]
        [Custom("Caption","墓圹")]
        public string TombWall
        {
            get { return GetPropertyValue<string>("TombWall"); }
            set { SetPropertyValue("TombWall", value); }
        }

        [Size(3000)]
        [Custom("Caption","墓室")]
        public string TombRoom
        {
            get { return GetPropertyValue<string>("TombRoom"); }
            set { SetPropertyValue("TombRoom", value); }
        }

        [Size(3000)]
        [Custom("Caption","葬具")]
        public string TombContainer
        {
            get { return GetPropertyValue<string>("TombContainer"); }
            set { SetPropertyValue("TombContainer", value); }
        }

        [Size(3000)]
        [Custom("Caption","人骨")]
        public string Skeleton
        {
            get { return GetPropertyValue<string>("Skeleton"); }
            set { SetPropertyValue("Skeleton", value); }
        }

        [Size(3000)]
        [Custom("Caption","葬仪 葬式")]
        public string Rite
        {
            get { return GetPropertyValue<string>("Rite"); }
            set { SetPropertyValue("Rite", value); }
        }

        [Size(3000)]
        [Custom("Caption","随葬品")]
        public string Belongs
        {
            get { return GetPropertyValue<string>("Belongs"); }
            set { SetPropertyValue("Belongs", value); }
        }

        [Size(3000)]
        [Custom("Caption","其他")]
        public string Other
        {
            get { return GetPropertyValue<string>("Other"); }
            set { SetPropertyValue("Other", value); }
        }

        [Size(3000)]
        [Custom("Caption","年代和文化形制及相关问题")]
        public string AgeAndCulture
        {
            get { return GetPropertyValue<string>("AgeAndCulture"); }
            set { SetPropertyValue("AgeAndCulture", value); }
        }

        [Size(3000)]
        [Custom("Caption","价值及日后工作计划")]
        public string ValueAndPlan
        {
            get { return GetPropertyValue<string>("ValueAndPlan"); }
            set { SetPropertyValue("ValueAndPlan", value); }
        }

        [Custom("Caption","审核人")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }

        [Custom("Caption","审核时间")]
        public DateTime CheckOn
        {
            get { return GetPropertyValue<DateTime>("CheckOn"); }
            set { SetPropertyValue("CheckOn", value); }
        }
    }

    public enum IsMainOrPart { 未知, 主, 从 }

}
