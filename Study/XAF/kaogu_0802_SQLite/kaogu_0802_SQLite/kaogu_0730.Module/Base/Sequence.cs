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
    public class Sequence : BaseObject
    {
        public Sequence(Session session) : base(session) { }

        private SequenceDefine sequenceDefine;
        public SequenceDefine SequenceDefine
        {
            get { return sequenceDefine; }
            set { SetPropertyValue("SequenceDefine", ref sequenceDefine, value); }
        }

        private string sequenceBy;
        public string SequenceBy
        {
            get { return sequenceBy; }
            set { SetPropertyValue("SequenceBy", ref sequenceBy, value); }
        }

        private int nextNo;
        public int NextNo
        {
            get { return nextNo; }
            set { SetPropertyValue("NextNo", ref nextNo, value); }
        }
    }

}
