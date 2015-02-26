using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo.Metadata;

namespace kaogu_0730.Module
{
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Id")]
    [Custom("Caption", "调查绘图登记")]
    public class SurveyPicture : BaseObject
    {
        public SurveyPicture(Session session) : base(session) { }

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
        [Association("SurveyFeatureSettlement-SurveyPicture", typeof(SurveyFeatureSettlement))]
        public SurveyFeatureSettlement SurveyFeatureSettlement
        {
            get { return GetPropertyValue<SurveyFeatureSettlement>("SurveyFeatureSettlement"); }
            set { SetPropertyValue("SurveyFeatureSettlement", value); }
        }

        [Custom("Caption", "对应列石遗迹编号")]
        [Association("SurveyFeatureAlignment-SurveyPicture", typeof(SurveyFeatureAlignment))]
        public SurveyFeatureAlignment SurveyFeatureAlignment
        {
            get { return GetPropertyValue<SurveyFeatureAlignment>("SurveyFeatureAlignment"); }
            set { SetPropertyValue("SurveyFeatureAlignment", value); }
        }

        [Custom("Caption", "对应鹿石遗迹编号")]
        [Association("SurveyFeatureDeerStone-SurveyPicture", typeof(SurveyFeatureDeerStone))]
        public SurveyFeatureDeerStone SurveyFeatureDeerStone
        {
            get { return GetPropertyValue<SurveyFeatureDeerStone>("SurveyFeatureDeerStone"); }
            set { SetPropertyValue("SurveyFeatureDeerStone", value); }
        }

        [Custom("Caption", "对应墓葬遗迹编号")]
        [Association("SurveyFeatureTomb-SurveyPicture", typeof(SurveyFeatureTomb))]
        public SurveyFeatureTomb SurveyFeatureTomb
        {
            get { return GetPropertyValue<SurveyFeatureTomb>("SurveyFeatureTomb"); }
            set { SetPropertyValue("SurveyFeatureTomb", value); }
        }

        [Custom("Caption", "名称")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "类别")]
        public PictureObjectType Type
        {
            get { return GetPropertyValue<PictureObjectType>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "绘图号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "比例")]
        public string Scale
        {
            get { return GetPropertyValue<string>("Scale"); }
            set { SetPropertyValue("Scale", value); }
        }


        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "记录日期（精确到分）")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "绘图方式")]
        public PictureMethod PictureMethod
        {
            get { return GetPropertyValue<PictureMethod>("PictureMethod"); }
            set { SetPropertyValue("PictureMethod", value); }
        }

        [Custom("Caption", "绘图人")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }


        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "审核日期（精确到分）")]
        public DateTime CheckOn
        {
            get { return GetPropertyValue<DateTime>("CheckOn"); }
            set { SetPropertyValue("CheckOn", value); }
        }

        [Custom("Caption", "审核人")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }

        //[VisibleInListView(true)]
        //[DevExpress.Xpo.Size(SizeAttribute.Unlimited), ValueConverter(typeof(ImageValueConverter))]
        //[ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 40)]
        //[Custom("Caption", "绘图")]
        //public Image Picture
        //{
        //    get { return GetPropertyValue<Image>("Picture"); }
        //    set { SetPropertyValue<Image>("Picture", value); }
        //}
    }
}
