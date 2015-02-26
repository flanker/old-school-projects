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
    

    //ֲ��
    [DefaultClassOptions]
    [Custom("Caption", "ֲ��")]
    public class Vegetation : BaseObject
    {
        public Vegetation(Session session) : base(session) { }

        [Custom("Caption", "�����ż�")]
        
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

        [Custom("Caption", "��Ӧ��״�ż����")]
        [Association("ExcavationFeaturePile-Vegetation", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile"); }
            set { SetPropertyValue("ExcavationFeaturePile", value); }
        }

        [Custom("Caption", "��Ӧ���Ӷ�״�ż����")]
        [Association("ExcavationFeaturePileHole-Vegetation", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole"); }
            set { SetPropertyValue("ExcavationFeaturePileHole", value); }
        }

        [Custom("Caption", "��ӦĹ�Ḳ������")]
        [Association("ExcavationFeatureTomb-Vegetation", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb"); }
            set { SetPropertyValue("ExcavationFeatureTomb", value); }
        }

        [Custom("Caption", "��Χ")]
        public string Scope
        {
            get { return GetPropertyValue<string>("Scope"); }
            set { SetPropertyValue("Scope", value); }
        }

        [Custom("Caption", "����")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "��ɫ")]
        public string Color
        {
            get { return GetPropertyValue<string>("Color"); }
            set { SetPropertyValue("Color", value); }
        }

        [Custom("Caption", "�߶�")]
        public string Height
        {
            get { return GetPropertyValue<string>("Height"); }
            set { SetPropertyValue("Height", value); }
        }

        [Custom("Caption", "����")]
        public string Proportion
        {
            get { return GetPropertyValue<string>("Proportion"); }
            set { SetPropertyValue("Proportion", value); }
        }
    }

    //�˹��ѻ� ���ѻ��ǼǱ�
    //��Ȼ�ѻ� ���ѻ��ǼǱ�NL
    //Ĺ��-��Ȼ�ѻ���Ĺ�ۡ�Ĺ�ң�
    [DefaultClassOptions]
    [Custom("Caption", "Ĺ��-��Ȼ�ѻ�")]
    public class NatureAccumulation : BaseObject
    {
        public NatureAccumulation(Session session) : base(session) { }

        [Custom("Caption", "����Ĺ��")]
        [Association("ExcavationFeatureTomb-NatureAccumulation2", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb2
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2"); }
            set { SetPropertyValue("ExcavationFeatureTomb2", value); }
        }

        [Custom("Caption", "����Ĺ��")]
        [Association("ExcavationFeatureTomb-NatureAccumulation3", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb3
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb3"); }
            set { SetPropertyValue("ExcavationFeatureTomb3", value); }
        }

        [Custom("Caption", "���")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "�ֲ���Χ")]
        public string SpreadScope
        {
            get { return GetPropertyValue<string>("SpreadScope"); }
            set { SetPropertyValue("SpreadScope", value); }
        }

        [Custom("Caption", "����")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }
    }
    //������ �������ǩ

    //���⽨���ṹ���˹��ۼ�
    [DefaultClassOptions]
    [Custom("Caption", "���⽨���ṹ�Լ��˹��ۼ�����")]
    public class SpacialBuildingStructureAndArtificialVestige : BaseObject
    {
        public SpacialBuildingStructureAndArtificialVestige(Session session) : base(session) { }

        [Custom("Caption", "�����ż�")]

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

        [Custom("Caption", "��ӦĹ��Ĺ�۱��")]
        [Association("ExcavationFeatureTomb-SpacialBuildingStructureAndArtificialVestige", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb1
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb1"); }
            set { SetPropertyValue("ExcavationFeatureTomb1", value); }
        }

        [Custom("Caption", "��ӦĹ��Ĺ�ұ��")]
        [Association("ExcavationFeatureTomb-SpacialBuildingStructureAndArtificialVestige2", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb2
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2"); }
            set { SetPropertyValue("ExcavationFeatureTomb2", value); }
        }

        [Custom("Caption", "��Ӧ��״�ż����")]
        [Association("ExcavationFeatureHole-SpacialBuildingStructureAndArtificialVestige", typeof(ExcavationFeatureHole))]
        public ExcavationFeatureHole ExcavationFeatureHole
        {
            get { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole"); }
            set { SetPropertyValue("ExcavationFeatureHole", value); }
        }

        [Custom("Caption", "��Ӧ��״�ż����")]
        [Association("ExcavationFeaturePile-SpacialBuildingStructureAndArtificialVestige", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile"); }
            set { SetPropertyValue("ExcavationFeaturePile", value); }
        }

        [Custom("Caption", "��Ӧ���Ӷ�״�ż����")]
        [Association("ExcavationFeaturePileHole-SpacialBuildingStructureAndArtificialVestige", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole"); }
            set { SetPropertyValue("ExcavationFeaturePileHole", value); }
        }

        [Custom("Caption", "���⽨���ṹ�Լ��˹��ۼ�����")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "����")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }
    }

    



    //Ĺ��-Ĺ��-���
    [DefaultClassOptions]
    [Custom("Caption", "Ĺ��-Ĺ��-���")]
    public class TombTool : BaseObject
    {
        public TombTool(Session session) : base(session) { }

        [Custom("Caption", "����Ĺ��")]
        [Association("ExcavationFeatureTomb-TombTool", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb"); }
            set { SetPropertyValue("ExcavationFeatureTomb", value); }
        }

        [Custom("Caption", "����")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "ƽ����״")]
        public string PlaneShape
        {
            get { return GetPropertyValue<string>("PlaneShape"); }
            set { SetPropertyValue("PlaneShape", value); }
        }

        [Custom("Caption", "����")]
        public string MaterialQuality
        {
            get { return GetPropertyValue<string>("MaterialQuality"); }
            set { SetPropertyValue("MaterialQuality", value); }
        }

        [Custom("Caption", "����")]
        public string Size
        {
            get { return GetPropertyValue<string>("Size"); }
            set { SetPropertyValue("Size", value); }
        }

    }

    //Ĺ��-Ĺ��-�˹�Skeleton
    [DefaultClassOptions]
    [Custom("Caption", "Ĺ��-Ĺ��-�˹�")]
    public class TombSkeleton: BaseObject
    {
        public TombSkeleton(Session session) : base(session) { }

        [Custom("Caption", "����Ĺ��")]
        [Association("ExcavationFeatureTomb-TombSkeleton", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb"); }
            set { SetPropertyValue("ExcavationFeatureTomb", value); }
        }

        [Custom("Caption", "��ţ��ڼ��ߣ�")]
        public int Id
        {
            get { return GetPropertyValue<int>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "λ��")]
        public string Position
        {
            get { return GetPropertyValue<string>("Position"); }
            set { SetPropertyValue("Position", value); }
        }

        [Custom("Caption", "��ʽ")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "ͷ��")]
        public string HeadDirection
        {
            get { return GetPropertyValue<string>("HeadDirection"); }
            set { SetPropertyValue("HeadDirection", value); }
        }

        [Custom("Caption", "����")]
        public string Other
        {
            get { return GetPropertyValue<string>("Other"); }
            set { SetPropertyValue("Other", value); }
        }

    }
    //Ĺ��-����

    [DefaultClassOptions]
    [Custom("Caption", "Ĺ��-Ĺ��-ѳ�� ���� ѳ�� ����")]
    public class TombSacrifice : BaseObject
    {
        public TombSacrifice(Session session) : base(session) { }

        [Custom("Caption", "����Ĺ��")]
        [Association("ExcavationFeatureTomb-TombSacrifice", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb"); }
            set { SetPropertyValue("ExcavationFeatureTomb", value); }
        }

        [Custom("Caption", "���")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "���")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "λ��")]
        public string Position
        {
            get { return GetPropertyValue<string>("Position"); }
            set { SetPropertyValue("Position", value); }
        }

        [Custom("Caption", "��������")]
        public string AdditionType
        {
            get { return GetPropertyValue<string>("AdditionType"); }
            set { SetPropertyValue("AdditionType", value); }
        }

        [Custom("Caption", "����")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }

    }

    //����

    [DefaultClassOptions]
    [Custom("Caption", "����")]
    public class Sign : BaseObject
    {
        public Sign(Session session) : base(session) { }

        [Custom("Caption", "�����ѻ�")]
        [Association("Accumulation-Sign", typeof(Accumulation))]
        public Accumulation Accumulation
        {
            get { return GetPropertyValue<Accumulation>("Accumulation"); }
            set { SetPropertyValue("Accumulation", value); }
        }
        
        [Custom("Caption", "�����ż�")]

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


        [Custom("Caption", "��Ӧ���漰������")]
        [Association("ExcavationFeatureGround-Sign", typeof(ExcavationFeatureGround))]
        public ExcavationFeatureGround ExcavationFeatureGround
        {
            get { return GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround"); }
            set { SetPropertyValue("ExcavationFeatureGround", value); }
        }

        [Custom("Caption", "��Ӧ��״�ż����")]
        [Association("ExcavationFeatureHole-Sign", typeof(ExcavationFeatureHole))]
        public ExcavationFeatureHole ExcavationFeatureHole
        {
            get { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole"); }
            set { SetPropertyValue("ExcavationFeatureHole", value); }
        }

        [Custom("Caption", "��Ӧ��״�ż����")]
        [Association("ExcavationFeaturePile-Sign", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile"); }
            set { SetPropertyValue("ExcavationFeaturePile", value); }
        }

        [Custom("Caption", "��Ӧ���Ӷ�״�ż����")]
        [Association("ExcavationFeaturePileHole-Sign", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole"); }
            set { SetPropertyValue("ExcavationFeaturePileHole", value); }
        }

        [Custom("Caption", "��ӦĹ����")]
        [Association("ExcavationFeatureTomb-Sign", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb"); }
            set { SetPropertyValue("ExcavationFeatureTomb", value); }
        }

        [Custom("Caption", "λ��")]
        public string Position
        {
            get { return GetPropertyValue<string>("Position"); }
            set { SetPropertyValue("Position", value); }
        }

        [Custom("Caption", "����")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }
    }

    //���漰����-�����ۼ�
    [DefaultClassOptions]
    [Custom("Caption", "�����ۼ�")]
    public class GroundModifyVestige : BaseObject
    {
        public GroundModifyVestige(Session session) : base(session) { }

        [Custom("Caption", "�����ż�")]

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


        [Custom("Caption", "������������")]
        [Association("ExcavationFeatureGround-GroundModifyVestige", typeof(ExcavationFeatureGround))]
        public ExcavationFeatureGround ExcavationFeatureGround
        {
            get { return GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround"); }
            set { SetPropertyValue("ExcavationFeatureGround", value); }
        }

        [Custom("Caption", "��������")]
        [Association("ExcavationFeaturePillarHole-GroundModifyVestige", typeof(ExcavationFeaturePillarHole))]
        public ExcavationFeaturePillarHole ExcavationFeaturePillarHole
        {
            get { return GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole"); }
            set { SetPropertyValue("ExcavationFeaturePillarHole", value); }
        }

        [Custom("Caption", "λ��")]
        public string Position
        {
            get { return GetPropertyValue<string>("Position"); }
            set { SetPropertyValue("Position", value); }
        }

        [Custom("Caption", "����")]
        public string Material
        {
            get { return GetPropertyValue<string>("Material"); }
            set { SetPropertyValue("Material", value); }
        }

        [Custom("Caption", "��ɫ")]
        public string Color
        {
            get { return GetPropertyValue<string>("Color"); }
            set { SetPropertyValue("Color", value); }
        }

        [Custom("Caption", "���ܶ�")]
        public string Density
        {
            get { return GetPropertyValue<string>("Density"); }
            set { SetPropertyValue("Density", value); }
        }

        [Custom("Caption", "����")]
        public string Size
        {
            get { return GetPropertyValue<string>("Size"); }
            set { SetPropertyValue("Size", value); }
        }

        [Custom("Caption", "������ʽ")]
        public string ModifyType
        {
            get { return GetPropertyValue<string>("ModifyType"); }
            set { SetPropertyValue("ModifyType", value); }
        }


    }
}
