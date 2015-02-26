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
    /// 虚拟员工表
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
        /// 员工编号
        /// </summary>
        [Size(20)]
        [DisplayName("员工编号")]
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
        /// 员工姓名
        /// </summary>
        [Size(50)]
        [DevExpress.Xpo.DisplayName("员工姓名")]
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
    /// 虚拟业务表
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
        /// 主键，不显示
        /// VisibleInListView属性来确认在listView中是否显示此列，相似的有VisibleInDetailViewAttribute、
        /// VisibleInLookupListViewAttribute、VisibleInReportsAttribute
        /// 相关属性可参照帮助文档中Concepts->Business Model Design->Built-in Attributes章节，里面有详细描述
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
        /// 业务描述
        /// Size属性是XPO提供的，而不是Persistent.Base中的，相关文档可以通过XPO帮助文档中找到；
        /// Size在这里可以控制界面录入长度；
        /// DisplayName用来本地化；
        /// </summary>
        [Size(50)]
        [DisplayName("业务描述")]
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
        /// 客户描述
        /// </summary>
        [Size(50)]
        [DevExpress.Xpo.DisplayName("客户描述")]
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