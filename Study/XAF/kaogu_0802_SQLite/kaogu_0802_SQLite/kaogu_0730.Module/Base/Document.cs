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
    public class Document : BaseDomainObject
    {
        public Document(Session session) : base(session) { }

        protected override void OnSaving()
        {
            base.OnSaving();

            if (String.IsNullOrEmpty(this.Code))
            {
                DocNoSequenceSetting docNoSeqSetting = Session.FindObject<DocNoSequenceSetting>(
                    new BinaryOperator("DomainObjectType", ClassInfo.FullName, BinaryOperatorType.Equal));
                if (docNoSeqSetting == null)
                {
                    throw new Exception("没有定义单据编码规则, 请先设置!");
                }
                else
                {
                    if (docNoSeqSetting.SequenceStyle == DocNoSequenceStyleEnum.Menual)
                    {
                        throw new Exception("当前单据编码规则为手工录入, 请录入编码!");
                    }

                    if (docNoSeqSetting.SequenceDefine == null)
                    {
                        throw new Exception("编码规则不存在!");
                    }
                    this.Code = docNoSeqSetting.SequenceDefine.GetDocNo();
                }
            }
        }
    }

}
