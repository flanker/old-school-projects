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
    public class Resume : BaseObject
    {
        public Resume(Session session) : base(session) { }

        private Contact contact;
        private FileData file;

        [Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        public FileData File
        {
            get { return file; }
            set
            {
                SetPropertyValue("File", ref file, value);
            }
        }
        public Contact Contact
        {
            get
            {
                return contact;
            }
            set
            {
                SetPropertyValue("Contact", ref contact,
                value);
            }
        }
        [Aggregated, Association("Resume-PortfolioFileData", typeof(PortfolioFileData))]
        public XPCollection<PortfolioFileData> Portfolio
        {
            get
            {
                return GetCollection<PortfolioFileData>(
                    "Portfolio");
            }
        }
    }

    public class PortfolioFileData : FileAttachmentBase
    {
        public PortfolioFileData(Session session)
            : base(session) { }

        private DocumentType documentType;
        protected Resume resume;

        [Persistent, Association("Resume-PortfolioFileData")]
        public Resume Resume
        {
            get { return resume; }
            set
            {
                SetPropertyValue("Resume", ref resume, value);
            }
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            documentType = DocumentType.Unknown;
        }
        public DocumentType DocumentType
        {
            get { return documentType; }
            set
            {
                SetPropertyValue("DocumentType", ref documentType, value);
            }
        }
    }

    public enum DocumentType
    {
        SourceCode = 1, 
        Tests = 2,
        Documentation = 3,
        Diagrams = 4, 
        ScreenShots = 5, 
        Unknown = 6
    }

}
