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
    public class SequenceDefineSegment : BaseObject
    {
        public SequenceDefineSegment(Session session) : base(session) { }

        private int number;
        public int Number
        {
            get { return number; }
            set { SetPropertyValue("Number", ref number, value); }
        }

        private SequenceDefineSegmentTypeEnum segmentType;
        public SequenceDefineSegmentTypeEnum SegmentType
        {
            get { return segmentType; }
            set { SetPropertyValue("SegmentType", ref segmentType, value); }
        }

        private string segmentValue;
        public string SegmentValue
        {
            get { return segmentValue; }
            set { SetPropertyValue("SegmentValue", ref segmentValue, value); }
        }

        private int segmentLength;
        public int SegmentLength
        {
            get { return segmentLength; }
            set { SetPropertyValue("SegmentLength", ref segmentLength, value); }
        }

        private SequenceDefineSegmentPadTypeEnum padType;
        public SequenceDefineSegmentPadTypeEnum PadType
        {
            get { return padType; }
            set { SetPropertyValue("PadType", ref padType, value); }
        }

        private string padCharacter;
        public string PadCharacter
        {
            get { return padCharacter; }
            set { SetPropertyValue("PadCharacter", ref padCharacter, value); }
        }

        private bool isFlowBy;
        public bool IsFlowBy
        {
            get { return isFlowBy; }
            set { SetPropertyValue("IsFlowBy", ref isFlowBy, value); }
        }

        private string segmentSplitMark;
        public string SegmentSplitMark
        {
            get { return segmentSplitMark; }
            set { SetPropertyValue("SegmentSplitMark", ref segmentSplitMark, value); }
        }

        private SequenceDefine sequenceDefine;
        [Association("SequenceDefine-Segments", typeof(SequenceDefine))]
        public SequenceDefine SequenceDefine
        {
            get { return sequenceDefine; }
            set { SetPropertyValue("SequenceDefine", ref sequenceDefine, value); }
        }

    }

    public enum SequenceDefineSegmentTypeEnum
    {
        Constant,
        FlowNo
    }

    public enum SequenceDefineSegmentPadTypeEnum
    {
        Left,
        Right
    }
}
