using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MySolution.Module
{
    [DefaultClassOptions]
    public class Payment : BaseObject
    {
        public Payment(Session session) : base(session) { }

        private double rate;
        private double hours;

        [Persistent]
        public double Amount
        {
            get { return Rate * Hours; }
        }
        public double Rate
        {
            get { return rate; }
            set
            {
                SetPropertyValue("Rate", ref rate, value);
                OnChanged("Amount");
            }
        }
        public double Hours
        {
            get { return hours; }
            set
            {
                SetPropertyValue("Hours", ref hours, value);
                OnChanged("Amount");
            }
        }
    }
}
