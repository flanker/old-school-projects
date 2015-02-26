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
    [Custom("Caption", "入库登记")]
    public class InStorage : BaseObject
    {
        public InStorage(Session session) : base(session) { }

        

        [Custom("Caption", "工作方式")]
        public WorkTypeStoreage WorkType
        {
            get { return GetPropertyValue<WorkTypeStoreage>("WorkType"); }
            set { SetPropertyValue("WorkType", value); }
        }

        [Custom("Caption", "遗物类型")]
        public RemainType RemainType
        {
            get { return GetPropertyValue<RemainType>("RemainType"); }
            set { SetPropertyValue("RemainType", value); }
        }

        [Custom("Caption", "遗物编号")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }          
        }       

        [Custom("Caption", "遗物名称")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "记录时间（精确至分）")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "采集人")]
        public Worker CreateBy
        {
            get { return GetPropertyValue<Worker>("CreateBy"); }
            set { SetPropertyValue("CreateBy", value); }
        }

        [Custom("Caption", "核对人")]
        public Worker CheckBy
        {
            get { return GetPropertyValue<Worker>("CheckBy"); }
            set { SetPropertyValue("CheckBy", value); }
        }

        [Custom("Caption", "备注")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        [Action(ToolTip = "由库存遗物生成出库登记")]
        public void PutOut()
        {

            OutStorage os = new OutStorage(Session);
            os.WorkType = WorkType;
            os.RemainType = RemainType;
            os.Id = Id;
            os.Name = Name;
            
        }
    }

    public enum WorkTypeStoreage { 未知, 调查, 挖掘 }


}
