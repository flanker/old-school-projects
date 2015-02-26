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
    [Custom("Caption", "�����ַ�Ǽ�")]
    public class SurveyFeatureSettlement : BaseObject
    {
        public SurveyFeatureSettlement(Session session) : base(session) { }

        //��¼�� ��¼ʱ��
        [Custom("Caption", "��¼��")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("Caption", "��¼����")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        //����
        [Custom("Caption", "����")]
        public string Weather
        {
            get { return GetPropertyValue<string>("Weather"); }
            set { SetPropertyValue("Weather", value); }
        }

        //��ַ����
        [Custom("Caption", "��ַ����")]
        public string SiteBelong
        {
            get { return GetPropertyValue<string>("SiteBelong"); }
            set { SetPropertyValue("SiteBelong", value); }
        }

        //��ַ���
        [Custom("Caption", "��ַ���")]
        public string SiteId
        {
            get { return GetPropertyValue<string>("SiteId"); }
            set { SetPropertyValue("SiteId", value); }
        }

        //���鷽��
        [Custom("Caption", "���鷽��")]
        public SurveyMethod SurveyMethod
        {
            get { return GetPropertyValue<SurveyMethod>("SurveyMethod"); }
            set { SetPropertyValue("SurveyMethod", value); }
        }

        //�������
        [Custom("Caption", "�������")]
        public string GridId
        {
            get { return GetPropertyValue<string>("GridId"); }
            set { SetPropertyValue("GridId", value); }
        }

        //Ĺ����
        [Custom("Caption", "��ַ���")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        //λ��
        [Custom("Caption", "λ��")]
        public string Location
        {
            get { return GetPropertyValue<string>("Location"); }
            set { SetPropertyValue("Location", value); }
        }
        //��γ����N E H
        [Custom("Caption", "N")]
        public float N
        {
            get { return GetPropertyValue<float>("N"); }
            set { SetPropertyValue("N", value); }
        }

        [Custom("Caption", "E")]
        public float E
        {
            get { return GetPropertyValue<float>("E"); }
            set { SetPropertyValue("E", value); }
        }

        [Custom("Caption", "H")]
        public float H
        {
            get { return GetPropertyValue<float>("H"); }
            set { SetPropertyValue("H", value); }
        }
        //ȫվ������X Y Z
        [Custom("Caption", "X")]
        public float X
        {
            get { return GetPropertyValue<float>("X"); }
            set { SetPropertyValue("X", value); }
        }

        [Custom("Caption", "Y")]
        public float Y
        {
            get { return GetPropertyValue<float>("Y"); }
            set { SetPropertyValue("Y", value); }
        }

        [Custom("Caption", "Z")]
        public float Z
        {
            get { return GetPropertyValue<float>("Z"); }
            set { SetPropertyValue("Z", value); }
        }

        //����λ��
        [Custom("Caption", "����λ��")]
        public string SurveyDrawLocation
        {
            get { return GetPropertyValue<string>("SurveyDrawLocation"); }
            set { SetPropertyValue("SurveyDrawLocation", value); }
        }

        //��淽ʽ ȫվ�� GPS
        [Custom("Caption", "��淽ʽ")]
        public SurveyDrawType SurveyDrawType
        {
            get { return GetPropertyValue<SurveyDrawType>("SurveyDrawType"); }
            set { SetPropertyValue("SurveyDrawType", value); }
        }

        //�����ͺ�
        [Custom("Caption", "�����ͺ�")]
        public string SurveyDrawTool
        {
            get { return GetPropertyValue<string>("SurveyDrawTool"); }
            set { SetPropertyValue("SurveyDrawTool", value); }
        }

        //�������� ��
        [Custom("Caption", "�������ȣ��ף�")]
        public string SurveyDrawDefinition
        {
            get { return GetPropertyValue<string>("SurveyDrawDefinition"); }
            set { SetPropertyValue("SurveyDrawDefinition", value); }
        }

        //������ һ�Զ�
        [Association("SurveyFeatureSettlement-Worker", typeof(Worker))]
        [Custom("Caption", "������")]
        public XPCollection Worker
        {
            get { return GetCollection("Worker"); }
        }

        //����·��
        [Custom("Caption", "����·��")]
        public string SurveyPath
        {
            get { return GetPropertyValue<string>("SurveyPath"); }
            set { SetPropertyValue("SurveyPath", value); }
        }

        //������״  ��-�Ϻ�-һ��-�ϲ�-��
        [Custom("Caption", "������״")]
        public SurveyProtectionSituation SurveyProtectionSituation
        {
            get { return GetPropertyValue<SurveyProtectionSituation>("SurveyProtectionSituation"); }
            set { SetPropertyValue("SurveyProtectionSituation", value); }
        }

        //��״����
        [Custom("Caption", "��״����")]
        public string SituationDescription
        {
            get { return GetPropertyValue<string>("SituationDescription"); }
            set { SetPropertyValue("SituationDescription", value); }
        }

        //���ԭ�� ��Ȼ���� ��Ϊ����
        [Custom("Caption", "��Ȼ����")]
        public NatureDamageType NatureDamageType
        {
            get { return GetPropertyValue<NatureDamageType>("NatureDamageType"); }
            set { SetPropertyValue("NatureDamageType", value); }
        }

        [Custom("Caption", "��Ϊ����")]
        public ArtifactDamageType ArtifactDamageType
        {
            get { return GetPropertyValue<ArtifactDamageType>("ArtifactDamageType"); }
            set { SetPropertyValue("ArtifactDamageType", value); }
        }

        //��Ȼ���� �ر������� ������ ���ε�ò
        [Custom("Caption", "�ر�������")]
        public string SurveySurfaceCovering
        {
            get { return GetPropertyValue<string>("SurveySurfaceCovering"); }
            set { SetPropertyValue("SurveySurfaceCovering", value); }
        }

        [Custom("Caption", "������")]
        public int SurveySurfaceCoveringRate
        {
            get { return GetPropertyValue<int>("SurveySurfaceCoveringRate"); }
            set { SetPropertyValue("SurveySurfaceCoveringRate", value); }
        }

        [Custom("Caption", "���ε�ò")]
        public string TerrainGround
        {
            get { return GetPropertyValue<string>("TerrainGround"); }
            set { SetPropertyValue("TerrainGround", value); }
        }

        //���Ļ���
        [Custom("Caption", "���Ļ���")]
        public string CultureEnvironment
        {
            get { return GetPropertyValue<string>("CultureEnvironment"); }
            set { SetPropertyValue("CultureEnvironment", value); }
        }

        //�ż�����

        //��λ��ϵ
        [Custom("Caption", "��λ��ϵ")]
        public string LayerRelation
        {
            get { return GetPropertyValue<string>("LayerRelation"); }
            set { SetPropertyValue("LayerRelation", value); }
        }
        // ƽ�� ���� ����
        [Custom("Caption", "ƽ����״")]
        public SurveyPlaneShape PlaneShape
        {
            get { return GetPropertyValue<SurveyPlaneShape>("PlaneShape"); }
            set { SetPropertyValue("PlaneShape", value); }
        }

        [Custom("Caption", "������״")]
        public SurveySideShape SideShape
        {
            get { return GetPropertyValue<SurveySideShape>("SideShape"); }
            set { SetPropertyValue("SideShape", value); }
        }

        [Custom("Caption", "������״")]
        public SurveyProfileShape ProfileShape
        {
            get { return GetPropertyValue<SurveyProfileShape>("ProfileShape"); }
            set { SetPropertyValue("ProfileShape", value); }
        }

        //ƽ�沼������
        [Custom("Caption", "ƽ�沼������")]
        public string PlaneLayourType
        {
            get { return GetPropertyValue<string>("PlaneLayourType"); }
            set { SetPropertyValue("PlaneLayourType", value); }
        }

        //ƽ�沼������
        [Custom("Caption", "ƽ�沼������")]
        public string PlaneLayourDescription
        {
            get { return GetPropertyValue<string>("PlaneLayourDescription"); }
            set { SetPropertyValue("PlaneLayourDescription", value); }
        }
        //�������� һ�Զ�
        [Association("SurveyFeatureSettlement-SurveySettlementSingle", typeof(SurveySettlementSingle))]
        [Custom("Caption", "��������")]
        public XPCollection SurveySettlementSingle
        {
            get { return GetCollection("SurveySettlementSingle"); }
        }

        //�ż��ṹ

        [Custom("Caption", "�ż��ṹ")]
        public string Structure
        {
            get { return GetPropertyValue<string>("Structure"); }
            set { SetPropertyValue("Structure", value); }
        }


        //��ͼ
        //[Custom("Caption", "��ͼ")]
        //[DevExpress.Xpo.Size(SizeAttribute.Unlimited), ValueConverter(typeof(ImageValueConverter))]
        //[ImageEditor(DetailViewImageEditorMode = ImageEditorMode.PictureEdit)]
        //public Image Sketch
        //{
        //    get { return GetPropertyValue<Image>("Sketch"); }
        //    set { SetPropertyValue<Image>("Sketch", value); }
        //}

        [Custom("Caption", "��ͼ")]
        public string Sketch
        {
            get { return GetPropertyValue<string>("Sketch"); }
            set { SetPropertyValue("Sketch", value); }
        }

        //������ʩ һ�Զ�
        [Association("SurveyFeatureSettlement-SurveyAddition", typeof(SurveyAddition))]
        [Custom("Caption", "������ʩ")]
        public XPCollection SurveyAddition
        {
            get { return GetCollection("SurveyAddition"); }
        }

        //����ɼ�  һ�Զ� 
        [Association("SurveyFeatureSettlement-SurveyRemainMark", typeof(SurveyRemainMark))]
        [Custom("Caption", "����ɼ�")]
        public XPCollection SurveyRemainMark
        {
            get { return GetCollection("SurveyRemainMark"); }
        }


        //���ܱ��ż���ϵ
        [Custom("Caption", "���ܱ��ż���ϵ")]
        public string FeatureRelation
        {
            get { return GetPropertyValue<string>("FeatureRelation"); }
            set { SetPropertyValue("FeatureRelation", value); }
        }

        //�����ж� ����
        [Custom("Caption", "�����ж�")]
        public string PropertyDetermine
        {
            get { return GetPropertyValue<string>("PropertyDetermine"); }
            set { SetPropertyValue("PropertyDetermine", value); }
        }

        [Custom("Caption", "�����ж�-����")]
        public string PropertyReason
        {
            get { return GetPropertyValue<string>("PropertyReason"); }
            set { SetPropertyValue("PropertyReason", value); }
        }

        //����ж� ����
        [Custom("Caption", "����ж�")]
        public string AgeDetermine
        {
            get { return GetPropertyValue<string>("AgeDetermine"); }
            set { SetPropertyValue("AgeDetermine", value); }
        }

        [Custom("Caption", "����ж�-����")]
        public string AgeReason
        {
            get { return GetPropertyValue<string>("AgeReason"); }
            set { SetPropertyValue("AgeReason", value); }
        }


        //�����ͼ���
        [Association("SurveyFeatureSettlement-SurveyPicture", typeof(SurveyPicture))]
        [Custom("Caption", "����ɼ�")]
        public XPCollection SurveyPicture
        {
            get { return GetCollection("SurveyPicture"); }
        }

        //����������
        [Association("SurveyFeatureSettlement-SurveyDPhoto", typeof(SurveyDPhoto))]
        [Custom("Caption", "����ɼ�")]
        public XPCollection SurveyDPhoto
        {
            get { return GetCollection("SurveyDPhoto"); }
        }
        //����� ���ʱ��
        [Custom("Caption", "�����")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }

        [Custom("Caption", "���ʱ��")]
        public DateTime CheckOn
        {
            get { return GetPropertyValue<DateTime>("CheckOn"); }
            set { SetPropertyValue("CheckOn", value); }
        }
    }

    public enum PlaneLayourType { δ֪, ����, ��临��ʽ, ���� }
}