using System;
using System.ComponentModel;

using DevExpress.Xpo;
using DevExpress.Data.Filtering;

using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace kaogu_0730.Module
{
    [DefaultClassOptions]
    [Custom("Caption", "�����ǩ")]
    public class RemainMark : BaseObject
    {
        public RemainMark(Session session) : base(session) { }

        [Custom("Caption", "���")]
        public string Id
        {
            get { return GetPropertyValue<string>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        [Custom("Caption", "���")]
        public RemainType Type
        {
            get { return GetPropertyValue<RemainType>("Type"); }
            set { SetPropertyValue("Type", value); }
        }

        [Custom("Caption", "����")]
        public string Name
        {
            get { return GetPropertyValue<string>("Name"); }
            set { SetPropertyValue("Name", value); }
        }

        [Custom("Caption", "����")]
        public int Number
        {
            get { return GetPropertyValue<int>("Number"); }
            set { SetPropertyValue("Number", value); }
        }

        [Custom("Caption", "λ��")]
        public string Location
        {
            get { return GetPropertyValue<string>("Location"); }
            set { SetPropertyValue("Location", value); }
        }

       
        public float X
        {
            get { return GetPropertyValue<float>("X"); }
            set { SetPropertyValue("X", value); }
        }

       
        public float Y
        {
            get { return GetPropertyValue<float>("Y"); }
            set { SetPropertyValue("Y", value); }
        }

        public float Z
        {
            get { return GetPropertyValue<float>("Z"); }
            set { SetPropertyValue("Z", value); }
        }


        [Custom("Caption", "��¼��")]
        public Worker RecordBy
        {
            get { return GetPropertyValue<Worker>("RecordBy"); }
            set { SetPropertyValue("RecordBy", value); }
        }

        [Custom("EditMask", "G")]
        [Custom("DisplayFormat", "{0:G}")]
        [Custom("Caption", "��¼ʱ�䣨��ȷ���֣�")]
        public DateTime CreateOn
        {
            get { return GetPropertyValue<DateTime>("CreateOn"); }
            set { SetPropertyValue("CreateOn", value); }
        }

        [Custom("Caption", "�ĺ�")]
        public Boolean IsIdChange
        {
            get { return GetPropertyValue<Boolean>("IsIdChange"); }
            set { SetPropertyValue("IsIdChange", value); }
        }

        [Custom("Caption", "��ע")]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }


        [Action(ToolTip = "�����ǩ�ĺ�-����-��Ÿı䣨�ĺ�������")]       
        public void IdChange()
        {
            if (IsIdChange != false) {
                MarkChange mc = new MarkChange(Session);
                mc.MarkType = MarkTpye.����;
                mc.CreateBy = RecordBy; 
                mc.NewId = Id;
                mc.CreateOn = CreateOn;
                mc.Type = Type.ToString();
                
            }
            
        }

    }
    
    public enum RemainType 
    { δ֪, ����_С��, ��Ƭ, ����, ����, ̼��, ������, ������, ��ʯ��, �մ���, ��֯Ʒ��, ������, ����}

}
