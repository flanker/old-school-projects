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
    [Custom("Caption", "调查遗物登记")]
    public class SurveyRemainMark : BaseObject
    {
        public SurveyRemainMark(Session session) : base(session) { }


        [Custom("Caption", "所属遗迹")]
        public string FeatureId
        {
            get
            {
                if (GetPropertyValue<SurveyFeatureSettlement>("SurveyFeatureSettlement") != null)
                { return GetPropertyValue<SurveyFeatureSettlement>("SurveyFeatureSettlement").ToString(); }
                else if (GetPropertyValue<SurveyFeatureAlignment>("SurveyFeatureAlignment") != null)
                { return GetPropertyValue<SurveyFeatureAlignment>("SurveyFeatureAlignment").ToString(); }
                else if (GetPropertyValue<SurveyFeatureDeerStone>("SurveyFeatureDeerStone") != null)
                { return GetPropertyValue<SurveyFeatureDeerStone>("SurveyFeatureDeerStone").ToString(); }
                else if (GetPropertyValue<SurveyFeatureTomb>("SurveyFeatureTomb") != null)
                { return GetPropertyValue<SurveyFeatureTomb>("SurveyFeatureTomb").ToString(); }


                else return null;
            }
        }

        [Custom("Caption", "对应居址遗迹编号")]
        [Association("SurveyFeatureSettlement-SurveyRemainMark", typeof(SurveyFeatureSettlement))]
        public SurveyFeatureSettlement SurveyFeatureSettlement
        {
            get { return GetPropertyValue<SurveyFeatureSettlement>("SurveyFeatureSettlement"); }
            set { SetPropertyValue("SurveyFeatureSettlement", value); }
        }

        [Custom("Caption", "对应列石遗迹编号")]
        [Association("SurveyFeatureAlignment-SurveyRemainMark", typeof(SurveyFeatureAlignment))]
        public SurveyFeatureAlignment SurveyFeatureAlignment
        {
            get { return GetPropertyValue<SurveyFeatureAlignment>("SurveyFeatureAlignment"); }
            set { SetPropertyValue("SurveyFeatureAlignment", value); }
        }

        [Custom("Caption", "对应鹿石遗迹编号")]
        [Association("SurveyFeatureDeerStone-SurveyRemainMark", typeof(SurveyFeatureDeerStone))]
        public SurveyFeatureDeerStone SurveyFeatureDeerStone
        {
            get { return GetPropertyValue<SurveyFeatureDeerStone>("SurveyFeatureDeerStone"); }
            set { SetPropertyValue("SurveyFeatureDeerStone", value); }
        }

        [Custom("Caption", "对应墓葬遗迹编号")]
        [Association("SurveyFeatureTomb-SurveyRemainMark", typeof(SurveyFeatureTomb))]
        public SurveyFeatureTomb SurveyFeatureTomb
        {
            get { return GetPropertyValue<SurveyFeatureTomb>("SurveyFeatureTomb"); }
            set { SetPropertyValue("SurveyFeatureTomb", value); }
        }


        [Custom("Caption", "编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "类别")]
        public RemainType Type
        {
            get { return GetPropertyValue<RemainType>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "名称")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "数量")]
        public int Number
        {
            get { return GetPropertyValue<int>("Number"); }
            set { SetPropertyValue("Number", value); }
        }

        [Size(3000)]
        [Custom("Caption", "位置")]
        public string Location
        {
            get { return GetPropertyValue<string>("Location"); }
            set { SetPropertyValue("Location", value); }
        }

        [Custom("Caption", "记录者")]
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

        [Custom("Caption", "改号")]
        public Boolean IsIdChange
        {
            get { return GetPropertyValue<Boolean>("IsIdChange"); }
            set { SetPropertyValue("IsIdChange", value); }
        }

        [Size(3000)]
        [Custom("Caption", "备注")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

    }

}
