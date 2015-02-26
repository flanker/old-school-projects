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
    [DefaultClassOptions]
    public class DocNoSequenceSetting : BaseObject
    {
        public DocNoSequenceSetting(Session session) : base(session) { }

        private string domainObjectType;
        public string DomainObjectType
        {
            get { return domainObjectType; }
            set { SetPropertyValue("DomainObjectType", ref domainObjectType, value); }
        }

        private SequenceDefine sequenceDefine;
        public SequenceDefine SequenceDefine
        {
            get { return sequenceDefine; }
            set { SetPropertyValue("SequenceDefine", ref sequenceDefine, value); }
        }

        private DocNoSequenceStyleEnum sequenceStyle;
        public DocNoSequenceStyleEnum SequenceStyle
        {
            get { return sequenceStyle; }
            set { SetPropertyValue("SequenceStyle", ref sequenceStyle, value); }
        }
    }

    public enum DocNoSequenceStyleEnum
    {
        Auto,
        Menual
    }

}
