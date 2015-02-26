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
    [Custom("Caption", "遗物标签/出土物登记")]
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
                mc.MarkType = WorkType.遗物;
                mc.CreateBy = RecordBy; 
                mc.NewId = Id;
                mc.CreateOn = CreateOn;
                mc.Type = Type.ToString();
                
            }    
        }
        
        //出土物来源 堆积-探方-遗迹登记

        [Custom("Caption", "所属堆积")]
        [Association("Accumulation-RemainMark", typeof(Accumulation))]
        public Accumulation Accumulation
        {
            get { return GetPropertyValue<Accumulation>("Accumulation"); }
            set { SetPropertyValue("Accumulation", value); }
        }

        [Custom("Caption", "所属探方")]
        [Association("ExcavationTrench-RemainMark", typeof(ExcavationTrench))]
        public ExcavationTrench ExcavationTrench
        {
            get { return GetPropertyValue<ExcavationTrench>("ExcavationTrench"); }
            set { SetPropertyValue("ExcavationTrench", value); }
        }

        [Custom("Caption", "所属遗迹")]

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

        [Custom("Caption", "对应地面及界面")]
        [Association("ExcavationFeatureGround-RemainMark", typeof(ExcavationFeatureGround))]
        public ExcavationFeatureGround ExcavationFeatureGround
        {
            get { return GetPropertyValue<ExcavationFeatureGround>("ExcavationFeatureGround"); }
            set { SetPropertyValue("ExcavationFeatureGround", value); }
        }

        [Custom("Caption", "对应坑状遗迹")]
        [Association("ExcavationFeatureHole-RemainMark", typeof(ExcavationFeatureHole))]
        public ExcavationFeatureHole ExcavationFeatureHole
        {
            get { return GetPropertyValue<ExcavationFeatureHole>("ExcavationFeatureHole"); }
            set { SetPropertyValue("ExcavationFeatureHole", value); }
        }

        [Custom("Caption", "对应堆状遗迹-地表建筑")]
        [Association("ExcavationFeaturePile-RemainMark1", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile1
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile1"); }
            set { SetPropertyValue("ExcavationFeaturePile1", value); }
        }

        [Custom("Caption", "对应堆状遗迹-地下建筑")]
        [Association("ExcavationFeaturePile-RemainMark2", typeof(ExcavationFeaturePile))]
        public ExcavationFeaturePile ExcavationFeaturePile2
        {
            get { return GetPropertyValue<ExcavationFeaturePile>("ExcavationFeaturePile2"); }
            set { SetPropertyValue("ExcavationFeaturePile2", value); }
        }

        [Custom("Caption", "对应带坑堆状遗迹-地表建筑")]
        [Association("ExcavationFeaturePileHole-RemainMark1", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole1
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole1"); }
            set { SetPropertyValue("ExcavationFeaturePileHole1", value); }
        }

        [Custom("Caption", "对应带坑堆状遗迹-地下建筑")]
        [Association("ExcavationFeaturePileHole-RemainMark2", typeof(ExcavationFeaturePileHole))]
        public ExcavationFeaturePileHole ExcavationFeaturePileHole2
        {
            get { return GetPropertyValue<ExcavationFeaturePileHole>("ExcavationFeaturePileHole2"); }
            set { SetPropertyValue("ExcavationFeaturePileHole2", value); }
        }
        [Custom("Caption", "遗迹登记-柱洞遗迹")]
        [Association("ExcavationFeaturePillarHole-RemainMark", typeof(ExcavationFeaturePillarHole))]
        public ExcavationFeaturePillarHole ExcavationFeaturePillarHole
        {
            get { return GetPropertyValue<ExcavationFeaturePillarHole>("ExcavationFeaturePillarHole"); }
            set { SetPropertyValue("ExcavationFeaturePillarHole", value); }
        }

        [Custom("Caption", "对应墓葬遗迹-地表建筑")]
        [Association("ExcavationFeatureTomb-RemainMark1", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb1
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb1"); }
            set { SetPropertyValue("ExcavationFeatureTomb1", value); }
        }

        [Custom("Caption", "对应墓葬遗迹-墓圹")]
        [Association("ExcavationFeatureTomb-RemainMark2", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb2
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb2"); }
            set { SetPropertyValue("ExcavationFeatureTomb2", value); }
        }

        [Custom("Caption", "对应墓葬遗迹-墓室")]
        [Association("ExcavationFeatureTomb-RemainMark3", typeof(ExcavationFeatureTomb))]
        public ExcavationFeatureTomb ExcavationFeatureTomb3
        {
            get { return GetPropertyValue<ExcavationFeatureTomb>("ExcavationFeatureTomb3"); }
            set { SetPropertyValue("ExcavationFeatureTomb3", value); }
        }
    }
    
    public enum RemainType 
    { 未知, 器物_小件, 陶片, 骨骼, 土样, 碳样, 金属样, 骨骼样, 玉石样, 陶瓷样, 纺织品样, 漆器样, 其他}

}
