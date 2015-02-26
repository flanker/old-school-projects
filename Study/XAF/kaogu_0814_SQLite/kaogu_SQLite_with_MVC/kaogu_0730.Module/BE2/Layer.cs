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
    [Custom("Caption","层位关系")]
    public class Layer : BaseObject
    {
        public Layer(Session session) : base(session) { }

        //层位一所属单位 （一对多）
        [Custom("Caption", "层位一所属单位")]
        public string BelongUnit1
        {
            get { return GetPropertyValue<string>("BelongUnit1"); }
            set { SetPropertyValue("BelongUnit1",value); }
        }

        //层位一（主）
        [Custom("Caption", "层位一（主）")]
        public string LayerOne
        {
            get { return GetPropertyValue<string>("LayerOne"); }
            set { SetPropertyValue("LayerOne", value); }
        }

        //层位二所属单位 （直接填）
        [Custom("Caption", "层位二所属单位")]
        public string BelongUnit2
        {
            get { return GetPropertyValue<string>("BelongUnit2"); }
            set { SetPropertyValue("BelongUnit2", value); }
        }

        //层位二（次）
        [Custom("Caption", "层位一（次）")]
        public string LayerTwo
        {
            get { return GetPropertyValue<string>("LayerTwo"); }
            set { SetPropertyValue("LayerTwo", value); }
        }

        //层位关系

        [Custom("Caption", "层位关系")]
        public LayerRelation LayerRelation
        {
            get { return GetPropertyValue<LayerRelation>("LayerRelation"); }
            set { SetPropertyValue("LayerRelation", value); }
        }


        //层位一（主） 与 堆积-探方-遗迹 多对多关系
        [Custom("Caption", "所属堆积")]
        [Association("Accumulation-Layer", typeof(Accumulation))]
        public Accumulation Accumulation
        {
            get { return GetPropertyValue<Accumulation>("Accumulation"); }
            set { SetPropertyValue("Accumulation", value); }
        }

        [Custom("Caption", "所属探方")]
        [Association("ExcavationTrench-Layer", typeof(ExcavationTrench))]
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

        [Custom("Caption", "对应地面或界面")]
        [Association("ExcavationFeatureGround-Layer", typeof(ExcavationFeatureGround))]
        public ExcavationFeatureGround ExcavationFeatureGround
        {
            get { return GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround"); }
            set { SetPropertyValue("ExcavationFeatureGround", value); }
        }

        [Custom("Caption", "对应堆状遗迹")]
        [Association("ExcavationFeaturePile-Layer", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile"); }
            set { SetPropertyValue("ExcavationFeaturePile", value); }
        }

        [Custom("Caption", "对应坑状遗迹")]
        [Association("ExcavationFeatureHole-Layer", typeof(ExcavationFeatureHole))]
        public ExcavationFeatureHole ExcavationFeatureHole
        {
            get { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole"); }
            set { SetPropertyValue("ExcavationFeatureHole", value); }
        }

        [Custom("Caption", "对应带坑堆状遗迹")]
        [Association("ExcavationFeaturePileHole-Layer", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole"); }
            set { SetPropertyValue("ExcavationFeaturePileHole", value); }
        }
        [Custom("Caption", "对应柱洞遗迹")]
        [Association("ExcavationFeaturePillarHole-Layer", typeof(ExcavationFeaturePillarHole))]
        public ExcavationFeaturePillarHole ExcavationFeaturePillarHole
        {
            get { return GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole"); }
            set { SetPropertyValue("ExcavationFeaturePillarHole", value); }
        }

        [Custom("Caption", "对应墓葬遗迹")]
        [Association("ExcavationFeatureTomb-Layer", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb"); }
            set { SetPropertyValue("ExcavationFeatureTomb", value); }
        }

    }

    public enum LayerRelation { 未知, 打破, 被打破, 叠压, 被叠压  }


    [DefaultClassOptions]
    [Custom("Caption", "探方-遗迹层位关系")]
    public class TrenchFeatureLayerRelation : BaseObject
    {
        public TrenchFeatureLayerRelation(Session session) : base(session) { }


        [Custom("Caption", "所属探方")]
        [Association("ExcavationTrench-TrenchFeatureLayerRelation", typeof(ExcavationTrench))]
        public ExcavationTrench ExcavationTrench
        {
            get { return GetPropertyValue<ExcavationTrench>("ExcavationTrench"); }
            set { SetPropertyValue("ExcavationTrench", value); }
        }

        [Custom("Caption", "对应遗迹编号")]
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

        [Custom("Caption", "层位关系")]
        public string LayerRelation
        {
            get { return GetPropertyValue<string>("LayerRelation"); }
            set { SetPropertyValue("LayerRelation", value); }
        }

        [Custom("Caption", "描述")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }
    }
}
