using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace kaogu.Module
{
    [DefaultClassOptions]
    [System.ComponentModel.DefaultProperty("Id")]
    [Custom("Caption", "���漰����Ǽ�")]
    public class ExcavationFeatureGround : BaseObject
    {
        public ExcavationFeatureGround(Session session) : base(session) { }

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

        [Custom("Caption", "���漰������")]
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


        [Association("ExcavationFeatureGround-Worker", typeof(Worker))]
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

        [Custom("Caption", "�����ż�")]
        public string BelongFeature
        {
            get { return GetPropertyValue<string>("BelongFeature"); }
            set { SetPropertyValue("BelongFeature", value); }
        }

        //������Ϣ
        //��Ȼ����
        [Custom("Caption", "����")]
        public string Terrain
        {
            get { return GetPropertyValue<string>("Terrain"); }
            set { SetPropertyValue("Terrain", value); }
        }

        [Custom("Caption", "��ò")]
        public string Landform
        {
            get { return GetPropertyValue<string>("Landform"); }
            set { SetPropertyValue("Landform", value); }
        }

        [Custom("Caption", "ˮ��")]
        public string Hydrology
        {
            get { return GetPropertyValue<string>("Hydrology"); }
            set { SetPropertyValue("Hydrology", value); }
        }

        [Custom("Caption", "ֲ��")]
        public string Vege
        {
            get { return GetPropertyValue<string>("Vege"); }
            set { SetPropertyValue("Vege", value); }
        }

        [Custom("Caption", "����״��")]
        public string KeepState
        {
            get { return GetPropertyValue<string>("KeepState"); }
            set { SetPropertyValue("KeepState", value); }
        }

        [Custom("Caption", "����ʽ")]
        public string CleanType
        {
            get { return GetPropertyValue<string>("CleanType"); }
            set { SetPropertyValue("CleanType", value); }
        }

        [Custom("Caption", "�ֲ�λ��")]
        public string SpreadLocation
        {
            get { return GetPropertyValue<string>("SpreadLocation"); }
            set { SetPropertyValue("SpreadLocation", value); }
        }

        //�������ż���λ��λ�ù�ϵ ��Զ�
        [Custom("Caption", "�������ż���λ��λ�ù�ϵ")]
        [Association("ExcavationFeatureGround-Layer", typeof(Layer))]
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


        //����
        [Custom("Caption", "�����ż�")]
        public string AdditionFeature
        {
            get { return GetPropertyValue<string>("AdditionFeature"); }
            set { SetPropertyValue("AdditionFeature", value); }
        }

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

        [Custom("Caption", "�¶ȷ���")]
        public string SlopeLocation
        {
            get { return GetPropertyValue<string>("SlopeLocation"); }
            set { SetPropertyValue("SlopeLocation", value); }
        }
        [Custom("Caption", "�¶ȽǶ�")]
        public int SlopeDegree
        {
            get { return GetPropertyValue<int>("SlopeDegree"); }
            set { SetPropertyValue("SlopeDegree", value); }
        }


        //�����ۼ�
        [Custom("Caption", "�����ۼ�")]
        [Association("ExcavationFeatureGround-GroundModifyVestige", typeof(GroundModifyVestige))]
        public XPCollection GroundModifyVestige
        {
            get { return GetCollection("GroundModifyVestige"); }
        }

        //ʹ�û�����

        [Custom("Caption", "����")]
        [Association("ExcavationFeatureGround-Sign", typeof(Sign))]
        public XPCollection Sign
        {
            get { return GetCollection("Sign"); }
        }

        [Custom("Caption", "��������໥��ϵ")]
        public string SignRelation
        {
            get { return GetPropertyValue<string>("SignRelation"); }
            set { SetPropertyValue("SignRelation", value); }
        }

        //����ɼ� ������

        [Custom("Caption", "������")]

        [Association("ExcavationFeatureGround-RemainMark", typeof(RemainMark))]
        public XPCollection RemainMark
        {
            get { return GetCollection("RemainMark"); }
        }


        //��������


        [Custom("Caption", "�����жϼ�����")]
        public string PropertyAndReason
        {
            get { return GetPropertyValue<string>("PropertyAndReason"); }
            set { SetPropertyValue("PropertyAndReason", value); }
        }

        [Custom("Caption", "�ż����ۼ������ܽ�")]
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
    }

}
