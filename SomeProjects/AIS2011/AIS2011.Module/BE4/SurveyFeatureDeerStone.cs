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
    [Custom("Caption", "����¹ʯ�Ǽ�")]
    public class SurveyFeatureDeerStone : BaseObject
    {
        public SurveyFeatureDeerStone(Session session) : base(session) { }

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

        //¹ʯ���
        [Custom("Caption", "¹ʯ���")]
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

        //������ ��Զ�
        [Association("SurveyFeatureDeerStone-Worker", typeof(Worker))]
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

        //��Ȼ���� �ر����� ������ ���ε�ò
        [Custom("Caption", "�ر�����")]
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
        //ʯ��-��ɫ-������״-������״
        [Custom("Caption", "ʯ��")]
        public string Texture
        {
            get { return GetPropertyValue<string>("Texture"); }
            set { SetPropertyValue("Texture", value); }
        }

        [Custom("Caption", "��ɫ")]
        public string Color
        {
            get { return GetPropertyValue<string>("Color"); }
            set { SetPropertyValue("Color", value); }
        }


        [Custom("Caption", "������״")]
        public string ElevationShape
        {
            get { return GetPropertyValue<string>("ElevationShape"); }
            set { SetPropertyValue("ElevationShape", value); }
        }

        [Custom("Caption", "������״")]
        public string SectionShape
        {
            get { return GetPropertyValue<string>("SectionShape"); }
            set { SetPropertyValue("SectionShape", value); }
        }

        //����ѡȡ:��Ȼ��ʯ/�˹��ӹ�
        [Custom("Caption", "����ѡȡ")]
        public SurveyDeerStoneMaterial SurveyDeerStoneMaterial
        {
            get { return GetPropertyValue<SurveyDeerStoneMaterial>("SurveyDeerStoneMaterial"); }
            set { SetPropertyValue("SurveyDeerStoneMaterial", value); }
        }

        //�������� ����/ĥ��
        [Custom("Caption", "��������")]
        public SurveyDeerStoneMethod SurveyDeerStoneMethod
        {
            get { return GetPropertyValue<SurveyDeerStoneMethod>("SurveyDeerStoneMethod"); }
            set { SetPropertyValue("SurveyDeerStoneMethod", value); }
        }
        
        //�ߴ� �ر��� �����cm ���²��� �����cm
        [Custom("Caption", "�ر���-����m��")]
        public float GroundLength
        {
            get { return GetPropertyValue<float>("GroundLength"); }
            set { SetPropertyValue("GroundLength", value); }
        }

        [Custom("Caption", "�ر���-��m��")]
        public float GroundThickness
        {
            get { return GetPropertyValue<float>("GroundThickness"); }
            set { SetPropertyValue("GroundThickness", value); }
        }

        [Custom("Caption", "�ر���-�ߣ�m��")]
        public float GroundHeight
        {
            get { return GetPropertyValue<float>("GroundHeight"); }
            set { SetPropertyValue("GroundHeight", value); }
        }
        [Custom("Caption", "���²���-����m��")]
        public float UnderGroundLength
        {
            get { return GetPropertyValue<float>("UnderGroundLength"); }
            set { SetPropertyValue("UnderGroundLength", value); }
        }

        [Custom("Caption", "���²���-��m��")]
        public float UnderGroundThickness
        {
            get { return GetPropertyValue<float>("UnderGroundThickness"); }
            set { SetPropertyValue("UnderGroundThickness", value); }
        }

        [Custom("Caption", "���²���-�ߣ�m��")]
        public float UnderGroundHeight
        {
            get { return GetPropertyValue<float>("UnderGroundHeight"); }
            set { SetPropertyValue("UnderGroundHeight", value); }
        }

        //ͼ������ 
        //ͼ������ ������ װ���� �������� 
        [Custom("Caption", "������")]
        public SurveyDeerStoneAnimal SurveyDeerStoneAnimal
        {
            get { return GetPropertyValue<SurveyDeerStoneAnimal>("SurveyDeerStoneAnimal"); }
            set { SetPropertyValue("SurveyDeerStoneAnimal", value); }
        }


        [Custom("Caption", "װ����")]
        public SurveyDeerStoneAdornment SurveyDeerStoneAdornment
        {
            get { return GetPropertyValue<SurveyDeerStoneAdornment>("SurveyDeerStoneAdornment"); }
            set { SetPropertyValue("SurveyDeerStoneAdornment", value); }
        }

        [Custom("Caption", "��������")]
        public SurveyDeerStoneArm SurveyDeerStoneArm
        {
            get { return GetPropertyValue<SurveyDeerStoneArm>("SurveyDeerStoneArm"); }
            set { SetPropertyValue("SurveyDeerStoneArm", value); }
        }

        //�������� ǰ�� ����� �Ҳ��� ����
        [Custom("Caption", "ǰ������")]
        public string FrontDescription
        {
            get { return GetPropertyValue<string>("FrontDescription"); }
            set { SetPropertyValue("FrontDescription", value); }
        }

        [Custom("Caption", "���������")]
        public string LeftSideDescription
        {
            get { return GetPropertyValue<string>("LeftSideDescription"); }
            set { SetPropertyValue("LeftSideDescription", value); }
        }

        [Custom("Caption", "�Ҳ�������")]
        public string RightSideDescription
        {
            get { return GetPropertyValue<string>("RightSideDescription"); }
            set { SetPropertyValue("RightSideDescription", value); }
        }

        [Custom("Caption", "��������")]
        public string BackDescription
        {
            get { return GetPropertyValue<string>("BackDescription"); }
            set { SetPropertyValue("BackDescription", value); }
        }

        //����
        [Custom("Caption", "����")]
        public string Total
        {
            get { return GetPropertyValue<string>("Total"); }
            set { SetPropertyValue("Total", value); }
        }

        //������ʩ һ�Զ�
        [Association("SurveyFeatureDeerStone-SurveyAddition", typeof(SurveyAddition))]
        [Custom("Caption", "������ʩ")]
        public XPCollection SurveyAddition
        {
            get { return GetCollection("SurveyAddition"); }
        }

        //����ɼ�  һ�Զ� 
        [Association("SurveyFeatureDeerStone-SurveyRemainMark", typeof(SurveyRemainMark))]
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
        [Association("SurveyFeatureDeerStone-SurveyPicture", typeof(SurveyPicture))]
        [Custom("Caption", "����ɼ�")]
        public XPCollection SurveyPicture
        {
            get { return GetCollection("SurveyPicture"); }
        }

        //����������
        [Association("SurveyFeatureDeerStone-SurveyDPhoto", typeof(SurveyDPhoto))]
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
    public enum SurveyDeerStoneMaterial {δ֪, ��Ȼ��ʯ, �˹��ӹ� }
    public enum SurveyDeerStoneMethod { δ֪, ����, ĥ�� }

    public enum SurveyDeerStoneAnimal { δ֪, ��Ȼдʵ��¹����, ͼ����װ����¹����, ��, ţ, ��, ¿, ��, ��, ��, ����, Ұ��, ���� }
    public enum SurveyDeerStoneAdornment { δ֪, ����, ����, ����, ͭ��, ������, ��, ��, ���� }
    public enum SurveyDeerStoneArm { δ֪, ��, ��, ����, ��, ��, ��ʯ, Ȩ��, ��, ���ι�, ���� }

}
