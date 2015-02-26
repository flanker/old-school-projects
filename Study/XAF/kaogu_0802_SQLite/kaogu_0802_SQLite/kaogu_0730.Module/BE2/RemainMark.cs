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
    [Custom("Caption", "遗物标签")]
    public class RemainMark : BaseObject
    {
        public RemainMark(Session session) : base(session) { }

        [Custom("Caption", "编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "类别")]
        public RemainType Type
        {
            get { return GetPropertyValue<RemainType>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "名称")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "数量")]
        public int Number
        {
            get { return GetPropertyValue<int>("Number"); }
            set { SetPropertyValue("Number", value); }
        }

        [Custom("Caption", "位置")]
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


        [Custom("Caption", "记录者")]
        public Worker RecordBy
        {
            get { return GetPropertyValue<Worker>("RecordBy"); }
            set { SetPropertyValue("RecordBy", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "记录时间（精确至分）")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "改号")]
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


        [Action(ToolTip = "遗物标签改号-生成-编号改变（改号生单）")]       
        public void IdChange()
        {
            if (IsIdChange != false) {
                MarkChange mc = new MarkChange(Session);
                mc.MarkType = MarkTpye.遗物;
                mc.CreateBy = RecordBy; 
                mc.NewId = Id;
                mc.CreateOn = CreateOn;
                mc.Type = Type.ToString();
                
            }
            
        }

    }
    
    public enum RemainType 
    { 未知, 器物_小件, 陶片, 骨骼, 土样, 碳样, 金属样, 骨骼样, 玉石样, 陶瓷样, 纺织品样, 漆器样, 其他}

}
