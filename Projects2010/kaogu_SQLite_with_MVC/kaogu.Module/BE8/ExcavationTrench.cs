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
    [Custom("Caption", "̽���Ǽ�")]
    public class ExcavationTrench : BaseObject
    {
        public ExcavationTrench(Session session) : base(session) { }

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

        [Custom("Caption", "̽�����")]
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


        [Association("ExcavationTrench-Worker", typeof(Worker))]
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
        [Association("ExcavationTrench-Layer", typeof(Layer))]
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

        //�ѻ�
        [Custom("Caption", "�ѻ�")]

        [Association("ExcavationTrench-Accumulation", typeof(Accumulation))]
        public XPCollection Accumulation
        {
            get { return GetCollection("Accumulation"); }
        }

        //̽�����ż� ��λ��ϵ
        [Custom("Caption", "���ż���λ��ϵ")]

        [Association("ExcavationTrench-TrenchFeatureLayerRelation", typeof(TrenchFeatureLayerRelation))]
        public XPCollection TrenchFeatureLayerRelation
        {
            get { return GetCollection("TrenchFeatureLayerRelation"); }
        }


        //������
        [Custom("Caption", "������")]

        [Association("ExcavationTrench-RemainMark", typeof(RemainMark))]
        public XPCollection RemainMark
        {
            get { return GetCollection("RemainMark"); }
        }


        [Custom("Caption", "̽�����ۼ������ܽ�")]
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

        //̽�������¼

        [Size(3000)]
        [Custom("Caption", "��Ȼ����")]
        public string Environment
        {
            get { return GetPropertyValue<string>("Environment"); }
            set { SetPropertyValue("Environment", value); }
        }

        [Size(3000)]
        [Custom("Caption", "��ʷ����ſ�")]
        public string Geohistory
        {
            get { return GetPropertyValue<string>("Geohistory"); }
            set { SetPropertyValue("Geohistory", value); }
        }


        [Size(3000)]
        [Custom("Caption", "�������")]
        public string ExcavationProcess
        {
            get { return GetPropertyValue<string>("ExcavationProcess"); }
            set { SetPropertyValue("ExcavationProcess", value); }
        }

        [Size(3000)]
        [Custom("Caption", "��λ��ϵ")]
        public string LayerRelation
        {
            get { return GetPropertyValue<string>("LayerRelation"); }
            set { SetPropertyValue("LayerRelation", value); }
        }

        [Size(3000)]
        [Custom("Caption", "�ѻ�����")]
        public string AccumulationDescription
        {
            get { return GetPropertyValue<string>("AccumulationDescription"); }
            set { SetPropertyValue("AccumulationDescription", value); }
        }

        [Size(3000)]
        [Custom("Caption", "�ż�����")]
        public string FeatureDescription
        {
            get { return GetPropertyValue<string>("FeatureDescription"); }
            set { SetPropertyValue("FeatureDescription", value); }
        }

        [Size(3000)]
        [Custom("Caption", "������")]
        public string RemainDescription
        {
            get { return GetPropertyValue<string>("RemainDescription"); }
            set { SetPropertyValue("RemainDescription", value); }
        }

        [Size(3000)]
        [Custom("Caption", "����")]
        public string SignDescription
        {
            get { return GetPropertyValue<string>("SignDescription"); }
            set { SetPropertyValue("SignDescription", value); }
        }

        [Size(3000)]
        [Custom("Caption", "��ֵ���պ����ƻ�")]
        public string ValueAndPlan
        {
            get { return GetPropertyValue<string>("ValueAndPlan"); }
            set { SetPropertyValue("ValueAndPlan", value); }
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
