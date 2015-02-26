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
                    throw new Exception("û�ж��嵥�ݱ������, ��������!");
                }
                else
                {
                    if (docNoSeqSetting.SequenceStyle == DocNoSequenceStyleEnum.Menual)
                    {
                        throw new Exception("��ǰ���ݱ������Ϊ�ֹ�¼��, ��¼�����!");
                    }

                    if (docNoSeqSetting.SequenceDefine == null)
                    {
                        throw new Exception("������򲻴���!");
                    }
                    this.Code = docNoSeqSetting.SequenceDefine.GetDocNo();
                }
            }
        }
    }

}
