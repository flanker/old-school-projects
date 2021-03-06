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
    [Custom("Caption", "遗迹标签")]
    public class FeatureMark : BaseObject
    {
        public FeatureMark(Session session) : base(session) { }

        [Custom("Caption", "类别")]
        public FeatureCode Type
        {
            get { return GetPropertyValue<FeatureCode>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "遗迹编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "放号时间（精确到分）")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "申请人")]
        public Worker AskBy
        {
            get { return GetPropertyValue<Worker>("AskBy"); }
            set { SetPropertyValue("AskBy", value); }
        }

        [Custom("Caption", "放号人")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("Caption", "编号改动")]
        public Boolean IsIdChange
        {
            get { return GetPropertyValue<Boolean>("IsIdChange"); }
            set { SetPropertyValue("IsIdChange", value); }
        }

        [Custom("Caption", "备注")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        [Action(ToolTip = "遗迹标签改号-生成-编号改变（改号生单）")]
        public void IdChange()
        {
            if (IsIdChange != false)
            {
                MarkChange mc = new MarkChange(Session);
                mc.MarkType = WorkType.遗迹;
                mc.CreateBy = AskBy;
                mc.NewId = Id;
                mc.CreateOn = CreateOn;
                mc.Type  =  Type.ToString();
         
            }

        }
   
    }

}
