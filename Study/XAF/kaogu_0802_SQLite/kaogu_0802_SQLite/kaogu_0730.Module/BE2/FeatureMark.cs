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

    [Custom("Caption", "�ż���ǩ")]
    public class FeatureMark : BaseObject
    {
        public FeatureMark(Session session) : base(session) { }

        [Custom("Caption", "���")]
        public FeatureCode Tpye
        {
            get { return GetPropertyValue<FeatureCode>("Tpye"); }
            set { SetPropertyValue("Tpye", value); }
        }

        [Custom("Caption", "�ż����")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "�ź�ʱ�䣨��ȷ���֣�")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "������")]
        public Worker AskBy
        {
            get { return GetPropertyValue<Worker>("AskBy"); }
            set { SetPropertyValue("AskBy", value); }
        }

        [Custom("Caption", "�ź���")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("Caption", "��ŸĶ�")]
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

        [Action(ToolTip = "�ż���ǩ�ĺ�-����-��Ÿı䣨�ĺ�������")]
        public void IdChange()
        {
            if (IsIdChange != false)
            {
                MarkChange mc = new MarkChange(Session);
                mc.MarkType = MarkTpye.�ż�;
                mc.CreateBy = AskBy;
                mc.NewId = Id;
                mc.CreateOn = CreateOn;
                mc.Type = Tpye.ToString();

            }

        }
   
    }

}
