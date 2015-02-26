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
    [Custom("Caption", "���ŷ����ֳ����ﱣ������������")]
    [System.ComponentModel.DefaultProperty("Id")]
    [DefaultClassOptions]
    public class Protection : BaseObject
    {
        public Protection(Session session) : base(session) { }

        [Custom("Caption", "�������")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        //��¼�� ��¼ʱ��
        [Custom("Caption", "��¼��")]
        public Worker RecordBy
        {
            get { return GetPropertyValue<Worker>("RecordBy"); }
            set { SetPropertyValue("RecordBy", value); }
        }

        [Custom("Caption", "����ʱ��")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }


        //���������Ϣ�� ����-���-����-�ߴ�-����-����-����λ��-����ʱ��
        [Custom("Caption", "��������")]
        public string RelicName
        {
            get { return GetPropertyValue<string>("RelicName"); }
            set { SetPropertyValue("RelicName", value); }
        }

        [Custom("Caption", "������")]
        public string RelicId
        {
            get { return GetPropertyValue<string>("RelicId"); }
            set { SetPropertyValue("RelicId", value); }
        }

        [Custom("Caption", "����")]
        public string Material
        {
            get { return GetPropertyValue<string>("Material"); }
            set { SetPropertyValue("Material", value); }
        }
        [Size(3000)]
        [Custom("Caption", "�ߴ�")]
        public string Size
        {
            get { return GetPropertyValue<string>("Size"); }
            set { SetPropertyValue("Size", value); }
        }

        [Custom("Caption", "����")]
        public string Quality
        {
            get { return GetPropertyValue<string>("Quality"); }
            set { SetPropertyValue("Quality", value); }
        }

        [Custom("Caption", "����")]
        public string Quantity
        {
            get { return GetPropertyValue<string>("Quantity"); }
            set { SetPropertyValue("Quantity", value); }
        }

        [Size(3000)]
        [Custom("Caption", "����λ��")]
        public string Location
        {
            get { return GetPropertyValue<string>("Location"); }
            set { SetPropertyValue("Location", value); }
        }

        [Custom("Caption", "����ʱ��")]
        public DateTime FindOn
        {
            get { return GetPropertyValue<DateTime>("FindOn"); }
            set { SetPropertyValue("FindOn", value); }
        }

        //��ػ�����Ϣ ��ػ����� �¶�-��ˮ��-phֵ-������-����
        [Custom("Caption", "�¶�")]
        public string Temperature
        {
            get { return GetPropertyValue<string>("Temperature"); }
            set { SetPropertyValue("Temperature", value); }
        }

        [Custom("Caption", "��ˮ��")]
        public string Watery
        {
            get { return GetPropertyValue<string>("Watery"); }
            set { SetPropertyValue("Watery", value); }
        }

        [Custom("Caption", "PHֵ")]
        public string PH
        {
            get { return GetPropertyValue<string>("PH"); }
            set { SetPropertyValue("PH", value); }
        }

        [Custom("Caption", "������")]
        public string Depth
        {
            get { return GetPropertyValue<string>("Depth"); }
            set { SetPropertyValue("Depth", value); }
        }

        [Size(3000)]
        [Custom("Caption", "��ػ���-����")]
        public string AmbushOther
        {
            get { return GetPropertyValue<string>("Temperature"); }
            set { SetPropertyValue("Temperature", value); }
        }

        //��ػ�����Ϣ ������������� �ֳ��¶��ձ仯��¼-�ֳ�ʪ���ձ仯��¼-�ն�ˮƽ-���ŷ����ֳ�����������ʩ
        [Size(10000)]
        [Custom("Caption", "�ֳ��¶��ձ仯��¼")]
        public string TemperatureChanged
        {
            get { return GetPropertyValue<string>("Temperature"); }
            set { SetPropertyValue("Temperature", value); }
        }
        [Size(10000)]
        [Custom("Caption", "�ֳ�ʪ���ձ仯��¼")]
        public string HumidityChanged
        {
            get { return GetPropertyValue<string>("HumidityChanged"); }
            set { SetPropertyValue("HumidityChanged", value); }
        }

        [Custom("Caption", "�ն�ˮƽ")]
        public string Illumination
        {
            get { return GetPropertyValue<string>("Illumination"); }
            set { SetPropertyValue("Illumination", value); }
        }
        [Size(10000)]
        [Custom("Caption", "���ŷ����ֳ�����������ʩ")]
        public string OtherProtection
        {
            get { return GetPropertyValue<string>("OtherProtection"); }
            set { SetPropertyValue("OtherProtection", value); }
        }


        //��Ʒ�ɼ���Ϣ 
        [Custom("Caption", "��Ʒ�ɼ���Ϣ")]
        [Association("Protection-ProtectionSample", typeof(ProtectionSample))]
        public XPCollection ProtectionSample
        {
            get { return GetCollection("ProtectionSample"); }
        }

        //����������Ա ����������

        [Association("Protection-Worker", typeof(Worker))]
        [Custom("Caption", "����������Ա")]
        public XPCollection Worker
        {
            get { return GetCollection("Worker"); }
        }

        [Custom("Caption", "����������")]
        public Worker Leader
        {
            get { return GetPropertyValue<Worker>("Leader"); }
            set { SetPropertyValue("Leader", value); }
        }

        //���ﱣ����״
        [Size(10000)]
        [Custom("Caption", "���ﱣ����״")]
        public string CurrentSituation
        {
            get { return GetPropertyValue<string>("CurrentSituation"); }
            set { SetPropertyValue("CurrentSituation", value); }
        }

        //�ֳ�������������
        [Size(20000)]
        [Custom("Caption", "�ֳ�������������")]
        public string LiveMake
        {
            get { return GetPropertyValue<string>("LiveMake"); }
            set { SetPropertyValue("LiveMake", value); }
        }
        
        
        //������ʱ�洢΢�����仯��¼
        [Size(10000)]
        [Custom("Caption", "������ʱ�洢΢�����仯��¼")]
        public string MicroEnvironment
        {
            get { return GetPropertyValue<string>("MicroEnvironment"); }
            set { SetPropertyValue("MicroEnvironment", value); }
        }

        //�����װ������ķ���������
        [Size(10000)]
        [Custom("Caption", "�����װ������ķ���������")]
        public string Transfer
        {
            get { return GetPropertyValue<string>("Transfer"); }
            set { SetPropertyValue("Transfer", value); }
        }
      
        
        // ����������ʹ�õĻ�ѧ���ϼ��Լ�
        [Size(10000)]
        [Custom("Caption", "����������ʹ�õĻ�ѧ���ϼ��Լ�")]
        public string ChemistryMaterial
        {
            get { return GetPropertyValue<string>("Material"); }
            set { SetPropertyValue("Material", value); }
        }

        //����������ʹ�õ���������
        [Size(10000)]
        [Custom("Caption", "����������ʹ�õ���������")]
        public string OtherChemistryMaterial
        {
            get { return GetPropertyValue<string>("OtherChemistryMaterial"); }
            set { SetPropertyValue("OtherChemistryMaterial", value); }
        }


        //������ܵ�λ
        [Custom("Caption", "������ܵ�λ")]
        public PDepartment ReceiveBy
        {
            get { return GetPropertyValue<PDepartment>("ReceiveBy"); }
            set { SetPropertyValue("ReceiveBy", value); }
        }

        //��ע
        [Size(10000)]
        [Custom("Caption", "��ע")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        //��¼ 
        //��Ƭ һ�Զ�
        [Custom("Caption", "��Ƭ���")]
        [Association("Protection-ProtectionPhoto", typeof(ProtectionPhoto))]
        public XPCollection ProtectionPhoto
        {
            get { return GetCollection("ProtectionPhoto"); }
        }


        // ��Ʒ��������� һ�Զ�
        [Custom("Caption", "��Ʒ���������")]
        [Association("Protection-ProtectionSampleResult", typeof(ProtectionSampleResult))]
        public XPCollection ProtectionSampleResult
        {
            get { return GetCollection("ProtectionSampleResult"); }
        }

    }

}
