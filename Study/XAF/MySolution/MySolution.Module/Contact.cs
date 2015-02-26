using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MySolution.Module
{
    [DefaultClassOptions]
    [DefaultProperty("FullName")]
    public class Contact : Person
    {
        private string webPageAddress;
        private string nickName;
        private string spouseName;
        private TitleOfCourtesy titleOfCourtesy;
        private string notes;
        private DateTime anniversary;

        public Contact(Session session)
            : base(session)
        {
        }

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

        //private Department department;
        //public Department Department
        //{
        //    get { return department; }
        //    set { SetPropertyValue("Department", ref department, value); }
        //}

        private Position position;
        public Position Position
        {
            get { return position; }
            set { SetPropertyValue("Position", ref position, value); }
        }

        [Association("Contact-DemoTask", typeof(DemoTask))]
        public XPCollection Tasks
        {
            get { return GetCollection("Tasks"); }
        }

        private Department department;
        [Association("Department-Contacts", typeof(Department))]
        [ImmediatePostData]
        public Department Department
        {
            get { return department; }
            set
            {
                SetPropertyValue("Department", ref department, value);
                if (!IsLoading)
                {
                    Position = null;
                    if (Manager != null && Manager.Department != value)
                    {
                        Manager = null;
                    }
                }
            }
        }

        private Contact manager;
        [DataSourceProperty("Department.Contacts", DataSourcePropertyIsNullMode.SelectAll)]
        [DataSourceCriteria("Position.Title = 'Manager'")]
        public Contact Manager
        {
            get { return manager; }
            set
            {
                SetPropertyValue("Manager", ref manager, value);
            }
        }

        private ReadOnlyCollection<AuditDataItemPersistent> changeHistory;
        public ReadOnlyCollection<AuditDataItemPersistent> ChangeHistory
        {
            get
            {
                if (changeHistory == null)
                {
                    IList<AuditDataItemPersistent> sourceCollection;
                    sourceCollection = AuditedObjectWeakReference.GetAuditTrail(Session, this);
                    if (sourceCollection == null)
                    {
                        sourceCollection = new List<AuditDataItemPersistent>();
                    }
                    changeHistory = new ReadOnlyCollection<AuditDataItemPersistent>(sourceCollection);
                }
                return changeHistory;
            }
        }
    }

    public enum TitleOfCourtesy { Dr, Miss, Mr, Mrs, Ms };

}
