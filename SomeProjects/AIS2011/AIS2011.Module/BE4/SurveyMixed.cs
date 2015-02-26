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
    [Custom("Caption", "�ż�-������ʩ")]
    [System.ComponentModel.DefaultProperty("Id")]
    [DefaultClassOptions]
    public class SurveyAddition : BaseObject
    {
        public SurveyAddition(Session session) : base(session) { }

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
        [Association("SurveyFeatureSettlement-SurveyAddition", typeof(SurveyFeatureSettlement))]
        public SurveyFeatureSettlement SurveyFeSurveyFeatureSettlementatureTomb
        {
            get { return GetPropertyValue<SurveyFeatureSettlement>("SurveyFeatureSettlement"); }
            set { SetPropertyValue("SurveyFeatureSettlement", value); }
        }

        [Custom("Caption", "��Ӧ��ʯ�ż����")]
        [Association("SurveyFeatureAlignment-SurveyAddition", typeof(SurveyFeatureAlignment))]
        public SurveyFeatureAlignment SurveyFeatureAlignment
        {
            get { return GetPropertyValue<SurveyFeatureAlignment>("SurveyFeatureAlignment"); }
            set { SetPropertyValue("SurveyFeatureAlignment", value); }
        }

        [Custom("Caption", "��Ӧ¹ʯ�ż����")]
        [Association("SurveyFeatureDeerStone-SurveyAddition", typeof(SurveyFeatureDeerStone))]
        public SurveyFeatureDeerStone SurveyFeatureDeerStone
        {
            get { return GetPropertyValue<SurveyFeatureDeerStone>("SurveyFeatureDeerStone"); }
            set { SetPropertyValue("SurveyFeatureDeerStone", value); }
        }

        [Custom("Caption", "��ӦĹ���ż����")]
        [Association("SurveyFeatureTomb-SurveyAddition", typeof(SurveyFeatureTomb))]
        public SurveyFeatureTomb SurveyFeatureTomb
        {
            get { return GetPropertyValue<SurveyFeatureTomb>("SurveyFeatureTomb"); }
            set { SetPropertyValue("SurveyFeatureTomb", value); }
        }


        [Custom("Caption", "λ��")]
        public string Location
        {
            get { return GetPropertyValue<string>("Location"); }
            set { SetPropertyValue("Location", value); }
        }

        [Custom("Caption", "���")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "����")]
        public string Number
        {
            get { return GetPropertyValue<string>("Number"); }
            set { SetPropertyValue("Number", value); }
        }

        [Custom("Caption", "���")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }
    }

    [Custom("Caption", "��ַ-��������")]
    [System.ComponentModel.DefaultProperty("Id")]
    [DefaultClassOptions]
    public class SurveySettlementSingle : BaseObject
    {
        public SurveySettlementSingle(Session session) : base(session) { }

        [Custom("Caption", "������ַ")]
        [Association("SurveyFeatureSettlement-SurveySettlementSingle", typeof(SurveyFeatureSettlement))]
        public SurveyFeatureSettlement SurveyFeatureSettlement
        {
            get { return GetPropertyValue<SurveyFeatureSettlement>("SurveyFeatureSettlement"); }
            set { SetPropertyValue("SurveyFeatureSettlement", value); }
        }

        //��ַ����
        //���� �����m ǽ������

        [Custom("Caption", "����-����m��")]
        public float OutlineLength
        {
            get { return GetPropertyValue<float>("OutlineLength"); }
            set { SetPropertyValue("OutlineLength", value); }
        }

        [Custom("Caption", "����-��m��")]
        public float OutlineWidth
        {
            get { return GetPropertyValue<float>("OutlineWidth"); }
            set { SetPropertyValue("OutlineWidth", value); }
        }

        [Custom("Caption", "����-�ߣ�m��")]
        public float OutlineHeight
        {
            get { return GetPropertyValue<float>("OutlineHeight"); }
            set { SetPropertyValue("OutlineHeight", value); }
        }

        [Custom("Caption", "ǽ������")]
        public int WallRootNumber
        {
            get { return GetPropertyValue<int>("WallRootNumber"); }
            set { SetPropertyValue("WallRootNumber", value); }
        }

        //�ھ� ����� ���m

        [Custom("Caption", "�ھ�-����m��")]
        public float InnerLength
        {
            get { return GetPropertyValue<float>("InnerLength"); }
            set { SetPropertyValue("InnerLength", value); }
        }

        [Custom("Caption", "�ھ�-��m��")]
        public float InnerWidth
        {
            get { return GetPropertyValue<float>("InnerWidth"); }
            set { SetPropertyValue("InnerWidth", value); }
        }

        [Custom("Caption", "�ھ�-�ߣ�m��")]
        public float InnerHeight
        {
            get { return GetPropertyValue<float>("InnerHeight"); }
            set { SetPropertyValue("InnerHeight", value); }
        }

        [Custom("Caption", "�ھ�-�m��")]
        public float InnerDepth
        {
            get { return GetPropertyValue<float>("InnerDepth"); }
            set { SetPropertyValue("InnerDepth", value); }
        }
        //�ŵ� λ�� ���� ���m

        [Custom("Caption", "�ŵ�-λ��")]
        public string DoorwayLocation
        {
            get { return GetPropertyValue<string>("DoorwayLocation"); }
            set { SetPropertyValue("DoorwayLocation", value); }
        }

        [Custom("Caption", "�ŵ�-����")]
        public int DoorwayQuantity
        {
            get { return GetPropertyValue<int>("DoorwayQuantity"); }
            set { SetPropertyValue("DoorwayQuantity", value); }
        }

        [Custom("Caption", "�ŵ�-���")]
        public float DoorwayWidth
        {
            get { return GetPropertyValue<float>("DoorwayWidth"); }
            set { SetPropertyValue("DoorwayWidth", value); }
        }
        //�ѻ����� 
        //ʯ ��״ ��ɫ ʯ�� �ߴ�
        [Custom("Caption", "ʯ-��״")]
        public string StoneShape
        {
            get { return GetPropertyValue<string>("StoneShape"); }
            set { SetPropertyValue("StoneShape", value); }
        }

        [Custom("Caption", "ʯ-��ɫ")]
        public string StoneColor
        {
            get { return GetPropertyValue<string>("StoneColor"); }
            set { SetPropertyValue("StoneColor", value); }
        }

        [Custom("Caption", "ʯ��")]
        public string StoneTexture
        {
            get { return GetPropertyValue<string>("StoneTexture"); }
            set { SetPropertyValue("StoneTexture", value); }
        }

        [Custom("Caption", "ʯ-�ߴ�")]
        public string StoneSize
        {
            get { return GetPropertyValue<string>("StoneSize"); }
            set { SetPropertyValue("StoneSize", value); }
        }
        //�� ���� ��ɫ ������ 

        [Custom("Caption", "��-����")]
        public string SoilTexture
        {
            get { return GetPropertyValue<string>("SoilTexture"); }
            set { SetPropertyValue("SoilTexture", value); }
        }

        [Custom("Caption", "��-��ɫ")]
        public string SoilColor
        {
            get { return GetPropertyValue<string>("SoilColor"); }
            set { SetPropertyValue("SoilColor", value); }
        }

        [Custom("Caption", "��-������")]
        public string SoilContain
        {
            get { return GetPropertyValue<string>("SoilContain"); }
            set { SetPropertyValue("SoilContain", value); }
        }
        //�ѻ����� ����

        [Custom("Caption", "����")]
        public string Other
        {
            get { return GetPropertyValue<string>("Other"); }
            set { SetPropertyValue("Other", value); }
        }
    }
}
