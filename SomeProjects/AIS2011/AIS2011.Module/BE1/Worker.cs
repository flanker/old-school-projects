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
    [System.ComponentModel.DefaultProperty("Name")]
    [Custom("Caption", "��Ŀ��Ա")]
    public class Worker : BaseObject
    {

        public Worker(Session session) : base(session) { }


        private string name;
        [Custom("Caption", "����")]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }

        private Sex sex;
        [Custom("Caption", "�Ա�")]
        public Sex Sex
        {
            get { return sex; }
            set { SetPropertyValue("Sex", ref sex, value); }
        }

        private string nation;
        [Custom("Caption", "����")]
        public string Nation
        {
            get { return nation; }
            set { SetPropertyValue("Nation", ref nation, value); }
        }

        private DateTime birthday;
        [Custom("Caption", "��������")]
        public DateTime Birthday
        {
            get { return birthday; }
            set { SetPropertyValue("Birthday", ref birthday, value); }
        }

        private string origin;
        [Custom("Caption", "����")]
        public string Origin
        {
            get { return origin; }
            set { SetPropertyValue("Origin", ref origin, value); }
        }

        private PDepartment department;
        [Custom("Caption", "��λ��ѧУ��")]
        public PDepartment Department
        {
            get { return department; }
            set { SetPropertyValue("PDepartment", ref department, value); }
        }

        private string profession;
        [Custom("Caption", "רҵ")]
        public string Profession
        {
            get { return profession; }
            set { SetPropertyValue("Profession", ref profession, value); }
        }

        private string grade;
        [Custom("Caption", "�꼶")]
        public string Grade
        {
            get { return grade; }
            set { SetPropertyValue("Grade", ref grade, value); }
        }

        private string eduRecord;
        [Custom("Caption", "ѧ��")]
        public string EduRecord
        {
            get { return eduRecord; }
            set { SetPropertyValue("EduRecorde", ref eduRecord, value); }
        }

        private string mentor;
        [Custom("Caption", "��ʦ")]
        public string Mentor
        {
            get { return mentor; }
            set { SetPropertyValue("Mentor", ref mentor, value); }
        }

        private string identity;
        [Custom("Caption", "���֤��")]
        public string Identity
        {
            get { return identity; }
            set { SetPropertyValue("Identity", ref identity, value); }
        }

        private string email;
        [RuleRegularExpression("", DefaultContexts.Save,
         @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|"
         + "(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$")]
        [Custom("Caption", "Email")]
        public string Email
        {
            get { return email; }
            set { SetPropertyValue("Email", ref email, value); }
        }

        private string mobile;
        [Custom("Caption", "Mobile")]
        public string Mobile
        {
            get { return mobile; }
            set { SetPropertyValue("Mobile", ref mobile, value); }
        }


        [Custom("Caption", "QQ��")]
        public string QQ
        {
            get { return GetPropertyValue<string>("QQ"); }
            set { SetPropertyValue("QQ", value); }
        }

        [Size(3000)]
        [Custom("Caption", "�μ���Ŀ����")]
        public string Reason
        {
            get { return GetPropertyValue<string>("Reason"); }
            set { SetPropertyValue("Reason", value); }
        }

        [Custom("Caption", "�ƻ���ʼʱ��")]
        public DateTime PlanOn
        {
            get { return GetPropertyValue<DateTime>("PlanOn"); }
            set { SetPropertyValue("PlanOn", value); }
        }
        [Custom("Caption", "�ƻ�����ʱ��")]
        public DateTime PlanOff
        {
            get { return GetPropertyValue<DateTime>("PlanOff"); }
            set { SetPropertyValue("PlanOff", value); }
        }

        [Association("Worker-Experience", typeof(Experience))]
        [Custom("Caption", "��������")]
        public XPCollection Experience
        {
            get { return GetCollection("Experience"); }
        }

        [Association("Project-Worker", typeof(Project))]
        [Custom("Caption", "������Ŀ")]
        public XPCollection Project
        {
            get { return GetCollection("Project"); }
        }

        [Association("Accumulation-Worker", typeof(Accumulation))]
        [Custom("Caption", "��Ұ����-�ѻ��Ǽ�")]
        public XPCollection Accumulation
        {
            get { return GetCollection("Accumulation"); }
        }

        [Association("ExcavationTrench-Worker", typeof(ExcavationTrench))]
        [Custom("Caption", "��Ұ����-̽���Ǽ�")]
        public XPCollection ExcavationTrench
        {
            get { return GetCollection("ExcavationTrench"); }
        }

        [Association("ExcavationFeatureGround-Worker", typeof(ExcavationFeatureGround))]
        [Custom("Caption", "��Ұ����-���漰����Ǽ�")]
        public XPCollection ExcavationFeatureGround
        {
            get { return GetCollection("ExcavationFeatureGround"); }
        }

        [Association("ExcavationFeaturePile-Worker", typeof(ExcavationFeaturePile))]
        [Custom("Caption", "��Ұ����-��״�ż��Ǽ�")]
        public XPCollection ExcavationFeaturePile
        {
            get { return GetCollection("ExcavationFeaturePile"); }
        }

        [Association("ExcavationFeatureHole-Worker", typeof(ExcavationFeatureHole))]
        [Custom("Caption", "��Ұ����-��״�ż��Ǽ�")]
        public XPCollection ExcavationFeatureHole
        {
            get { return GetCollection("ExcavationFeatureHole"); }
        }

        [Association("ExcavationFeaturePileHole-Worker", typeof(ExcavationFeaturePileHole))]
        [Custom("Caption", "��Ұ����-���Ӷ�״�ż��Ǽ�")]
        public XPCollection ExcavationFeaturePileHole
        {
            get { return GetCollection("ExcavationFeaturePileHole"); }
        }


        [Association("ExcavationFeaturePillarHole-Worker", typeof(ExcavationFeaturePillarHole))]
        [Custom("Caption", "��Ұ����-�����ż��Ǽ�")]
        public XPCollection ExcavationFeaturePillarHole
        {
            get { return GetCollection("ExcavationFeaturePillarHole"); }
        }


        [Association("ExcavationFeatureTomb-Worker", typeof(ExcavationFeatureTomb))]
        [Custom("Caption", "��Ұ����-Ĺ���ż��Ǽ�")]
        public XPCollection ExcavationFeatureTomb
        {
            get { return GetCollection("ExcavationFeatureTomb"); }
        }

        [Association("Protection-Worker", typeof(Protection))]
        [Custom("Caption", "���ﱣ��-���ﴦ����")]
        public XPCollection Protection
        {
            get { return GetCollection("Protection"); }
        }

        [Association("SurveyFeatureSettlement-Worker", typeof(SurveyFeatureSettlement))]
        [Custom("Caption", "��Ұ����-��ַ�ż��Ǽ�")]
        public XPCollection SurveyFeatureSettlement
        {
            get { return GetCollection("SurveyFeatureSettlement"); }
        }

        [Association("SurveyFeatureAlignment-Worker", typeof(SurveyFeatureAlignment))]
        [Custom("Caption", "��Ұ����-��ʯ�ż��Ǽ�")]
        public XPCollection SurveyFeatureAlignment
        {
            get { return GetCollection("SurveyFeatureAlignment"); }
        }

        [Association("SurveyFeatureDeerStone-Worker", typeof(SurveyFeatureDeerStone))]
        [Custom("Caption", "��Ұ����-¹ʯ�ż��Ǽ�")]
        public XPCollection SurveyFeatureDeerStone
        {
            get { return GetCollection("SurveyFeatureDeerStone"); }
        }

        [Association("SurveyFeatureTomb-Worker", typeof(SurveyFeatureTomb))]
        [Custom("Caption", "��Ұ����-Ĺ���ż��Ǽ�")]
        public XPCollection SurveyFeatureTomb
        {
            get { return GetCollection("SurveyFeatureTomb"); }
        }

    }


    public enum Sex { ����, ��, Ů }


    [DefaultClassOptions]
    [Custom("Caption", "����ѧϰ����")]
    [System.ComponentModel.DefaultProperty("Worker")]
    public class Experience : BaseObject
    {

        public Experience(Session session) : base(session) { }


        [Custom("Caption", "��ʼʱ��")]
        public DateTime StartOn
        {
            get { return GetPropertyValue<DateTime>("StartOn"); }
            set { SetPropertyValue("StartOn", value); }
        }

        [Custom("Caption", "����ʱ��")]
        public DateTime StartOff
        {
            get { return GetPropertyValue<DateTime>("StartOff"); }
            set { SetPropertyValue("StartOff", value); }
        }
        [Custom("Caption", "����ѧϰ�ص�")]
        public string Location
        {
            get { return GetPropertyValue<string>("Location"); }
            set { SetPropertyValue("Location", value); }
        }

        [Custom("Caption", "����ѧϰ����")]
        public string JobContent
        {
            get { return GetPropertyValue<string>("JobContent"); }
            set { SetPropertyValue("JobContent", value); }
        }

        private PDepartment department;
        [Custom("Caption", "��λ��ѧУ��")]
        public PDepartment Department
        {
            get { return department; }
            set { SetPropertyValue("PDepartment", ref department, value); }
        }

        [Custom("Caption", "ְ��")]
        public string Duty
        {
            get { return GetPropertyValue<string>("Duty"); }
            set { SetPropertyValue("Duty", value); }
        }

        [Custom("Caption", "��ע")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        private Worker worker;
        [Association("Worker-Experience", typeof(Worker))]
        [Custom("Caption", "��Ա����")]
        public Worker Worker
        {
            get { return worker; }
            set { SetPropertyValue("Worker", ref worker, value); }
        }

    }

}
