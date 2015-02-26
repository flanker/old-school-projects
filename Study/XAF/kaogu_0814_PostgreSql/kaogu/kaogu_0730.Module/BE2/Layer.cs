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
    [Custom("Caption","��λ��ϵ")]
    public class Layer : BaseObject
    {
        public Layer(Session session) : base(session) { }

        //��λһ������λ ��һ�Զࣩ
        [Custom("Caption", "��λһ������λ")]
        public string BelongUnit1
        {
            get { return GetPropertyValue<string>("BelongUnit1"); }
            set { SetPropertyValue("BelongUnit1",value); }
        }

        //��λһ������
        [Custom("Caption", "��λһ������")]
        public string LayerOne
        {
            get { return GetPropertyValue<string>("LayerOne"); }
            set { SetPropertyValue("LayerOne", value); }
        }

        //��λ��������λ ��ֱ���
        [Custom("Caption", "��λ��������λ")]
        public string BelongUnit2
        {
            get { return GetPropertyValue<string>("BelongUnit2"); }
            set { SetPropertyValue("BelongUnit2", value); }
        }

        //��λ�����Σ�
        [Custom("Caption", "��λһ���Σ�")]
        public string LayerTwo
        {
            get { return GetPropertyValue<string>("LayerTwo"); }
            set { SetPropertyValue("LayerTwo", value); }
        }

        //��λ��ϵ

        [Custom("Caption", "��λ��ϵ")]
        public LayerRelation LayerRelation
        {
            get { return GetPropertyValue<LayerRelation>("LayerRelation"); }
            set { SetPropertyValue("LayerRelation", value); }
        }


        //��λһ������ �� �ѻ�-̽��-�ż� ��Զ��ϵ
        [Custom("Caption", "�����ѻ�")]
        [Association("Accumulation-Layer", typeof(Accumulation))]
        public Accumulation Accumulation
        {
            get { return GetPropertyValue<Accumulation>("Accumulation"); }
            set { SetPropertyValue("Accumulation", value); }
        }

        [Custom("Caption", "����̽��")]
        [Association("ExcavationTrench-Layer", typeof(ExcavationTrench))]
        public ExcavationTrench ExcavationTrench
        {
            get { return GetPropertyValue<ExcavationTrench>("ExcavationTrench"); }
            set { SetPropertyValue("ExcavationTrench", value); }
        }

        [Custom("Caption", "�����ż�")]
        public string FeatureId
        {
            get
            {
                if (GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround") != null)
                { return GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile") != null)
                { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile").ToString(); }
                else if (GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole") != null)
                { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole") != null)
                { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole") != null)
                { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole").ToString(); }
                else if (GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb") != null)
                { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb").ToString(); }
                else return null;
            }
        }

        [Custom("Caption", "��Ӧ��������")]
        [Association("ExcavationFeatureGround-Layer", typeof(ExcavationFeatureGround))]
        public ExcavationFeatureGround ExcavationFeatureGround
        {
            get { return GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround"); }
            set { SetPropertyValue("ExcavationFeatureGround", value); }
        }

        [Custom("Caption", "��Ӧ��״�ż�")]
        [Association("ExcavationFeaturePile-Layer", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile"); }
            set { SetPropertyValue("ExcavationFeaturePile", value); }
        }

        [Custom("Caption", "��Ӧ��״�ż�")]
        [Association("ExcavationFeatureHole-Layer", typeof(ExcavationFeatureHole))]
        public ExcavationFeatureHole ExcavationFeatureHole
        {
            get { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole"); }
            set { SetPropertyValue("ExcavationFeatureHole", value); }
        }

        [Custom("Caption", "��Ӧ���Ӷ�״�ż�")]
        [Association("ExcavationFeaturePileHole-Layer", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole"); }
            set { SetPropertyValue("ExcavationFeaturePileHole", value); }
        }
        [Custom("Caption", "��Ӧ�����ż�")]
        [Association("ExcavationFeaturePillarHole-Layer", typeof(ExcavationFeaturePillarHole))]
        public ExcavationFeaturePillarHole ExcavationFeaturePillarHole
        {
            get { return GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole"); }
            set { SetPropertyValue("ExcavationFeaturePillarHole", value); }
        }

        [Custom("Caption", "��ӦĹ���ż�")]
        [Association("ExcavationFeatureTomb-Layer", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb"); }
            set { SetPropertyValue("ExcavationFeatureTomb", value); }
        }

    }

    public enum LayerRelation { δ֪, ����, ������, ��ѹ, ����ѹ  }


    [DefaultClassOptions]
    [Custom("Caption", "̽��-�ż���λ��ϵ")]
    public class TrenchFeatureLayerRelation : BaseObject
    {
        public TrenchFeatureLayerRelation(Session session) : base(session) { }


        [Custom("Caption", "����̽��")]
        [Association("ExcavationTrench-TrenchFeatureLayerRelation", typeof(ExcavationTrench))]
        public ExcavationTrench ExcavationTrench
        {
            get { return GetPropertyValue<ExcavationTrench>("ExcavationTrench"); }
            set { SetPropertyValue("ExcavationTrench", value); }
        }

        [Custom("Caption", "��Ӧ�ż����")]
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

        [Custom("Caption", "��λ��ϵ")]
        public string LayerRelation
        {
            get { return GetPropertyValue<string>("LayerRelation"); }
            set { SetPropertyValue("LayerRelation", value); }
        }

        [Custom("Caption", "����")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }
    }
}
