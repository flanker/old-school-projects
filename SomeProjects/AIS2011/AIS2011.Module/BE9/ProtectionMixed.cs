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
    //��Ʒ�ɼ���Ϣ 
    //������Ʒ ��Ʒ���-��Ʒ��Ƭ��ţ�һ�Զࣩ-������λ-��������-������
    //������Ʒ ��Ʒ���-��Ʒ��Ƭ���-������λ-��������-������
    [Custom("Caption", "���ﱣ��-��Ʒ�ɼ���Ϣ")]
    [DefaultClassOptions]
    public class ProtectionSample : BaseObject
    {
        public ProtectionSample(Session session) : base(session) { }

        [Custom("Caption", "��Ӧ��������")]
        [Association("Protection-ProtectionSample", typeof(Protection))]
        public Protection Protection
        {
            get { return GetPropertyValue<Protection>("Protection"); }
            set { SetPropertyValue("Protection", value); }
        }

        [Custom("Caption", "��Ʒ���")]
        public ProtectionSampleType ProtectionSampleType
        {
            get { return GetPropertyValue<ProtectionSampleType>("ProtectionSampleType"); }
            set { SetPropertyValue("ProtectionSampleType", value); }
        }

        [Custom("Caption", "��Ʒ���")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "��Ʒ��Ƭ���")]
        [Association("ProtectionSample-ProtectionPhoto", typeof(ProtectionPhoto))]
        public XPCollection ProtectionPhoto
        {
            get { return GetCollection("ProtectionPhoto"); }
        }

        [Size(3000)]
        [Custom("Caption", "������λ")]
        public string Part
        {
            get { return GetPropertyValue<string>("Part"); }
            set { SetPropertyValue("Part", value); }
        }

        [Size(3000)]
        [Custom("Caption", "��������")]
        public string Method
        {
            get { return GetPropertyValue<string>("Method"); }
            set { SetPropertyValue("Method", value); }
        }

        [Custom("Caption", "������")]
        public string Quantity
        {
            get { return GetPropertyValue<string>("Quantity"); }
            set { SetPropertyValue("Quantity", value); }
        }
    }

    public enum ProtectionSampleType { δ֪, ����, ���� }
    //��Ƭ һ�Զ� 
    //���ﱣ����״��Ƭ ��Ƭ���-����ʱ��-������

    //������Ʒ�ɼ���Ƭ ����ǰ����/�����ֲ� ����������/�����ֲ�

    //�����ֳ�����������Ƭ ����׶� ������ǰ ����� - ����������
    [Custom("Caption", "���ﱣ��-��Ƭ")]
    [DefaultClassOptions]
    public class ProtectionPhoto : BaseObject
    {

        public ProtectionPhoto(Session session) : base(session) { }

        [Custom("Caption", "��Ӧ��������")]
        [Association("Protection-ProtectionPhoto", typeof(Protection))]
        public Protection Protection
        {
            get { return GetPropertyValue<Protection>("Protection"); }
            set { SetPropertyValue("Protection", value); }
        }

        [Custom("Caption", "��Ӧ�����������")]
        [Association("ProtectionSample-ProtectionPhoto", typeof(ProtectionSample))]
        public ProtectionSample ProtectionSample
        {
            get { return GetPropertyValue<ProtectionSample>("ProtectionSample"); }
            set { SetPropertyValue("ProtectionSample", value); }
        }

        [Custom("Caption", "��Ӧ�����׶�")]
        public ProtectionStep ProtectionStep
        {
            get { return GetPropertyValue<ProtectionStep>("ProtectionStep"); }
            set { SetPropertyValue("ProtectionStep", value); }
        }

        

        [Custom("Caption", "����������")]
        public string ProtectionMethod
        {
            get { return GetPropertyValue<string>("ProtectionMethod"); }
            set { SetPropertyValue("ProtectionMethod", value); }
        }

        [Custom("caption", "��Ƭ���")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "������")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "����ʱ��")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

      //��Ƭ
        //[VisibleInListView(true)]
        //[DevExpress.Xpo.Size(SizeAttribute.Unlimited), ValueConverter(typeof(ImageValueConverter))]
        //[ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 40)]
        //[Custom("Caption", "��Ƭ")]
        //public Image Photo
        //{
        //    get { return GetPropertyValue<Image>("Photo"); }
        //    set { SetPropertyValue<Image>("Photo", value); }
        //}

    }

    public enum ProtectionStep { δ֪, ������״, ����ǰ����򻷾��ֲ�, ����������򻷾��ֲ�, �ֳ���������ǰ, �ֳ���������� }

    //һ�Զ� ��Ʒ��������� ���Ŀ��-��ⷽ��-��Ʒ����-��Ʒ����-�����-��ⵥλ-�����
    [Custom("Caption", "���ﱣ��-��Ʒ���������")]
    [DefaultClassOptions]
    public class ProtectionSampleResult : BaseObject
    {
        public ProtectionSampleResult(Session session) : base(session) { }


        [Custom("Caption", "��Ӧ��������")]
        [Association("Protection-ProtectionSampleResult", typeof(Protection))]
        public Protection Protection
        {
            get { return GetPropertyValue<Protection>("Protection"); }
            set { SetPropertyValue("Protection", value); }
        }

        [Size(3000)]
        [Custom("Caption", "���Ŀ��")]
        public string Goal
        {
            get { return GetPropertyValue<string>("Goal"); }
            set { SetPropertyValue("Goal", value); }
        }

        [Size(3000)]
        [Custom("Caption", "��ⷽ��")]
        public string Method
        {
            get { return GetPropertyValue<string>("Method"); }
            set { SetPropertyValue("Method", value); }
        }

        [Size(3000)]
        [Custom("Caption", "��Ʒ����")]
        public string SampleType
        {
            get { return GetPropertyValue<string>("SampleType"); }
            set { SetPropertyValue("SampleType", value); }
        }

        [Size(3000)]
        [Custom("Caption", "��Ʒ����")]
        public string SampleDosage
        {
            get { return GetPropertyValue<string>("SampleDosage"); }
            set { SetPropertyValue("SampleDosage", value); }
        }

        [Size(20000)]
        [Custom("Caption", "�����")]
        public string Result
        {
            get { return GetPropertyValue<string>("Result"); }
            set { SetPropertyValue("Result", value); }
        }

        [Custom("Caption", "��ⵥλ")]
        public PDepartment TestAt
        {
            get { return GetPropertyValue<PDepartment>("TestAt"); }
            set { SetPropertyValue("TestAt", value); }
        }

        [Custom("Caption", "�����")]
        public Worker TestBy
        {
            get { return GetPropertyValue<Worker>("TestBy"); }
            set { SetPropertyValue("TestBy", value); }
        }
    }

}
