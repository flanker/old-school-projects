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
    

    //植物
    [DefaultClassOptions]
    [Custom("Caption", "植物")]
    public class Vegetation : BaseObject
    {
        public Vegetation(Session session) : base(session) { }

        [Custom("Caption", "所属遗迹")]
        
        public string FeatureId
        {
            get {
                if (GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb") != null)
                { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb").ToString(); }
                else if(GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile") != null)
                { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole") != null)
                { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole").ToString(); }
                else return null;
            }          
        }

        [Custom("Caption", "对应堆状遗迹编号")]
        [Association("ExcavationFeaturePile-Vegetation", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile"); }
            set { SetPropertyValue("ExcavationFeaturePile", value); }
        }

        [Custom("Caption", "对应带坑堆状遗迹编号")]
        [Association("ExcavationFeaturePileHole-Vegetation", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole"); }
            set { SetPropertyValue("ExcavationFeaturePileHole", value); }
        }

        [Custom("Caption", "对应墓葬覆盖物编号")]
        [Association("ExcavationFeatureTomb-Vegetation", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb"); }
            set { SetPropertyValue("ExcavationFeatureTomb", value); }
        }

        [Custom("Caption", "范围")]
        public string Scope
        {
            get { return GetPropertyValue<string>("Scope"); }
            set { SetPropertyValue("Scope", value); }
        }

        [Custom("Caption", "种类")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "颜色")]
        public string Color
        {
            get { return GetPropertyValue<string>("Color"); }
            set { SetPropertyValue("Color", value); }
        }

        [Custom("Caption", "高度")]
        public string Height
        {
            get { return GetPropertyValue<string>("Height"); }
            set { SetPropertyValue("Height", value); }
        }

        [Custom("Caption", "比例")]
        public string Proportion
        {
            get { return GetPropertyValue<string>("Proportion"); }
            set { SetPropertyValue("Proportion", value); }
        }
    }

    //人工堆积 见堆积登记表
    //自然堆积 见堆积登记表NL
    //墓葬-自然堆积（墓圹、墓室）
    [DefaultClassOptions]
    [Custom("Caption", "墓葬-自然堆积")]
    public class NatureAccumulation : BaseObject
    {
        public NatureAccumulation(Session session) : base(session) { }

        [Custom("Caption", "所属墓圹")]
        [Association("ExcavationFeatureTomb-NatureAccumulation2", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb2
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2"); }
            set { SetPropertyValue("ExcavationFeatureTomb2", value); }
        }

        [Custom("Caption", "所属墓室")]
        [Association("ExcavationFeatureTomb-NatureAccumulation3", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb3
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb3"); }
            set { SetPropertyValue("ExcavationFeatureTomb3", value); }
        }

        [Custom("Caption", "编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "分布范围")]
        public string SpreadScope
        {
            get { return GetPropertyValue<string>("SpreadScope"); }
            set { SetPropertyValue("SpreadScope", value); }
        }

        [Custom("Caption", "描述")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }
    }
    //出土物 见遗物标签

    //特殊建筑结构及人工痕迹
    [DefaultClassOptions]
    [Custom("Caption", "特殊建筑结构以及人工痕迹描述")]
    public class SpacialBuildingStructureAndArtificialVestige : BaseObject
    {
        public SpacialBuildingStructureAndArtificialVestige(Session session) : base(session) { }

        [Custom("Caption", "所属遗迹")]

        public string FeatureId
        {
            get
            {
                if (GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb1") != null)
                { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb1").ToString(); }
                else if(GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2") != null)
                { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2").ToString(); }
                else if (GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole") != null)
                { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile") != null)
                { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole") != null)
                { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole").ToString(); }
                else return null;
            }
        }

        [Custom("Caption", "对应墓葬墓圹编号")]
        [Association("ExcavationFeatureTomb-SpacialBuildingStructureAndArtificialVestige", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb1
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb1"); }
            set { SetPropertyValue("ExcavationFeatureTomb1", value); }
        }

        [Custom("Caption", "对应墓葬墓室编号")]
        [Association("ExcavationFeatureTomb-SpacialBuildingStructureAndArtificialVestige2", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb2
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2"); }
            set { SetPropertyValue("ExcavationFeatureTomb2", value); }
        }

        [Custom("Caption", "对应坑状遗迹编号")]
        [Association("ExcavationFeatureHole-SpacialBuildingStructureAndArtificialVestige", typeof(ExcavationFeatureHole))]
        public ExcavationFeatureHole ExcavationFeatureHole
        {
            get { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole"); }
            set { SetPropertyValue("ExcavationFeatureHole", value); }
        }

        [Custom("Caption", "对应堆状遗迹编号")]
        [Association("ExcavationFeaturePile-SpacialBuildingStructureAndArtificialVestige", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile"); }
            set { SetPropertyValue("ExcavationFeaturePile", value); }
        }

        [Custom("Caption", "对应带坑堆状遗迹编号")]
        [Association("ExcavationFeaturePileHole-SpacialBuildingStructureAndArtificialVestige", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole"); }
            set { SetPropertyValue("ExcavationFeaturePileHole", value); }
        }

        [Custom("Caption", "特殊建筑结构以及人工痕迹描述")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "描述")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }
    }

    



    //墓葬-墓室-葬具
    [DefaultClassOptions]
    [Custom("Caption", "墓葬-墓室-葬具")]
    public class TombTool : BaseObject
    {
        public TombTool(Session session) : base(session) { }

        [Custom("Caption", "所属墓葬")]
        [Association("ExcavationFeatureTomb-TombTool", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb"); }
            set { SetPropertyValue("ExcavationFeatureTomb", value); }
        }

        [Custom("Caption", "类型")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "平面形状")]
        public string PlaneShape
        {
            get { return GetPropertyValue<string>("PlaneShape"); }
            set { SetPropertyValue("PlaneShape", value); }
        }

        [Custom("Caption", "材质")]
        public string MaterialQuality
        {
            get { return GetPropertyValue<string>("MaterialQuality"); }
            set { SetPropertyValue("MaterialQuality", value); }
        }

        [Custom("Caption", "体量")]
        public string Size
        {
            get { return GetPropertyValue<string>("Size"); }
            set { SetPropertyValue("Size", value); }
        }

    }

    //墓葬-墓室-人骨Skeleton
    [DefaultClassOptions]
    [Custom("Caption", "墓葬-墓室-人骨")]
    public class TombSkeleton: BaseObject
    {
        public TombSkeleton(Session session) : base(session) { }

        [Custom("Caption", "所属墓葬")]
        [Association("ExcavationFeatureTomb-TombSkeleton", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb"); }
            set { SetPropertyValue("ExcavationFeatureTomb", value); }
        }

        [Custom("Caption", "编号（第几具）")]
        public int Id
        {
            get { return GetPropertyValue<int>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "位置")]
        public string Position
        {
            get { return GetPropertyValue<string>("Position"); }
            set { SetPropertyValue("Position", value); }
        }

        [Custom("Caption", "葬式")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "头向")]
        public string HeadDirection
        {
            get { return GetPropertyValue<string>("HeadDirection"); }
            set { SetPropertyValue("HeadDirection", value); }
        }

        [Custom("Caption", "其他")]
        public string Other
        {
            get { return GetPropertyValue<string>("Other"); }
            set { SetPropertyValue("Other", value); }
        }

    }
    //墓葬-牺牲

    [DefaultClassOptions]
    [Custom("Caption", "墓葬-墓室-殉人 人牲 殉牲 牺牲")]
    public class TombSacrifice : BaseObject
    {
        public TombSacrifice(Session session) : base(session) { }

        [Custom("Caption", "所属墓葬")]
        [Association("ExcavationFeatureTomb-TombSacrifice", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb"); }
            set { SetPropertyValue("ExcavationFeatureTomb", value); }
        }

        [Custom("Caption", "编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "类别")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "位置")]
        public string Position
        {
            get { return GetPropertyValue<string>("Position"); }
            set { SetPropertyValue("Position", value); }
        }

        [Custom("Caption", "伴出物类别")]
        public string AdditionType
        {
            get { return GetPropertyValue<string>("AdditionType"); }
            set { SetPropertyValue("AdditionType", value); }
        }

        [Custom("Caption", "描述")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }

    }

    //迹象

    [DefaultClassOptions]
    [Custom("Caption", "迹象")]
    public class Sign : BaseObject
    {
        public Sign(Session session) : base(session) { }

        [Custom("Caption", "所属堆积")]
        [Association("Accumulation-Sign", typeof(Accumulation))]
        public Accumulation Accumulation
        {
            get { return GetPropertyValue<Accumulation>("Accumulation"); }
            set { SetPropertyValue("Accumulation", value); }
        }
        
        [Custom("Caption", "所属遗迹")]

        public string FeatureId
        {
            get 
            {
                if (GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb") != null)
                { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb").ToString(); }
                else if (GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole") != null)
                { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile") != null)
                { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole") != null)
                { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole").ToString(); }
                else if (GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround") != null)
                { return GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround").ToString(); }
                else return null;
            }
        }


        [Custom("Caption", "对应地面及界面编号")]
        [Association("ExcavationFeatureGround-Sign", typeof(ExcavationFeatureGround))]
        public ExcavationFeatureGround ExcavationFeatureGround
        {
            get { return GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround"); }
            set { SetPropertyValue("ExcavationFeatureGround", value); }
        }

        [Custom("Caption", "对应坑状遗迹编号")]
        [Association("ExcavationFeatureHole-Sign", typeof(ExcavationFeatureHole))]
        public ExcavationFeatureHole ExcavationFeatureHole
        {
            get { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole"); }
            set { SetPropertyValue("ExcavationFeatureHole", value); }
        }

        [Custom("Caption", "对应堆状遗迹编号")]
        [Association("ExcavationFeaturePile-Sign", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile"); }
            set { SetPropertyValue("ExcavationFeaturePile", value); }
        }

        [Custom("Caption", "对应带坑堆状遗迹编号")]
        [Association("ExcavationFeaturePileHole-Sign", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole"); }
            set { SetPropertyValue("ExcavationFeaturePileHole", value); }
        }

        [Custom("Caption", "对应墓葬编号")]
        [Association("ExcavationFeatureTomb-Sign", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb"); }
            set { SetPropertyValue("ExcavationFeatureTomb", value); }
        }

        [Custom("Caption", "位置")]
        public string Position
        {
            get { return GetPropertyValue<string>("Position"); }
            set { SetPropertyValue("Position", value); }
        }

        [Custom("Caption", "描述")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }
    }

    //地面及界面-修整痕迹
    [DefaultClassOptions]
    [Custom("Caption", "修整痕迹")]
    public class GroundModifyVestige : BaseObject
    {
        public GroundModifyVestige(Session session) : base(session) { }

        [Custom("Caption", "所属遗迹")]

        public string FeatureId
        {
            get
            {
                if (GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround") != null)
                { return GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole") != null)
                { return GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole").ToString(); }
                else return null;
            }
        }


        [Custom("Caption", "所属地面或界面")]
        [Association("ExcavationFeatureGround-GroundModifyVestige", typeof(ExcavationFeatureGround))]
        public ExcavationFeatureGround ExcavationFeatureGround
        {
            get { return GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround"); }
            set { SetPropertyValue("ExcavationFeatureGround", value); }
        }

        [Custom("Caption", "所属柱洞")]
        [Association("ExcavationFeaturePillarHole-GroundModifyVestige", typeof(ExcavationFeaturePillarHole))]
        public ExcavationFeaturePillarHole ExcavationFeaturePillarHole
        {
            get { return GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole"); }
            set { SetPropertyValue("ExcavationFeaturePillarHole", value); }
        }

        [Custom("Caption", "位置")]
        public string Position
        {
            get { return GetPropertyValue<string>("Position"); }
            set { SetPropertyValue("Position", value); }
        }

        [Custom("Caption", "材料")]
        public string Material
        {
            get { return GetPropertyValue<string>("Material"); }
            set { SetPropertyValue("Material", value); }
        }

        [Custom("Caption", "颜色")]
        public string Color
        {
            get { return GetPropertyValue<string>("Color"); }
            set { SetPropertyValue("Color", value); }
        }

        [Custom("Caption", "致密度")]
        public string Density
        {
            get { return GetPropertyValue<string>("Density"); }
            set { SetPropertyValue("Density", value); }
        }

        [Custom("Caption", "体量")]
        public string Size
        {
            get { return GetPropertyValue<string>("Size"); }
            set { SetPropertyValue("Size", value); }
        }

        [Custom("Caption", "修整方式")]
        public string ModifyType
        {
            get { return GetPropertyValue<string>("ModifyType"); }
            set { SetPropertyValue("ModifyType", value); }
        }


    }
}
