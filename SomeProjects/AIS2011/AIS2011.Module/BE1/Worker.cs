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
    [Custom("Caption", "项目人员")]
    public class Worker : BaseObject
    {

        public Worker(Session session) : base(session) { }


        private string name;
        [Custom("Caption", "姓名")]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }

        private Sex sex;
        [Custom("Caption", "性别")]
        public Sex Sex
        {
            get { return sex; }
            set { SetPropertyValue("Sex", ref sex, value); }
        }

        private string nation;
        [Custom("Caption", "民族")]
        public string Nation
        {
            get { return nation; }
            set { SetPropertyValue("Nation", ref nation, value); }
        }

        private DateTime birthday;
        [Custom("Caption", "出生日期")]
        public DateTime Birthday
        {
            get { return birthday; }
            set { SetPropertyValue("Birthday", ref birthday, value); }
        }

        private string origin;
        [Custom("Caption", "籍贯")]
        public string Origin
        {
            get { return origin; }
            set { SetPropertyValue("Origin", ref origin, value); }
        }

        private PDepartment department;
        [Custom("Caption", "单位（学校）")]
        public PDepartment Department
        {
            get { return department; }
            set { SetPropertyValue("PDepartment", ref department, value); }
        }

        private string profession;
        [Custom("Caption", "专业")]
        public string Profession
        {
            get { return profession; }
            set { SetPropertyValue("Profession", ref profession, value); }
        }

        private string grade;
        [Custom("Caption", "年级")]
        public string Grade
        {
            get { return grade; }
            set { SetPropertyValue("Grade", ref grade, value); }
        }

        private string eduRecord;
        [Custom("Caption", "学历")]
        public string EduRecord
        {
            get { return eduRecord; }
            set { SetPropertyValue("EduRecorde", ref eduRecord, value); }
        }

        private string mentor;
        [Custom("Caption", "导师")]
        public string Mentor
        {
            get { return mentor; }
            set { SetPropertyValue("Mentor", ref mentor, value); }
        }

        private string identity;
        [Custom("Caption", "身份证号")]
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


        [Custom("Caption", "QQ号")]
        public string QQ
        {
            get { return GetPropertyValue<string>("QQ"); }
            set { SetPropertyValue("QQ", value); }
        }

        [Size(3000)]
        [Custom("Caption", "参加项目理由")]
        public string Reason
        {
            get { return GetPropertyValue<string>("Reason"); }
            set { SetPropertyValue("Reason", value); }
        }

        [Custom("Caption", "计划开始时间")]
        public DateTime PlanOn
        {
            get { return GetPropertyValue<DateTime>("PlanOn"); }
            set { SetPropertyValue("PlanOn", value); }
        }
        [Custom("Caption", "计划结束时间")]
        public DateTime PlanOff
        {
            get { return GetPropertyValue<DateTime>("PlanOff"); }
            set { SetPropertyValue("PlanOff", value); }
        }

        [Association("Worker-Experience", typeof(Experience))]
        [Custom("Caption", "工作经历")]
        public XPCollection Experience
        {
            get { return GetCollection("Experience"); }
        }

        [Association("Project-Worker", typeof(Project))]
        [Custom("Caption", "参与项目")]
        public XPCollection Project
        {
            get { return GetCollection("Project"); }
        }

        [Association("Accumulation-Worker", typeof(Accumulation))]
        [Custom("Caption", "田野发掘-堆积登记")]
        public XPCollection Accumulation
        {
            get { return GetCollection("Accumulation"); }
        }

        [Association("ExcavationTrench-Worker", typeof(ExcavationTrench))]
        [Custom("Caption", "田野发掘-探方登记")]
        public XPCollection ExcavationTrench
        {
            get { return GetCollection("ExcavationTrench"); }
        }

        [Association("ExcavationFeatureGround-Worker", typeof(ExcavationFeatureGround))]
        [Custom("Caption", "田野发掘-地面及界面登记")]
        public XPCollection ExcavationFeatureGround
        {
            get { return GetCollection("ExcavationFeatureGround"); }
        }

        [Association("ExcavationFeaturePile-Worker", typeof(ExcavationFeaturePile))]
        [Custom("Caption", "田野发掘-堆状遗迹登记")]
        public XPCollection ExcavationFeaturePile
        {
            get { return GetCollection("ExcavationFeaturePile"); }
        }

        [Association("ExcavationFeatureHole-Worker", typeof(ExcavationFeatureHole))]
        [Custom("Caption", "田野发掘-坑状遗迹登记")]
        public XPCollection ExcavationFeatureHole
        {
            get { return GetCollection("ExcavationFeatureHole"); }
        }

        [Association("ExcavationFeaturePileHole-Worker", typeof(ExcavationFeaturePileHole))]
        [Custom("Caption", "田野发掘-带坑堆状遗迹登记")]
        public XPCollection ExcavationFeaturePileHole
        {
            get { return GetCollection("ExcavationFeaturePileHole"); }
        }


        [Association("ExcavationFeaturePillarHole-Worker", typeof(ExcavationFeaturePillarHole))]
        [Custom("Caption", "田野发掘-柱洞遗迹登记")]
        public XPCollection ExcavationFeaturePillarHole
        {
            get { return GetCollection("ExcavationFeaturePillarHole"); }
        }


        [Association("ExcavationFeatureTomb-Worker", typeof(ExcavationFeatureTomb))]
        [Custom("Caption", "田野发掘-墓葬遗迹登记")]
        public XPCollection ExcavationFeatureTomb
        {
            get { return GetCollection("ExcavationFeatureTomb"); }
        }

        [Association("Protection-Worker", typeof(Protection))]
        [Custom("Caption", "文物保护-文物处理档案")]
        public XPCollection Protection
        {
            get { return GetCollection("Protection"); }
        }

        [Association("SurveyFeatureSettlement-Worker", typeof(SurveyFeatureSettlement))]
        [Custom("Caption", "田野调查-居址遗迹登记")]
        public XPCollection SurveyFeatureSettlement
        {
            get { return GetCollection("SurveyFeatureSettlement"); }
        }

        [Association("SurveyFeatureAlignment-Worker", typeof(SurveyFeatureAlignment))]
        [Custom("Caption", "田野调查-列石遗迹登记")]
        public XPCollection SurveyFeatureAlignment
        {
            get { return GetCollection("SurveyFeatureAlignment"); }
        }

        [Association("SurveyFeatureDeerStone-Worker", typeof(SurveyFeatureDeerStone))]
        [Custom("Caption", "田野调查-鹿石遗迹登记")]
        public XPCollection SurveyFeatureDeerStone
        {
            get { return GetCollection("SurveyFeatureDeerStone"); }
        }

        [Association("SurveyFeatureTomb-Worker", typeof(SurveyFeatureTomb))]
        [Custom("Caption", "田野调查-墓葬遗迹登记")]
        public XPCollection SurveyFeatureTomb
        {
            get { return GetCollection("SurveyFeatureTomb"); }
        }

    }


    public enum Sex { 保密, 男, 女 }


    [DefaultClassOptions]
    [Custom("Caption", "工作学习经历")]
    [System.ComponentModel.DefaultProperty("Worker")]
    public class Experience : BaseObject
    {

        public Experience(Session session) : base(session) { }


        [Custom("Caption", "开始时间")]
        public DateTime StartOn
        {
            get { return GetPropertyValue<DateTime>("StartOn"); }
            set { SetPropertyValue("StartOn", value); }
        }

        [Custom("Caption", "结束时间")]
        public DateTime StartOff
        {
            get { return GetPropertyValue<DateTime>("StartOff"); }
            set { SetPropertyValue("StartOff", value); }
        }
        [Custom("Caption", "工作学习地点")]
        public string Location
        {
            get { return GetPropertyValue<string>("Location"); }
            set { SetPropertyValue("Location", value); }
        }

        [Custom("Caption", "工作学习内容")]
        public string JobContent
        {
            get { return GetPropertyValue<string>("JobContent"); }
            set { SetPropertyValue("JobContent", value); }
        }

        private PDepartment department;
        [Custom("Caption", "单位（学校）")]
        public PDepartment Department
        {
            get { return department; }
            set { SetPropertyValue("PDepartment", ref department, value); }
        }

        [Custom("Caption", "职务")]
        public string Duty
        {
            get { return GetPropertyValue<string>("Duty"); }
            set { SetPropertyValue("Duty", value); }
        }

        [Custom("Caption", "备注")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        private Worker worker;
        [Association("Worker-Experience", typeof(Worker))]
        [Custom("Caption", "人员姓名")]
        public Worker Worker
        {
            get { return worker; }
            set { SetPropertyValue("Worker", ref worker, value); }
        }

    }

}
