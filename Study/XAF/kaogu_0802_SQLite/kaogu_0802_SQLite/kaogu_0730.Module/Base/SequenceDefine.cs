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
    [MapInheritance(MapInheritanceType.OwnTable)]
    public class SequenceDefine : BaseDomainObject
    {
        public SequenceDefine(Session session) : base(session) { }

        private string nothing;

        public string Nothing
        {
            get { return nothing; }
            set { SetPropertyValue("Nothing", ref nothing, value); }
        }

        [Association("SequenceDefine-Segments"), Aggregated]
        public XPCollection<SequenceDefineSegment> Segments
        {
            get { return GetCollection<SequenceDefineSegment>("Segments"); }
        }

        public string GetDocNo()
        {   
            string docNo = "";

            foreach (SequenceDefineSegment segment in Segments)
            {
                if (segment.SegmentType == SequenceDefineSegmentTypeEnum.Constant)
                {
                    docNo += segment.SegmentValue;
                    docNo += segment.SegmentSplitMark;
                }
                else if (segment.SegmentType == SequenceDefineSegmentTypeEnum.FlowNo)
                {
                    BinaryOperator op1 = new BinaryOperator("SequenceDefine", this.Oid);
                    BinaryOperator op2 = new BinaryOperator("SequenceBy", docNo);
                    CriteriaOperator op = CriteriaOperator.And(op1, op2);
                    Sequence seq = Session.FindObject<Sequence>(op);
                    if (seq == null)
                    {
                        seq = new Sequence(Session);
                        seq.SequenceDefine = this;
                        seq.SequenceBy = docNo;
                        seq.NextNo = 1;
                        seq.Save();
                    }

                    int flowNo = seq.NextNo;
                    string flowNoString = GetFlowNo(flowNo, segment.SegmentLength, segment.PadCharacter, segment.PadType);
                    docNo += flowNoString;

                    seq.NextNo += 1;
                    seq.Save();

                }
            }

            return docNo;
        }

        private string GetFlowNo(int flowNo, int length, string padChar, SequenceDefineSegmentPadTypeEnum padType)
        {
            string reFlowNo = flowNo.ToString();

            int needToPad = length - reFlowNo.Length;

            for (int i = 0; i < needToPad; i++)
            {
                if (padType == SequenceDefineSegmentPadTypeEnum.Left)
                {
                    reFlowNo = padChar + reFlowNo;
                }
                else if (padType == SequenceDefineSegmentPadTypeEnum.Left)
                {
                    reFlowNo = reFlowNo + padChar;
                }
            }

            return reFlowNo;
        }
    }

}
