using System;
using DevExpress.Persistent.AuditTrail;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using DevExpress.Persistent.Validation;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace TimeLimited.Module
{
    /// <summary>
    /// ����Ա����
    /// </summary>
    [DefaultClassOptions]
    public class Employee : BaseObject
    {
		private string empID;
        private string empName;
        public Employee(Session session)
            : base(session)
        {
		}
        /// <summary>
        /// Ա�����
        /// </summary>
        [Size(20)]
        [DisplayName("Ա�����")]
        public string EmpID
        {
			get {
                return empID;
			}
			set {
                SetPropertyValue("EmpID", ref empID, value);
			}
		}
        /// <summary>
        /// Ա������
        /// </summary>
        [Size(50)]
        [DevExpress.Xpo.DisplayName("Ա������")]
        public string EmpName
        {
			get {
                return empName;
			}
			set {
                SetPropertyValue("EmpName", ref empName, value);
			}
		}
    }

    /// <summary>
    /// ����ҵ���
    /// </summary>
    [DefaultClassOptions]
    public class OpCase : BaseObject
    {
        private Guid opCaseID;
        private string opInfo;
        private string customerName;
        public OpCase(Session session)
            : base(session)
        {
            opCaseID = new Guid();
        }
        /// <summary>
        /// ����������ʾ
        /// VisibleInListView������ȷ����listView���Ƿ���ʾ���У����Ƶ���VisibleInDetailViewAttribute��
        /// VisibleInLookupListViewAttribute��VisibleInReportsAttribute
        /// ������Կɲ��հ����ĵ���Concepts->Business Model Design->Built-in Attributes�½ڣ���������ϸ����
        /// </summary>
        [VisibleInListView(false)]
        public Guid OpCaseID
        {
            get
            {
                return opCaseID;
            }
            set
            {
                SetPropertyValue("OpCaseID", ref opCaseID, value);
            }
        }
        /// <summary>
        /// ҵ������
        /// Size������XPO�ṩ�ģ�������Persistent.Base�еģ�����ĵ�����ͨ��XPO�����ĵ����ҵ���
        /// Size��������Կ��ƽ���¼�볤�ȣ�
        /// DisplayName�������ػ���
        /// </summary>
        [Size(50)]
        [DisplayName("ҵ������")]
        public string OpInfo
        {
            get
            {
                return opInfo;
            }
            set
            {
                SetPropertyValue("OpInfo", ref opInfo, value);
            }
        }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        [Size(50)]
        [DevExpress.Xpo.DisplayName("�ͻ�����")]
        public string CustomerName
        {
            get
            {
                return customerName;
            }
            set
            {
                SetPropertyValue("CustomerName", ref customerName, value);
            }
        }
    }
}