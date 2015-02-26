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
    [Custom("Caption", "�����ż��Ǽ�")]
    public class ExcavationFeaturePillarHole : BaseObject
    {
        public ExcavationFeaturePillarHole(Session session) : base(session) { }

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

        [Custom("Caption", "������ַ")]
        public string BelongSite
        {
            get { return GetPropertyValue<string>("BelongSite"); }
            set { SetPropertyValue("BelongSite", value); }
        }

        [Custom("Caption", "�������")]
        public String Id
        {
            get { return GetPropertyValue<String>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "�Ƿ�����")]
        public IsMainOrPart MainOrPart
        {
            get { return GetPropertyValue<IsMainOrPart>("MainOrPart"); }
            set { SetPropertyValue("MainOrPart", value); }
        }

        [Association("ExcavationFeaturePillarHole-Worker", typeof(Worker))]
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
        [Size(3000)]
        [Custom("Caption", "����λ������һ")]
        public string GPSDescription
        {
            get { return GetPropertyValue<string>("GPSDescription"); }
            set { SetPropertyValue("GPSDescription", value); }
        }

        [Custom("Caption", "X")] //ȫվ��
        public string TotalStationX
        {
            get { return GetPropertyValue<string>("TotalStationX"); }
            set { SetPropertyValue("TotalStationX", value); }
        }

        [Custom("Caption", "Y")] //ȫվ��
        public string TotalStationY
        {
            get { return GetPropertyValue<string>("TotalStationY"); }
            set { SetPropertyValue("TotalStationY", value); }
        }

        [Custom("Caption", "Z")] //ȫվ��
        public string TotalStationZ
        {
            get { return GetPropertyValue<string>("TotalStationZ"); }
            set { SetPropertyValue("TotalStationZ", value); }
        }
        [Size(3000)]
        [Custom("Caption", "����λ��������")]
        public string TotalStationDescription
        {
            get { return GetPropertyValue<string>("TotalStationDescription"); }
            set { SetPropertyValue("TotalStationDescription", value); }
        }
        [Size(3000)]
        [Custom("Caption", "�����ż�")]
        public string BelongFeature
        {
            get { return GetPropertyValue<string>("BelongFeature"); }
            set { SetPropertyValue("BelongFeature", value); }
        }

        //������Ϣ
        //��Ȼ����
        [Size(3000)]
        [Custom("Caption", "����")]
        public string Terrain
        {
            get { return GetPropertyValue<string>("Terrain"); }
            set { SetPropertyValue("Terrain", value); }
        }
        [Size(3000)]
        [Custom("Caption", "��ò")]
        public string Landform
        {
            get { return GetPropertyValue<string>("Landform"); }
            set { SetPropertyValue("Landform", value); }
        }
        [Size(3000)]
        [Custom("Caption", "ˮ��")]
        public string Hydrology
        {
            get { return GetPropertyValue<string>("Hydrology"); }
            set { SetPropertyValue("Hydrology", value); }
        }
        [Size(3000)]
        [Custom("Caption", "ֲ��")]
        public string Vege
        {
            get { return GetPropertyValue<string>("Vege"); }
            set { SetPropertyValue("Vege", value); }
        }
        [Size(3000)]
        [Custom("Caption", "����״��")]
        public string KeepState
        {
            get { return GetPropertyValue<string>("KeepState"); }
            set { SetPropertyValue("KeepState", value); }
        }
        [Size(3000)]
        [Custom("Caption", "����ʽ")]
        public string CleanType
        {
            get { return GetPropertyValue<string>("CleanType"); }
            set { SetPropertyValue("CleanType", value); }
        }
        [Size(3000)]
        [Custom("Caption", "�ֲ�λ��")]
        public string SpreadLocation
        {
            get { return GetPropertyValue<string>("SpreadLocation"); }
            set { SetPropertyValue("SpreadLocation", value); }
        }

        //�������ż���λ��λ�ù�ϵ ��Զ�
        [Custom("Caption", "�������ż���λ��λ�ù�ϵ")]
        [Association("ExcavationFeaturePillarHole-Layer", typeof(Layer))]
        public XPCollection Layer
        {
            get { return GetCollection("Layer"); }
        }
        [Size(3000)]
        [Custom("Caption", "��������")]
        public string LayerDescription
        {
            get { return GetPropertyValue<string>("LayerDescription"); }
            set { SetPropertyValue("LayerDescription", value); }
        }


        //����
        [Size(3000)]
        [Custom("Caption", "�����ż�")]
        public string AdditionFeature
        {
            get { return GetPropertyValue<string>("AdditionFeature"); }
            set { SetPropertyValue("AdditionFeature", value); }
        }
        [Size(3000)]
        [Custom("Caption", "�ֲ���Χ")]
        public string SpreadScope
        {
            get { return GetPropertyValue<string>("SpreadScope"); }
            set { SetPropertyValue("SpreadScope", value); }
        }

        //��״shape

        [Custom("Caption", "������״")]
        public string FaceShape
        {
            get { return GetPropertyValue<string>("FaceShape"); }
            set { SetPropertyValue("FaceShape", value); }
        }

        [Custom("Caption", "ƽ����״")]
        public string PlaneShape
        {
            get { return GetPropertyValue<string>("PlaneShape"); }
            set { SetPropertyValue("PlaneShape", value); }
        }

        [Custom("Caption", "������״")]
        public string ProfileShape
        {
            get { return GetPropertyValue<string>("ProfileShape"); }
            set { SetPropertyValue("ProfileShape", value); }
        }

        //����

        [Custom("Caption", "����һ")]
        public string Direction1
        {
            get { return GetPropertyValue<string>("Direction1"); }
            set { SetPropertyValue("Direction1", value); }
        }

        [Custom("Caption", "�Ƿ񳤻�ֱ��")]
        public IsLengthOrDiameter IsLengthOrDiameter
        {
            get { return GetPropertyValue<IsLengthOrDiameter>("IsLengthOrDiameter"); }
            set { SetPropertyValue("IsLengthOrDiameter", value); }
        }

        [Custom("Caption", "��/ֱ����m��")]
        public float DirectionLength
        {
            get { return GetPropertyValue<float>("DirectionLength"); }
            set { SetPropertyValue("DirectionLength", value); }
        }

        [Custom("Caption", "�����")]
        public string Direction2
        {
            get { return GetPropertyValue<string>("Direction2"); }
            set { SetPropertyValue("Direction2", value); }
        }

        [Custom("Caption", "��m��")]
        public float DirectionWidth
        {
            get { return GetPropertyValue<float>("DirectionWidth"); }
            set { SetPropertyValue("DirectionWidth", value); }
        }

        [Custom("Caption", "��ȣ�m��")]
        public float Depth
        {
            get { return GetPropertyValue<float>("Depth"); }
            set { SetPropertyValue("Depth", value); }
        }

        //�����ۼ�
        [Custom("Caption", "�����ۼ�")]
        [Association("ExcavationFeaturePillarHole-GroundModifyVestige", typeof(GroundModifyVestige))]
        public XPCollection GroundModifyVestige
        {
            get { return GetCollection("GroundModifyVestige"); }
        }

        //ľ��
        [Custom("Caption", "����")]
        public string PillarType
        {
            get { return GetPropertyValue<string>("PillarType"); }
            set { SetPropertyValue("PillarType", value); }
        }

        [Custom("Caption", "��ɫ")]
        public string PillarColor
        {
            get { return GetPropertyValue<string>("PillarColor"); }
            set { SetPropertyValue("PillarColor", value); }
        }
        [Size(3000)]
        [Custom("Caption", "����״��")]
        public string PillarProtection
        {
            get { return GetPropertyValue<string>("PillarProtection"); }
            set { SetPropertyValue("PillarProtection", value); }
        }

        //ľ�� ����

        [Custom("Caption", "����m��")]
        public float PillarLength
        {
            get { return GetPropertyValue<float>("PillarLength"); }
            set { SetPropertyValue("PillarLength", value); }
        }

        [Custom("Caption", "ֱ����m��")]
        public float PillarDiameter
        {
            get { return GetPropertyValue<float>("PillarDiameter"); }
            set { SetPropertyValue("PillarDiameter", value); }
        }

        [Custom("Caption", "�ߣ�m��")]
        public float PillarHeight
        {
            get { return GetPropertyValue<float>("PillarHeight"); }
            set { SetPropertyValue("PillarHeight", value); }
        }

        [Custom("Caption", "�m��")]
        public float PillarDepth
        {
            get { return GetPropertyValue<float>("PillarDepth"); }
            set { SetPropertyValue("PillarDepth", value); }
        }

        [Custom("Caption", "��б��")]
        public int PillarSlopeDegree
        {
            get { return GetPropertyValue<int>("PillarSlopeDegree"); }
            set { SetPropertyValue("PillarSlopeDegree", value); }
        }

        //�ѻ�
        [Custom("Caption", "�ѻ�")]

        [Association("ExcavationFeaturePillarHole-Accumulation", typeof(Accumulation))]
        public XPCollection Accumulation
        {
            get { return GetCollection("Accumulation"); }
        }
        //������

        [Custom("Caption", "������")]

        [Association("ExcavationFeaturePillarHole-RemainMark", typeof(RemainMark))]
        public XPCollection RemainMark
        {
            get { return GetCollection("RemainMark"); }
        }
        [Size(10000)]
        [Custom("Caption", "�����жϼ�����")]
        public string PropertyAndReason
        {
            get { return GetPropertyValue<string>("PropertyAndReason"); }
            set { SetPropertyValue("PropertyAndReason", value); }
        }
        [Size(10000)]
        [Custom("Caption", "������������Ϲ�ϵ������")]
        public string PillarHoleComponentAndReason
        {
            get { return GetPropertyValue<string>("PillarHoleComponentAndReason"); }
            set { SetPropertyValue("PillarHoleComponentAndReason", value); }
        }
        [Size(10000)]
        [Custom("Caption", "�����ټ�����Ϲ�ϵ������")]
        public string SignComponentAndReason
        {
            get { return GetPropertyValue<string>("SignComponentAndReason"); }
            set { SetPropertyValue("SignComponentAndReason", value); }
        }
        [Size(10000)]
        [Custom("Caption", "�ż����ۼ������ܽ�")]
        public string Summary
        {
            get { return GetPropertyValue<string>("Summary"); }
            set { SetPropertyValue("Summary", value); }
        }
        [Size(10000)]
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
    }

}
