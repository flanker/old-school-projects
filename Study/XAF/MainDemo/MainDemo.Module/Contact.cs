using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MainDemo.Module
{
    [DefaultClassOptions]
    public class Contact : Person
    {
        private string webPageAddress;
        private string nickName;
        private string spouseName;
        private TitleOfCourtesy titleOfCourtesy;
        private string notes;
        private DateTime anniversary;
        public Contact(Session session) : base(session) { }
        public string WebPageAddress
        {
            get { return webPageAddress; }
            set { SetPropertyValue("WebPageAddress", ref webPageAddress, value); }
        }
        public string NickName
        {
            get { return nickName; }
            set { SetPropertyValue("NickName", ref nickName, value); }
        }
        public string SpouseName
        {
            get { return spouseName; }
            set { SetPropertyValue("SpouseName", ref spouseName, value); }
        }
        public TitleOfCourtesy TitleOfCourtesy
        {
            get { return titleOfCourtesy; }
            set { SetPropertyValue("TitleOfCourtesy", ref titleOfCourtesy, value); }
        }
        public DateTime Anniversary
        {
            get { return anniversary; }
            set { SetPropertyValue("Anniversary", ref anniversary, value); }
        }
        [Size(4096)]
        public string Notes
        {
            get { return notes; }
            set { SetPropertyValue("Notes", ref notes, value); }
        }

        [Association("Contact-DemoTask")]
        public XPCollection<DemoTask> DemoTasks
        {
            get { return GetCollection<DemoTask>("DemoTasks"); }
        }
    }
    public enum TitleOfCourtesy { Dr, Miss, Mr, Mrs, Ms };

}
