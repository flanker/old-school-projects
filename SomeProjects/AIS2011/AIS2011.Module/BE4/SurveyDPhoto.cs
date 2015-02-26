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
    [Custom("Caption", "调查数码照片登记")]
    public class SurveyDPhoto : BaseObject
    {
        public SurveyDPhoto(Session session) : base(session) { }

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
        [Association("SurveyFeatureSettlement-SurveyDPhoto", typeof(SurveyFeatureSettlement))]
        public SurveyFeatureSettlement SurveyFeatureSettlement
        {
            get { return GetPropertyValue<SurveyFeatureSettlement>("SurveyFeatureSettlement"); }
            set { SetPropertyValue("SurveyFeatureSettlement", value); }
        }

        [Custom("Caption", "对应列石遗迹编号")]
        [Association("SurveyFeatureAlignment-SurveyDPhoto", typeof(SurveyFeatureAlignment))]
        public SurveyFeatureAlignment SurveyFeatureAlignment
        {
            get { return GetPropertyValue<SurveyFeatureAlignment>("SurveyFeatureAlignment"); }
            set { SetPropertyValue("SurveyFeatureAlignment", value); }
        }

        [Custom("Caption", "对应鹿石遗迹编号")]
        [Association("SurveyFeatureDeerStone-SurveyDPhoto", typeof(SurveyFeatureDeerStone))]
        public SurveyFeatureDeerStone SurveyFeatureDeerStone
        {
            get { return GetPropertyValue<SurveyFeatureDeerStone>("SurveyFeatureDeerStone"); }
            set { SetPropertyValue("SurveyFeatureDeerStone", value); }
        }

        [Custom("Caption", "对应墓葬遗迹编号")]
        [Association("SurveyFeatureTomb-SurveyDPhoto", typeof(SurveyFeatureTomb))]
        public SurveyFeatureTomb SurveyFeatureTomb
        {
            get { return GetPropertyValue<SurveyFeatureTomb>("SurveyFeatureTomb"); }
            set { SetPropertyValue("SurveyFeatureTomb", value); }
        }


        //
        [Custom("Caption", "相机型号")]
        public CameraType CameraType
        {
            get { return GetPropertyValue<CameraType>("CameraType"); }
            set { SetPropertyValue("CameraType", value); }
        }

        [Custom("Caption", "照片编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "拍摄对象")]
        public string Object
        {
            get { return GetPropertyValue<string>("Object"); }
            set { SetPropertyValue("Object", value); }
        }

        [Custom("Caption", "描述")]
        public string Description
        {
            get { return GetPropertyValue<string>("Description"); }
            set { SetPropertyValue("Description", value); }
        }

        [Custom("Caption", "从")]
        public string DirectionFrom
        {
            get { return GetPropertyValue<string>("DirectionFrom"); }
            set { SetPropertyValue("DirectionFrom", value); }
        }

        [Custom("Caption", "到")]
        public string DirectionTo
        {
            get { return GetPropertyValue<string>("DirectionTo"); }
            set { SetPropertyValue("DirectionTo", value); }
        }

        [Custom("Caption", "拍摄方向")]
        public string Direction
        {
            get { return GetPropertyValue<string>("DirectionFrom") + "→" + GetPropertyValue<string>("DirectionTo"); }
        }

        [Custom("Caption", "天气")]
        public string Weather
        {
            get { return GetPropertyValue<string>("Weather"); }
            set { SetPropertyValue("Weather", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "记录时间（精确至分）")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "拍摄者")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        //[VisibleInListView(true)]
        //[DevExpress.Xpo.Size(SizeAttribute.Unlimited), ValueConverter(typeof(ImageValueConverter))]
        //[ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 40)]
        //[Custom("Caption", "照片")]
        //public Image Photo
        //{
        //    get { return GetPropertyValue<Image>("Photo"); }
        //    set { SetPropertyValue<Image>("Photo", value); }
        //}


    }

}
