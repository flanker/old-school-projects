using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.Data.Filtering;

namespace MainDemo.Module
{
    public partial class FindBySubjectController : ViewController
    {
        public FindBySubjectController()
        {
            InitializeComponent();
            RegisterActions(components);
        }

        private void FindBySubjectController_Activated(object sender, EventArgs e)
        {
            FindBySubjectAction.Active.SetItemValue("ObjectType", 
                View.ObjectTypeInfo.Type == typeof(DemoTask));
        }

        private void FindBySubjectAction_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            ObjectSpace objectSpace = Application.CreateObjectSpace();
            string paramValue = e.ParameterCurrentValue.ToString();
            if (!string.IsNullOrEmpty(paramValue))
            {
                paramValue = "%" + paramValue + "%";
            }
            object obj = objectSpace.FindObject(View.ObjectTypeInfo.Type,
               new BinaryOperator("Subject", paramValue, BinaryOperatorType.Like));
            if (obj != null)
            {
                e.ShowViewParameters.CreatedView = Application.CreateDetailView(objectSpace, obj);
            }
        }
    }
}
