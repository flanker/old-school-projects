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
    [Custom("Caption", "�ѻ��Ǽ�")]
    public class Accumulation : BaseObject
    {
        public Accumulation(Session session) : base(session) { }

        [Custom("Caption", "��¼��")]
        public Worker RecordBy
        {
            get { return GetPropertyValue<Worker>("RecordBy"); }
            set { SetPropertyValue("RecordBy", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "��¼ʱ�䣨��ȷ���֣�")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        //������ַ

        //�ż����
        [Custom("Caption", "�ż����")]
        public FeatureMark FeatureMark
        {
            get { return GetPropertyValue<FeatureMark>("FeatureMark"); }
            set { SetPropertyValue("FeatureMark", value); }
        }

        [Custom("Caption", "�ѻ����")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        //�ż�����
        [Custom("Caption", "�Ƿ�����")]
        public IsMainOrPart MainOrPart
        {
            get { return GetPropertyValue<IsMainOrPart>("MainOrPart"); }
            set { SetPropertyValue("MainOrPart", value); }
        }

        [Association("Accumulation-Worker", typeof(Worker))]
        [Custom("Caption", "������Ա")]
        public XPCollection Worker
        {
            get { return GetCollection("Worker"); }
        }

        [Custom("Caption", "����������")]
        public DateTime StartOn
        {
            get { return GetPropertyValue<DateTime>("StartOn"); }
            set { SetPropertyValue("StartOn", value); }
        }

        [Custom("Caption", "����������")]
        public DateTime EndOn
        {
            get { return GetPropertyValue<DateTime>("EndOn"); }
            set { SetPropertyValue("EndOn", value); }
        }

        [Custom("Caption", "�ù�")]
        public string FWorker
        {
            get { return GetPropertyValue<string>("FWorker"); }
            set { SetPropertyValue("EndOn", value); }
        }


        //����λ��
        [Custom("Caption", "��������")]
        public string GPS
        {
            get { return GetPropertyValue<string>("GPS"); }
            set { SetPropertyValue("GPS", value); }
        }

        [Custom("Caption", "����λ������һ")]
        public string GPSDescription
        {
            get { return GetPropertyValue<string>("GPSDescription"); }
            set { SetPropertyValue("GPSDescription", value); }
        }

        [Custom("Caption", "��������")] //ȫվ��
        public string TotalStation
        {
            get { return GetPropertyValue<string>("TotalStation"); }
            set { SetPropertyValue("TotalStation", value); }
        }

        [Custom("Caption", "����λ��������")]
        public string TotalStationDescription
        {
            get { return GetPropertyValue<string>("TotalStationDescription"); }
            set { SetPropertyValue("TotalStationDescription", value); }
        }

        [Custom("Caption", "�����ż���")]
        public string BelongFeature
        {
            get { return GetPropertyValue<string>("BelongFeature"); }
            set { SetPropertyValue("BelongFeature", value); }
        }

        [Custom("Caption", "����״��")]
        public string Protection
        {
            get { return GetPropertyValue<string>("Protection"); }
            set { SetPropertyValue("Protection", value); }
        }

        [Custom("Caption", "����ʽ")]
        public string CleanType
        {
            get { return GetPropertyValue<string>("CleanType"); }
            set { SetPropertyValue("CleanType", value); }
        }

        [Custom("Caption", "�ֲ���Χ")]
        public string SpreadScope
        {
            get { return GetPropertyValue<string>("SpreadScope"); }
            set { SetPropertyValue("SpreadScope", value); }
        }

        //��״shape

        [Custom("Caption", "ƽ����״")]
        public AccPlaneShape AccPlaneShape
        {
            get { return GetPropertyValue<AccPlaneShape>("AccPlaneShape"); }
            set { SetPropertyValue("AccPlaneShape", value); }
        }

        [Custom("Caption", "������״")]
        public AccFaceShape AccFaceShape
        {
            get { return GetPropertyValue<AccFaceShape>("AccFaceShape"); }
            set { SetPropertyValue("AccFaceShape", value); }
        }

        [Custom("Caption", "������״���ߣ�")]
        public AccProfileSideShape AccProfileSideShape
        {
            get { return GetPropertyValue<AccProfileSideShape>("AccProfileSideShape"); }
            set { SetPropertyValue("AccProfileSideShape", value); }
        }

        [Custom("Caption", "������״���ף�")]
        public AccProfileBottomShape AccProfileBottomShape
        {
            get { return GetPropertyValue<AccProfileBottomShape>("AccProfileBottomShape"); }
            set { SetPropertyValue("AccProfileBottomShape", value); }
        }

        //����
        //ƽ��

        [Custom("Caption", "ƽ�淽��һ")]
        public string PlaneDirection1
        {
            get { return GetPropertyValue<string>("PlaneDirection1"); }
            set { SetPropertyValue("PlaneDirection1", value); }
        }

        [Custom("Caption", "�Ƿ񳤻�ֱ��")]
        public IsLengthOrDiameter IsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("IsLengthOrDiameter"); }
            set { SetPropertyValue("IsLengthOrDiameter", value); }
        }

        [Custom("Caption", "��/ֱ����m��")]
        public float PlaneDirectionLength
        {
            get { return GetPropertyValue<float>("PlaneDirectionLength"); }
            set { SetPropertyValue("PlaneDirectionLength", value); }
        }

        [Custom("Caption", "ƽ�淽���")]
        public string PlaneDirection2
        {
            get { return GetPropertyValue<string>("PlaneDirection2"); }
            set { SetPropertyValue("PlaneDirection2", value); }
        }

        [Custom("Caption", "��m��")]
        public float PlaneDirectionWidth
        {
            get { return GetPropertyValue<float>("PlaneDirectionWidth"); }
            set { SetPropertyValue("PlaneDirectionWidth", value); }
        }

        //���棨m��
        [Custom("Caption", "�Ƿ���Ȼ�߶�")]
        public IsDepthOrHeight IsDepthOrHeight
        {
            get { return GetPropertyValue<IsDepthOrHeight>("IsDepthOrHeight"); }
            set { SetPropertyValue("IsDepthOrHeight", value); }
        }

        //����Surface
        [Custom("Caption", "����")]
        public float SurfaceSouthEast
        {
            get { return GetPropertyValue<float>("SurfaceSouthEast"); }
            set { SetPropertyValue("SurfaceSouthEast", value); }
        }

        [Custom("Caption", "����")]
        public float SurfaceSouthWest
        {
            get { return GetPropertyValue<float>("SurfaceSouthWest"); }
            set { SetPropertyValue("SurfaceSouthWest", value); }
        }

        [Custom("Caption", "�в�")]
        public float SurfaceMiddle
        {
            get { return GetPropertyValue<float>("SurfaceMiddle"); }
            set { SetPropertyValue("SurfaceMiddle", value); }
        }

        [Custom("Caption", "����")]
        public float SurfaceNorthEast
        {
            get { return GetPropertyValue<float>("SurfaceNorthEast"); }
            set { SetPropertyValue("SurfaceNorthEast", value); }
        }

        [Custom("Caption", "����")]
        public float SurfaceNorthWest
        {
            get { return GetPropertyValue<float>("SurfaceNorthWest"); }
            set { SetPropertyValue("SurfaceNorthWest", value); }
        }

        [Custom("Caption", "���")]
        public float SurfaceHighest
        {
            get { return GetPropertyValue<float>("SurfaceHighest"); }
            set { SetPropertyValue("SurfaceHighest", value); }
        }

        [Custom("Caption", "λ��")]
        public string SurfaceHighestPosition
        {
            get { return GetPropertyValue<string>("SurfaceHighestPosition"); }
            set { SetPropertyValue("SurfaceHighestPosition", value); }
        }


        [Custom("Caption", "���")]
        public float SurfaceLowest
        {
            get { return GetPropertyValue<float>("SurfaceLowest"); }
            set { SetPropertyValue("SurfaceLowest", value); }
        }

        [Custom("Caption", "λ��")]
        public string SurfaceLowestPosition
        {
            get { return GetPropertyValue<string>("SurfaceLowestPosition"); }
            set { SetPropertyValue("SurfaceLowestPosition", value); }
        }

        //����Floor

        [Custom("Caption", "����")]
        public float FloorSouthEast
        {
            get { return GetPropertyValue<float>("FloorSouthEast"); }
            set { SetPropertyValue("FloorSouthEast", value); }
        }

        [Custom("Caption", "����")]
        public float FloorSouthWest
        {
            get { return GetPropertyValue<float>("FloorSouthWest"); }
            set { SetPropertyValue("FloorSouthWest", value); }
        }

        [Custom("Caption", "�в�")]
        public float FloorMiddle
        {
            get { return GetPropertyValue<float>("FloorMiddle"); }
            set { SetPropertyValue("FloorMiddle", value); }
        }

        [Custom("Caption", "����")]
        public float FloorNorthEast
        {
            get { return GetPropertyValue<float>("FloorNorthEast"); }
            set { SetPropertyValue("FloorNorthEast", value); }
        }

        [Custom("Caption", "����")]
        public float FloorNorthWest
        {
            get { return GetPropertyValue<float>("FloorNorthWest"); }
            set { SetPropertyValue("FloorNorthWest", value); }
        }

        [Custom("Caption", "���")]
        public float FloorHighest
        {
            get { return GetPropertyValue<float>("FloorHighest"); }
            set { SetPropertyValue("FloorHighest", value); }
        }

        [Custom("Caption", "λ��")]
        public string FloorHighestPosition
        {
            get { return GetPropertyValue<string>("FloorHighestPosition"); }
            set { SetPropertyValue("FloorHighestPosition", value); }
        }


        [Custom("Caption", "���")]
        public float FloorLowest
        {
            get { return GetPropertyValue<float>("FloorLowest"); }
            set { SetPropertyValue("FloorLowest", value); }
        }

        [Custom("Caption", "λ��")]
        public string FloorLowestPosition
        {
            get { return GetPropertyValue<string>("FloorLowestPosition"); }
            set { SetPropertyValue("FloorLowestPosition", value); }
        }

        //���

        [Custom("Caption", "���")]
        public float Thickest
        {
            get { return GetPropertyValue<float>("Thickest"); }
            set { SetPropertyValue("Thickest", value); }
        }

        [Custom("Caption", "λ��")]
        public string ThickestPosition
        {
            get { return GetPropertyValue<string>("ThickestPosition"); }
            set { SetPropertyValue("ThickestPosition", value); }
        }


        [Custom("Caption", "�")]
        public float Thinest
        {
            get { return GetPropertyValue<float>("Thinest"); }
            set { SetPropertyValue("Thinest", value); }
        }

        [Custom("Caption", "λ��")]
        public string ThinestPosition
        {
            get { return GetPropertyValue<string>("ThinestPosition"); }
            set { SetPropertyValue("ThinestPosition", value); }
        }

        //����

        [Custom("Caption", "����")]
        public SoilProperty SoilProperty
        {
            get { return GetPropertyValue<SoilProperty>("SoilProperty"); }
            set { SetPropertyValue("SoilProperty", value); }
        }

        [Custom("Caption", "��ɫ")]
        public string SoilColor
        {
            get { return GetPropertyValue<string>("SoilColor"); }
            set { SetPropertyValue("SoilColor", value); }
        }

        [Custom("Caption", "���ܶ�")]
        public Density Density
        {
            get { return GetPropertyValue<Density>("Density"); }
            set { SetPropertyValue("Density", value); }
        }

        //������

        [Custom("Caption", "������")]
        [Association("Accumulation-AccumulationContain", typeof(AccumulationContain))]
        public XPCollection AccumulationContain
        {
            get { return GetCollection("AccumulationContain"); }
        }

        //��λ��ϵ
        [Custom("Caption", "��λ��ϵ")]
        [Association("Accumulation-Layer", typeof(Layer))]
        public XPCollection Layer
        {
            get { return GetCollection("Layer"); }
        }


        [Custom("Caption", "��������")]
        public string LayerDescription
        {
            get { return GetPropertyValue<string>("LayerDescription"); }
            set { SetPropertyValue("LayerDescription", value); }
        }

        [Custom("Caption", "����ɼ�")]
        [Association("Accumulation-RemainMark", typeof(RemainMark))]
        public XPCollection RemainMark
        {
            get { return GetCollection("RemainMark"); }
        }

        [Custom("Caption", "����")]
        [Association("Accumulation-Sign", typeof(Sign))]
        public XPCollection Sign
        {
            get { return GetCollection("Sign"); }
        }

        [Custom("Caption", "�������໥��ϵ")]
        public string SignRelation
        {
            get { return GetPropertyValue<string>("SignRelation"); }
            set { SetPropertyValue("SignRelation", value); }
        }

        [Custom("Caption", "��������")]
        public string TotalDescription
        {
            get { return GetPropertyValue<string>("TotalDescription"); }
            set { SetPropertyValue("TotalDescription", value); }
        }

        [Custom("Caption", "�ѻ������жϼ�����")]
        public string PropertyAndReason
        {
            get { return GetPropertyValue<string>("PropertyAndReason"); }
            set { SetPropertyValue("PropertyAndReason", value); }
        }

        [Custom("Caption", "�ѻ����ۼ������ܽ�")]
        public string Summary
        {
            get { return GetPropertyValue<string>("Summary"); }
            set { SetPropertyValue("Summary", value); }
        }

        [Custom("Caption", "��ע")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

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


        //̽��-���ż� �����ѻ�
        [Custom("Caption", "����̽��")]
        [Association("ExcavationTrench-Accumulation", typeof(ExcavationTrench))]
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

                if (GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole") != null)
                { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile") != null)
                { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole1") != null)
                { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole1").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole2") != null)
                { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole2").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole") != null)
                { return GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole").ToString(); }
                else if (GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb1") != null)
                { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb1").ToString(); }
                else if (GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2") != null)
                { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2").ToString(); }
                else if (GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb3") != null)
                { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb3").ToString(); }
                else return null;
            }
        }

        [Custom("Caption", "��Ӧ��״�ż�")]
        [Association("ExcavationFeatureHole-Accumulation", typeof(ExcavationFeatureHole))]
        public ExcavationFeatureHole ExcavationFeatureHole
        {
            get { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole"); }
            set { SetPropertyValue("ExcavationFeatureHole", value); }
        }

        [Custom("Caption", "��Ӧ��״�ż�")]
        [Association("ExcavationFeaturePile-Accumulation", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile"); }
            set { SetPropertyValue("ExcavationFeaturePile", value); }
        }

        [Custom("Caption", "��Ӧ���Ӷ�״�ż�-�ر���")]
        [Association("ExcavationFeaturePileHole-Accumulation1", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole1
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole1"); }
            set { SetPropertyValue("ExcavationFeaturePileHole1", value); }
        }

        [Custom("Caption", "��Ӧ���Ӷ�״�ż�-���½���")]
        [Association("ExcavationFeaturePileHole-Accumulation2", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole2
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole2"); }
            set { SetPropertyValue("ExcavationFeaturePileHole2", value); }
        }

        [Custom("Caption", "��Ӧ�����ż�")]
        [Association("ExcavationFeaturePillarHole-Accumulation", typeof(ExcavationFeaturePillarHole))]
        public ExcavationFeaturePillarHole ExcavationFeaturePillarHole
        {
            get { return GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole"); }
            set { SetPropertyValue("ExcavationFeaturePillarHole", value); }
        }

        [Custom("Caption", "��ӦĹ���ż�-�ر���")]
        [Association("ExcavationFeatureTomb-Accumulation1", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb1
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb1"); }
            set { SetPropertyValue("ExcavationFeatureTomb1", value); }
        }

        [Custom("Caption", "��ӦĹ���ż�-Ĺ��")]
        [Association("ExcavationFeatureTomb-Accumulation2", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb2
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2"); }
            set { SetPropertyValue("ExcavationFeatureTomb2", value); }
        }

        [Custom("Caption", "��ӦĹ���ż�-Ĺ��")]
        [Association("ExcavationFeatureTomb-Accumulation3", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb3
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb3"); }
            set { SetPropertyValue("ExcavationFeatureTomb3", value); }
        }


    }
    public enum AccPlaneShape { δ֪, Բ��, ����, Բ�Ƿ���, ����, ����, ��Բ��, ��Բ��, ������, ��������, ���� }
    public enum AccFaceShape { δ֪, ��״, Ͳ״, ��״, ˮƽ״, ��״, ��״, ͹��״, ����״, ���� }
    public enum AccProfileSideShape { δ֪, ׶��, Ͳ��, ����, ����, ���� }
    public enum AccProfileBottomShape { δ֪, ƽ��, Բ��, ���, б��, ͹��, ���� }

    public enum IsLengthOrDiameter { δ֪, ��, ֱ�� }
    public enum IsDepthOrHeight { δ֪, ���, �߶� }
    public enum SoilProperty { δ֪, ճ��, ��ɳ��, ϸɳ��, ��ɳ��, ϸ��, ���� }
    public enum Density { δ֪, ����, ������, ������, ���� }

    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Id")]
    [Custom("Caption", "�ѻ�������")]
    public class AccumulationContain : BaseObject
    {
        public AccumulationContain(Session session) : base(session) { }
        [Custom("Caption", "���")]
        public string Type
        {
            get { return GetPropertyValue<string>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "����")]
        public string Proportion
        {
            get { return GetPropertyValue<string>("Proportion"); }
            set { SetPropertyValue("Proportion", value); }
        }

        [Custom("Caption", "��ѡ��")]
        public string Separation
        {
            get { return GetPropertyValue<string>("Separation"); }
            set { SetPropertyValue("Separation", value); }
        }

        [Custom("Caption", "Բ����")]
        public string Round
        {
            get { return GetPropertyValue<string>("Round"); }
            set { SetPropertyValue("Round", value); }
        }

        [Custom("Caption", "ֲ��(��Χ-����-��ɫ-�߶�-����)")]
        [Association("Accumulation-AccumulationContain", typeof(Accumulation))]
        public Accumulation Accumulation
        {
            get { return GetPropertyValue<Accumulation>("Accumulation"); }
            set { SetPropertyValue("Accumulation", value); }
        }
    }
}
