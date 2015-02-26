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
    [Custom("Caption", "�����ǩ/������Ǽ�")]
    public class RemainMark : BaseObject
    {
        public RemainMark(Session session) : base(session) { }

        [Custom("Caption", "���")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "���")]
        public RemainType Type
        {
            get { return GetPropertyValue<RemainType>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "����")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "����")]
        public int Number
        {
            get { return GetPropertyValue<int>("Number"); }
            set { SetPropertyValue("Number", value); }
        }

        [Custom("Caption", "λ��")]
        public string Location
        {
            get { return GetPropertyValue<string>("Location"); }
            set { SetPropertyValue("Location", value); }
        }

       
        public float X
        {
            get { return GetPropertyValue<float>("X"); }
            set { SetPropertyValue("X", value); }
        }

       
        public float Y
        {
            get { return GetPropertyValue<float>("Y"); }
            set { SetPropertyValue("Y", value); }
        }

        public float Z
        {
            get { return GetPropertyValue<float>("Z"); }
            set { SetPropertyValue("Z", value); }
        }


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

        [Custom("Caption", "�ĺ�")]
        public Boolean IsIdChange
        {
            get { return GetPropertyValue<Boolean>("IsIdChange"); }
            set { SetPropertyValue("IsIdChange", value); }
        }

        [Custom("Caption", "��ע")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }


        [Action(ToolTip = "�����ǩ�ĺ�-����-��Ÿı䣨�ĺ�������")]       
        public void IdChange()
        {
            if (IsIdChange != false) {
                MarkChange mc = new MarkChange(Session);
                mc.MarkType = WorkType.����;
                mc.CreateBy = RecordBy; 
                mc.NewId = Id;
                mc.CreateOn = CreateOn;
                mc.Type = Type.ToString();
                
            }    
        }
        
        //��������Դ �ѻ�-̽��-�ż��Ǽ�

        [Custom("Caption", "�����ѻ�")]
        [Association("Accumulation-RemainMark", typeof(Accumulation))]
        public Accumulation Accumulation
        {
            get { return GetPropertyValue<Accumulation>("Accumulation"); }
            set { SetPropertyValue("Accumulation", value); }
        }

        [Custom("Caption", "����̽��")]
        [Association("ExcavationTrench-RemainMark", typeof(ExcavationTrench))]
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
                if (GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround") != null)
                { return GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround").ToString(); }
                else if (GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole") != null)
                { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile1") != null)
                { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile1").ToString(); }
                else if (GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile2") != null)
                { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile2").ToString(); }
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

        [Custom("Caption", "��Ӧ���漰����")]
        [Association("ExcavationFeatureGround-RemainMark", typeof(ExcavationFeatureGround))]
        public ExcavationFeatureGround ExcavationFeatureGround
        {
            get { return GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround"); }
            set { SetPropertyValue("ExcavationFeatureGround", value); }
        }

        [Custom("Caption", "��Ӧ��״�ż�")]
        [Association("ExcavationFeatureHole-RemainMark", typeof(ExcavationFeatureHole))]
        public ExcavationFeatureHole ExcavationFeatureHole
        {
            get { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole"); }
            set { SetPropertyValue("ExcavationFeatureHole", value); }
        }

        [Custom("Caption", "��Ӧ��״�ż�-�ر���")]
        [Association("ExcavationFeaturePile-RemainMark1", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile1
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile1"); }
            set { SetPropertyValue("ExcavationFeaturePile1", value); }
        }

        [Custom("Caption", "��Ӧ��״�ż�-���½���")]
        [Association("ExcavationFeaturePile-RemainMark2", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile2
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile2"); }
            set { SetPropertyValue("ExcavationFeaturePile2", value); }
        }

        [Custom("Caption", "��Ӧ���Ӷ�״�ż�-�ر���")]
        [Association("ExcavationFeaturePileHole-RemainMark1", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole1
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole1"); }
            set { SetPropertyValue("ExcavationFeaturePileHole1", value); }
        }

        [Custom("Caption", "��Ӧ���Ӷ�״�ż�-���½���")]
        [Association("ExcavationFeaturePileHole-RemainMark2", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole2
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole2"); }
            set { SetPropertyValue("ExcavationFeaturePileHole2", value); }
        }
        [Custom("Caption", "�ż��Ǽ�-�����ż�")]
        [Association("ExcavationFeaturePillarHole-RemainMark", typeof(ExcavationFeaturePillarHole))]
        public ExcavationFeaturePillarHole ExcavationFeaturePillarHole
        {
            get { return GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole"); }
            set { SetPropertyValue("ExcavationFeaturePillarHole", value); }
        }

        [Custom("Caption", "��ӦĹ���ż�-�ر���")]
        [Association("ExcavationFeatureTomb-RemainMark1", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb1
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb1"); }
            set { SetPropertyValue("ExcavationFeatureTomb1", value); }
        }

        [Custom("Caption", "��ӦĹ���ż�-Ĺ��")]
        [Association("ExcavationFeatureTomb-RemainMark2", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb2
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2"); }
            set { SetPropertyValue("ExcavationFeatureTomb2", value); }
        }

        [Custom("Caption", "��ӦĹ���ż�-Ĺ��")]
        [Association("ExcavationFeatureTomb-RemainMark3", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb3
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb3"); }
            set { SetPropertyValue("ExcavationFeatureTomb3", value); }
        }
    }
    
    public enum RemainType 
    { δ֪, ����_С��, ��Ƭ, ����, ����, ̼��, ������, ������, ��ʯ��, �մ���, ��֯Ʒ��, ������, ����}

}
