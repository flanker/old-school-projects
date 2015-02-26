using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace kaogu_0730.Module.Base
{
    [NonPersistent]
    public class BaseDomainObject : BaseObject
    {
        public BaseDomainObject(Session session) : base(session) { }

        private string code;
        //[RuleRequiredField("RuleRequiredField for BaseDomainObject.Code", DefaultContexts.Save)]
        public string Code
        {
            get { return code; }
            set { SetPropertyValue("Code", ref code, value); }
        }

        private string name;
        [RuleRequiredField("RuleRequiredField for BaseDomainObject.Name", DefaultContexts.Save)]
        public string Name
        {
            get { return name; }
            set { SetPropertyValue("Name", ref name, value); }
        }
    }

}
