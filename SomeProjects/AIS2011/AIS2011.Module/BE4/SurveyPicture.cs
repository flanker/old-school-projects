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
    [Custom("Caption", "�����ͼ�Ǽ�")]
    public class SurveyPicture : BaseObject
    {
        public SurveyPicture(Session session) : base(session) { }

        [Custom("Caption", "�����ż�")]
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

        [Custom("Caption", "��Ӧ��ַ�ż����")]
        [Association("SurveyFeatureSettlement-SurveyPicture", typeof(SurveyFeatureSettlement))]
        public SurveyFeatureSettlement SurveyFeatureSettlement
        {
            get { return GetPropertyValue<SurveyFeatureSettlement>("SurveyFeatureSettlement"); }
            set { SetPropertyValue("SurveyFeatureSettlement", value); }
        }

        [Custom("Caption", "��Ӧ��ʯ�ż����")]
        [Association("SurveyFeatureAlignment-SurveyPicture", typeof(SurveyFeatureAlignment))]
        public SurveyFeatureAlignment SurveyFeatureAlignment
        {
            get { return GetPropertyValue<SurveyFeatureAlignment>("SurveyFeatureAlignment"); }
            set { SetPropertyValue("SurveyFeatureAlignment", value); }
        }

        [Custom("Caption", "��Ӧ¹ʯ�ż����")]
        [Association("SurveyFeatureDeerStone-SurveyPicture", typeof(SurveyFeatureDeerStone))]
        public SurveyFeatureDeerStone SurveyFeatureDeerStone
        {
            get { return GetPropertyValue<SurveyFeatureDeerStone>("SurveyFeatureDeerStone"); }
            set { SetPropertyValue("SurveyFeatureDeerStone", value); }
        }

        [Custom("Caption", "��ӦĹ���ż����")]
        [Association("SurveyFeatureTomb-SurveyPicture", typeof(SurveyFeatureTomb))]
        public SurveyFeatureTomb SurveyFeatureTomb
        {
            get { return GetPropertyValue<SurveyFeatureTomb>("SurveyFeatureTomb"); }
            set { SetPropertyValue("SurveyFeatureTomb", value); }
        }

        [Custom("Caption", "����")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "���")]
        public PictureObjectType Type
        {
            get { return GetPropertyValue<PictureObjectType>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "��ͼ��")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "����")]
        public string Scale
        {
            get { return GetPropertyValue<string>("Scale"); }
            set { SetPropertyValue("Scale", value); }
        }


        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "��¼���ڣ���ȷ���֣�")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "��ͼ��ʽ")]
        public PictureMethod PictureMethod
        {
            get { return GetPropertyValue<PictureMethod>("PictureMethod"); }
            set { SetPropertyValue("PictureMethod", value); }
        }

        [Custom("Caption", "��ͼ��")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }


        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "������ڣ���ȷ���֣�")]
        public DateTime CheckOn
        {
            get { return GetPropertyValue<DateTime>("CheckOn"); }
            set { SetPropertyValue("CheckOn", value); }
        }

        [Custom("Caption", "�����")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }

        //[VisibleInListView(true)]
        //[DevExpress.Xpo.Size(SizeAttribute.Unlimited), ValueConverter(typeof(ImageValueConverter))]
        //[ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 40)]
        //[Custom("Caption", "��ͼ")]
        //public Image Picture
        //{
        //    get { return GetPropertyValue<Image>("Picture"); }
        //    set { SetPropertyValue<Image>("Picture", value); }
        //}
    }
}
